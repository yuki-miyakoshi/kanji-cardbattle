using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
 
public class TsukuriCardView : MonoBehaviour
{
    [SerializeField] Text tsukuriText, powerText;

    public void Show(TsukuriCardModel cardModel) // cardModelのデータ取得と反映
    {
        
        tsukuriText.text = ReadKanjiCSV.instance.getKanjiCSV(cardModel.tsukuri_unique,5);
        powerText.text = cardModel.power.ToString();

    }
}