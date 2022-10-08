using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
 
public class BushuCardView : MonoBehaviour
{
    [SerializeField] Text bushuText;

    public void Show(BushuCardModel cardModel) // cardModelのデータ取得と反映
    {

        bushuText.text = ReadKanjiCSV.instance.getKanjiCSV(cardModel.bushu_unique,3);

    }
}