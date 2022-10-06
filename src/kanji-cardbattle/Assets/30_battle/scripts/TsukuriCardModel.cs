using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public class TsukuriCardModel
{
    public int count;
    public int tsukuri_unique;
    public int power;

    public TsukuriCardModel(int cardID)
    {
        cardID = count++;
        tsukuri_unique = UnityEngine.Random.Range(1, 300);
        power = UnityEngine.Random.Range(1, 5);
    }

}