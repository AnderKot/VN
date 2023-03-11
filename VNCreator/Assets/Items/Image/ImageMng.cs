using Microsoft.Unity.VisualStudio.Editor;
using MyVNBase;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static System.Net.Mime.MediaTypeNames;

public class ImageMng : MonoBehaviour
{
    private RectTransform rectTransform;
    private UnityEngine.UI.Image image;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<UnityEngine.UI.Image>();
    }

    public void SetImageFromPath(string path)
    {
        // Получение данных 
        byte[] RawByte = File.ReadAllBytes(path);
        // Подготовка спрайта
        Texture2D RawTexture = new Texture2D(0,0);
        RawTexture.LoadImage(RawByte);
        Sprite NewSprite = Sprite.Create(RawTexture, new Rect(0.0f, 0.0f, RawTexture.width, RawTexture.height), new Vector2(0.5f, 0.5f));
        // настройка изображения
        image.sprite = NewSprite;
        image.type = UnityEngine.UI.Image.Type.Simple;
        image.color = Color.white;
        // Настройка положения
    }

    public void SetImage(VNImage vnImage)
    {
        // Получение данных 
        byte[] RawByte = vnImage.RawData;
        // Подготовка спрайта
        Texture2D RawTexture = new Texture2D(0, 0);
        RawTexture.LoadImage(RawByte);
        Sprite NewSprite = Sprite.Create(RawTexture, new Rect(0.0f, 0.0f, RawTexture.width, RawTexture.height), new Vector2(0.5f, 0.5f));
        // настройка изображения
        image.sprite = NewSprite;
        image.type = UnityEngine.UI.Image.Type.Simple;
        image.color = Color.white;
        // Настройка положения
        rectTransform.localPosition = vnImage.Position;
        rectTransform.localScale = vnImage.Scale;
        rectTransform.localRotation = Quaternion.Euler(0f,0f,vnImage.Rotation);
    }
}
