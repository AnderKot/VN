using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sizer : MonoBehaviour
{
    public Camera MainCamera;
    public SpriteRenderer MySprite;
    public float CurrX;
    public float CurrY;

    private void Start()
    {
        Application.targetFrameRate = 45;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        float newCurrX = Mathf.Round(MainCamera.transform.position.x / 10);
        float newCurrY = Mathf.Round(MainCamera.transform.position.y / 10);

        if (newCurrX != CurrX)
        {
            CurrX = newCurrX;
            MySprite.transform.position = new Vector3(MainCamera.transform.position.x, MySprite.transform.position.y, MySprite.transform.position.z);
        }


        if (newCurrY != CurrY)
        {
            CurrY = newCurrY;
            MySprite.transform.position = new Vector3(MySprite.transform.position.x, MainCamera.transform.position.y, MySprite.transform.position.z);
        }

    }
}
