using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Room1 : MonoBehaviour
{
    public GameObject door;
    public Target[] targets;

    Text ValueToKill;


    private void Update()
    {
        if (Int32.Parse(ValueToKill.text) <= 0)
        {
            finishRoom1();
        }

        
    }

    private void finishRoom1()
    {
        Destroy(door);
        ValueToKill.text = "0";
        return;
    }
}
