using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMng : MonoBehaviour
{
    private Rigidbody2D MyRigidbody;
    static public Rigidbody2D CurrTarget;
    private bool NeedClear;

    public float Xoffset;
    public float Yoffset;

    private void Start()
    {
        MyRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        Vector2 Scroll = Input.mouseScrollDelta;

        if (Scroll != Vector2.zero)
        {
            float CurrDistanse = Camera.main.orthographicSize - Scroll.y;

            if (CurrDistanse < 2)
                CurrDistanse = 2;
            if (CurrDistanse > 20)
                CurrDistanse = 20;

            Camera.main.orthographicSize = CurrDistanse;
        }

        if (Input.GetMouseButton(0))
        {
            if (CurrTarget == null)
            {
                float CurrDistanse = Camera.main.orthographicSize - Scroll.y;
                Camera.main.transform.position = new Vector3(-Input.GetAxis("Mouse X") * 0.1f * CurrDistanse, -Input.GetAxis("Mouse Y") * 0.1f * CurrDistanse, 0) + Camera.main.transform.position;
            }
            else
            {
                Vector3 WorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
                MyRigidbody.MovePosition(new Vector2(WorldPos.x, WorldPos.y) + (Vector2.right * Xoffset) + (Vector2.up * Yoffset));
                CurrTarget.MovePosition(MyRigidbody.position);
                NeedClear = true;
            }

        }
        else
        {
            if (NeedClear)
            {
                NeedClear = false;
                CurrTarget = null;
            }
            Vector3 WorldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            MyRigidbody.MovePosition(new Vector2(WorldPos.x, WorldPos.y) + (Vector2.right * Xoffset) + (Vector2.up * Yoffset));
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Input.GetMouseButton(0))
        {
            Debug.Log("Курсор над " + collision.name);
            if (collision.tag == "MoveBar")
            {
                CurrTarget = collision.gameObject.GetComponent<MoveBar>().MovedRigidbody;
                Debug.Log("Курсор готов зацепить");
            }
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!Input.GetMouseButton(0))
        {
            Debug.Log("Курсор вышл");
            CurrTarget = null;
        }

    }

    public void AddItem(GameObject item)
    {
        Vector3 CamPos = Camera.main.transform.position;
        Instantiate(item, CamPos + (Vector3.forward * 100), new Quaternion(0,0,0,1));
    }
}
