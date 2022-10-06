using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
 
public class CardModel
{
    public int cardID;
    public string name;
    public int cost;
    public int power;
    public Sprite icon;
 
    public CardModel(int cardID)
    {
        CardEntity cardEntity = Resources.Load<CardEntity>("CardEntityList/Card" + cardID);
 
        cardID = cardEntity.cardID;
        name = cardEntity.name;
        cost = cardEntity.cost;
        power = cardEntity.power;
        icon = cardEntity.icon;
    }
}