using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionAdder : MonoBehaviour
{
    public GameObject option;
    public GameObject[] Options = new GameObject[5];
    private int OptionsCount;

    private void OnMouseDown()
    {
        if (OptionsCount < 5)
        {
            Options[OptionsCount] = Instantiate(option, transform);
            Rigidbody2D MovmentOption = Options[OptionsCount].GetComponent<Rigidbody2D>();
            MovmentOption.MovePosition(MovmentOption.position - (Vector2.up * (0.7f + OptionsCount)));
            OptionDelete DeleteTrigger = Options[OptionsCount].GetComponent<OptionDelete>();
            DeleteTrigger.DeleteFromList = optionDelete;
            DeleteTrigger.ID = OptionsCount;
            OptionsCount++;
        }
    }

    public void optionDelete(int id)
    {
        Options[id] = null;
        OptionsCount--;
        for (int optionNo = id+1; optionNo < 5 ; optionNo++)
        {
            if (Options[optionNo] != null)
            {
                Rigidbody2D MovmentOption = Options[optionNo].GetComponent<Rigidbody2D>();
                MovmentOption.MovePosition(MovmentOption.position - (Vector2.down));
                Options[optionNo].GetComponent<OptionDelete>().ID = optionNo - 1;
                Options[optionNo-1] = Options[optionNo];
                Options[optionNo] = null;
            }
        }
    }
}
