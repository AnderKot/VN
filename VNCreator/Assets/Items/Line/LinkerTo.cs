using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkerTo : MonoBehaviour
{
    public GameObject Line;

    private bool Linked;
    private Transform NextPoint;

    private void OnMouseDown()
    {
        if (!Linked)
        {
            GameObject newLine = Instantiate(Line,transform.position + (Vector3.forward * 5),new Quaternion(0,0,0,1));
            NextPoint = newLine.GetComponent<Line>().End_T;
            CursorMng.CurrTarget = NextPoint.GetComponent<Rigidbody2D>();
            Transform MyPoint = newLine.GetComponent<Line>().Start_T;
            Destroy(MyPoint.GetComponent<Collider2D>());
            Destroy(MyPoint.GetComponent<Rigidbody2D>());
            MyPoint.SetParent(transform);
            MyPoint.localPosition = Vector3.back;
            LinkSet(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Linked)
        {
            if ((collision.tag == "PointStart"))
            {
                Linked = true;
                Transform LinkedPoint = collision.transform;
                LinkedPoint.parent.GetComponent<Line>().Wall_T.GetComponent<SpriteRenderer>().color = Color.green;
                LinkedPoint.SetParent(transform);
                LinkedPoint.localPosition = Vector3.back;
                Destroy(LinkedPoint.GetComponent<Collider2D>());
                Destroy(LinkedPoint.GetComponent<Rigidbody2D>());
                CursorMng.CurrTarget = null;
            }
        }
    }

    public void LinkSet(bool linked)
    {
        Linked = linked;
    }
}
