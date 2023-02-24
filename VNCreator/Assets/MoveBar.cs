using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBar : MonoBehaviour
{
    public Rigidbody2D MovedRigidbody;

    void FixedUpdate()
    {

    }
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.name == "Cursor") & Input.GetMouseButton(0))
        {
            Vector3 WorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            MovedRigidbody.MovePosition(new Vector2(WorldPos.x, WorldPos.y) + (Vector2.up * -1f));// + (Vector2.right * 0.2f) + ) ;
        }
    }

    
    private void OnMouseDrag()
    {
        Vector3 WorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        MovedRigidbody.MovePosition(new Vector2(WorldPos.x, WorldPos.y) + (Vector2.up * -1f));// + (Vector2.right * 0.2f) + ) ;
    }
    */
}
