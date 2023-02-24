using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class EffectMng : MonoBehaviour
{
    public SpriteRenderer Effect;
    public GameObject OnButton;
    public GameObject OffButton;
    public TextMeshProUGUI TextMesh;
    public string CurrValue = "1";
    
    void FixedUpdate()
    {
        if (Effect.enabled)
        {
            float CF;
            //string newCurrValue = TextMesh.GetParsedText();
            //Regex.Replace(newCurrValue, @"\W+", "", RegexOptions.IgnoreCase);
            string newCurrValue = "20";

            if ((CurrValue != newCurrValue) & (Single.TryParse(newCurrValue, out CF)))
            {
                CurrValue = newCurrValue;
                if (CF < 1f)
                    CF = 1f;
                //Effect.material = new Material(shader);
                Effect.material.SetFloat("_Radius", CF);
            }
        }
    }

    private void OnMouseDown()
    {
        
            if (Effect.enabled)
            {
                Effect.enabled = false;
                OnButton.SetActive(false);
                OffButton.SetActive(true);
            }
            else
            {
                Effect.enabled = true;
                OnButton.SetActive(true);
                OffButton.SetActive(false);
            }
    }
}
