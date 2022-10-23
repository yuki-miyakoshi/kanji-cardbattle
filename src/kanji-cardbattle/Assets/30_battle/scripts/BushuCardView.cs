using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class BushuCardView : MonoBehaviour
{
    [SerializeField] public Text bushuText;
    public int CardID;
    public string BushuUnique;
    public string[] MyTsukuriUnique;
    public string[] MyKanjiUnique;

    public void Show(BushuCardModel cardModel) // cardModelのデータ取得と反映
    {
        CardID = cardModel.CardID;
        BushuUnique = cardModel.BushuUnique;

        MyTsukuriUnique = cardModel.MyTsukuriUnique;
        MyKanjiUnique = cardModel.MyKanjiUnique;

        bushuText.text = cardModel.BushuText;
    }
}