using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TsukuriCardView : MonoBehaviour
{
    [SerializeField] Text tsukuriText, powerText;
    public int CardID;
    public string TsukuriUnique;
    public int Power;


    public void Show(TsukuriCardModel cardModel) // cardModelのデータ取得と反映
    {
        CardID = cardModel.CardID;
        TsukuriUnique = cardModel.TsukuriUnique;
        Power = cardModel.Power;

        tsukuriText.text = cardModel.TsukuriText;
        powerText.text = cardModel.Power.ToString();
    }

    public void OnClickCombineCard(){
        Debug.Log("タップ");
        GameObject target1 = GameObject.Find("Bushu");
        if( target1.GetComponent<BushuCardView>().MyTsukuriUnique.Contains(TsukuriUnique) == true){
            Debug.Log("ヒット！");
            for(int i = 0; i < ReadKanjiCSV.instance.getListCount(); i++){
                if(ReadKanjiCSV.instance.getKanjiCSV(i,2) == target1.GetComponent<BushuCardView>().BushuUnique){
                    if(ReadKanjiCSV.instance.getKanjiCSV(i,4) == TsukuriUnique){
                        target1.GetComponent<BushuCardView>().bushuText.text = ReadKanjiCSV.instance.getKanjiCSV(i,1);
                    }
                }
            }
            
        }
        
        Debug.Log(target1.GetComponent<BushuCardView>().MyTsukuriUnique);
    }
}