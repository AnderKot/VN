using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ImageLoader : MonoBehaviour
{
    private ImageMng MyManager;
    public string ImagePath;
    public Transform FatherObgect;
    public GameObject ImageManager;

    private void OnMouseDown()
    {
        Cursor.visible = true;
        ImagePath = EditorUtility.OpenFilePanel("Celect image", "", "png,jpg");
        Cursor.visible = false;

        if (ImagePath.Length != 0)
        {
            if (MyManager == null)
            {
                MyManager = Instantiate(ImageManager, FatherObgect).GetComponent<ImageMng>();
            }
            //MyManager.SetImagePathFrom(ImagePath);
        }
    }
}
