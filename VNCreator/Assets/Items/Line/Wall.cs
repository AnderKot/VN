using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Transform Start_T;
    public Transform End_T;
    public Transform Wall_T;
    private Vector2 LastPoint;

    void FixedUpdate()
    {
        Vector2 Diraction = new Vector2(End_T.position.x - Start_T.position.x, End_T.position.y - Start_T.position.y);
        if (LastPoint != Diraction)
        {
            Wall_T.position = new Vector3((Start_T.position.x + End_T.position.x) / 2f,
                                        (Start_T.position.y + End_T.position.y) / 2f,
                                        98f);

            Wall_T.localScale = new Vector3 (Wall_T.localScale.x, Diraction.magnitude, 1f);

            Wall_T.rotation = Quaternion.LookRotation(Vector3.forward, Diraction.normalized);
            LastPoint = Diraction;
        }

    }
}
