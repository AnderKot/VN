using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkerFrom : MonoBehaviour
{
    public GameObject Line;
    private Transform NextPoint;

    protected virtual void OnMouseDown()
    {
        GameObject newLine = Instantiate(Line, transform.position + (Vector3.forward * 5), new Quaternion(0, 0, 0, 1));
        NextPoint = newLine.GetComponent<Line>().Start_T;
        CursorMng.CurrTarget = NextPoint.GetComponent<Rigidbody2D>();
        Transform MyPoint = newLine.GetComponent<Line>().End_T;
        Destroy(MyPoint.GetComponent<Collider2D>());
        Destroy(MyPoint.GetComponent<Rigidbody2D>());
        MyPoint.SetParent(transform);
        MyPoint.localPosition = Vector3.back;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "PointEnd"))
        {
            Transform LinkedPoint = collision.transform;
            LinkedPoint.parent.GetComponent<Line>().Wall_T.GetComponent<SpriteRenderer>().color = Color.green;
            LinkedPoint.parent.GetComponent<Line>().Start_T.parent.GetComponent<LinkerTo>().LinkSet(true);
            LinkedPoint.SetParent(transform);
            LinkedPoint.localPosition = Vector3.back;
            Destroy(LinkedPoint.GetComponent<Collider2D>());
            Destroy(LinkedPoint.GetComponent<Rigidbody2D>());
            CursorMng.CurrTarget = null;
        }

    }
}