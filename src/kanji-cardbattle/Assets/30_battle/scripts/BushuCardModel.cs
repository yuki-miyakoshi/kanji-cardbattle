using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public class BushuCardModel
{
    public int count;
    public int bushu_unique;

    public BushuCardModel(int cardID)
    {
        cardID = count++;
        bushu_unique = UnityEngine.Random.Range(1, 3000);
    }

}