using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Progress;

public class ImageHider : MonoBehaviour
{
    private Rigidbody2D MyRigidbody;

    public float HideLenght = 1f;
    public GameObject HideIcon;
    public GameObject ShowIcon;
    public List<GameObject> Items;

    private void Start()
    {
        MyRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        if (Items[0].active)
        {
            Items.ForEach(item => item.SetActive(false));
            HideIcon.SetActive(false);
            ShowIcon.SetActive(true);
            MyRigidbody.MovePosition(new Vector2(0, HideLenght) + MyRigidbody.position);
        }
        else
        {
            Items.ForEach(item => item.SetActive(true));
            HideIcon.SetActive(true);
            ShowIcon.SetActive(false);
            MyRigidbody.MovePosition(new Vector2(0, -HideLenght) + MyRigidbody.position);
        }
    }
}
