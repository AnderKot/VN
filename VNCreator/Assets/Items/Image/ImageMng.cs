using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class ImageMng : MonoBehaviour
{
    public SpriteRenderer MySpriteRenderer;
    public void SetImagePath(string path)
    {
        byte[] RawByte = File.ReadAllBytes(path);
        Texture2D RawTexture = new Texture2D(0,0);
        RawTexture.LoadImage(RawByte);
        Sprite NewSprite = Sprite.Create(RawTexture, new Rect(0.0f, 0.0f, RawTexture.width, RawTexture.height), new Vector2(0.5f, 0.5f));
        MySpriteRenderer.sprite = NewSprite;
        MySpriteRenderer.drawMode = SpriteDrawMode.Sliced;
        MySpriteRenderer.color = Color.white;
        //MySpriteRenderer.size = new(1* Xscale, 1 * Yscale);
        MySpriteRenderer.size = new((MySpriteRenderer.sprite.texture.width/256f), (MySpriteRenderer.sprite.texture.height/256f));
    }
}
