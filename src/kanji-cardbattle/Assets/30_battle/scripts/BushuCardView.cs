using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
 
public class BushuCardView : MonoBehaviour
{
    [SerializeField] Text bushuText;
    public int CardID;
    public string BushuUnique;
    public List<string> MyTsukuriUnique;

    public void Show(BushuCardModel cardModel) // cardModelのデータ取得と反映
    {
        CardID = cardModel.CardID;
        BushuUnique = cardModel.BushuUnique;

        MyTsukuriUnique = cardModel.MyTsukuriUnique;

        bushuText.text = cardModel.BushuText;
    }
}