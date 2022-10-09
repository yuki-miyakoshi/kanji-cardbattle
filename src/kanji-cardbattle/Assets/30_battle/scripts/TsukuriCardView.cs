using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
 
public class TsukuriCardView : MonoBehaviour
{
    [SerializeField] public Text TsukuriText, PowerText;
    public int CardID;
    public string Tsukuri_unique;
    public int Power;


    public void Show(TsukuriCardModel cardModel) // cardModelのデータ取得と反映
    {
        CardID = cardModel.CardID;
        Tsukuri_unique = cardModel.Tsukuri_unique;
        Power = cardModel.Power;

        TsukuriText.text = cardModel.TsukuriText;
        PowerText.text = cardModel.Power.ToString();

    }
}