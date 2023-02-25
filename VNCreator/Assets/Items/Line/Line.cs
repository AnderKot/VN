using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Line : MonoBehaviour
{
    public Transform Start_T;
    public Transform End_T;
    public Rigidbody2D Wall_T;

    private Vector2 LastPoint;


    void FixedUpdate()
    {
        if ((End_T != null) & (Start_T != null))
        {
            Vector2 Diraction = new Vector2(End_T.position.x - Start_T.position.x, End_T.position.y - Start_T.position.y);
            if (LastPoint != Diraction)
            {
                Wall_T.MovePosition( new Vector3((Start_T.position.x + End_T.position.x) / 2f,
                                            (Start_T.position.y + End_T.position.y) / 2f));

                Wall_T.transform.localScale = new Vector3 (Wall_T.transform.localScale.x, Diraction.magnitude, 1f);

                Wall_T.MoveRotation (Quaternion.LookRotation(Vector3.forward, Diraction.normalized));
                LastPoint = Diraction;
            }
        }
        else
        {
            if (Start_T != null)
            {
                if (Start_T.parent != transform)
                    Start_T.parent.GetComponent<LinkerTo>().LinkSet(false);
                Destroy(Start_T.gameObject);
            }
            if (End_T != null)
            {
                Destroy(End_T.gameObject);
            }
            Destroy(gameObject);
        }


    }


}
