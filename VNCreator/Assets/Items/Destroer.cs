using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destroer : MonoBehaviour
{
    public List<GameObject> DeleteObjects;
    public float MouseDobleDownTimeDelay;
    private float LastMouseDownTime;

    private void OnMouseDown()
    {
        if ((Time.time - LastMouseDownTime) < MouseDobleDownTimeDelay & (LastMouseDownTime != 0f))
        {
            DeleteObjects.ForEach(obj => Destroy(obj));
        }
        else
        {
            LastMouseDownTime = Time.time;
        }
    }
}
