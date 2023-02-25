using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionDelete : MonoBehaviour
{
    public int ID;
    public delegate void InCallback(int id);
    public InCallback DeleteFromList;

    private void OnDestroy()
    {
        DeleteFromList(ID);
    }
}
