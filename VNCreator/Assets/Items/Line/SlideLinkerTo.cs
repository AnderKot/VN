using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SlideLinkerTo : LinkerTo
{
    public GameObject Slide;

    override protected void OnMouseDown()
    {
        base.OnMouseDown();
        GameObject NewSlide = Instantiate(Slide, NextPoint.position + (Vector3.forward * 5), new Quaternion(0, 0, 0, 1));
        
    }
}
