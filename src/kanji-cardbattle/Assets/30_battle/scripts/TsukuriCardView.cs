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

    public float speed = 5.0f;
    private Rigidbody2D rb = null;

    void Start()
     {
         //コンポーネントのインスタンスを捕まえる
         rb = GetComponent<Rigidbody2D>();
     }

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
        Vector3 CardPos = transform.position;
        Vector3 MyField = GameObject.Find("myfield").transform.position;

Debug.Log("座標"+CardPos.y);
        rb.velocity = new Vector2( (MyField.x - CardPos.x ) * speed, (-CardPos.y)*speed);

        GameObject target1 = GameObject.Find("Bushu");
        if( target1.GetComponent<BushuCardView>().MyTsukuriUnique.Contains(TsukuriUnique) == true){
Debug.Log("ヒット！");

            gameObject.SetActive (false);
            GameManager.instance.doNextTsukuri++;

            for(int i = 0; i < ReadKanjiCSV.instance.getListCount(); i++){
                if(ReadKanjiCSV.instance.getKanjiCSV(i,2) == target1.GetComponent<BushuCardView>().BushuUnique){
                    if(ReadKanjiCSV.instance.getKanjiCSV(i,4) == TsukuriUnique){

                        // Transform myTransform = this.transform;
                        // Vector3 pos = transform.position;

                        // Debug.Log(pos.x);
                        // target1.GetComponent<BushuCardView>().bushuText.text = ReadKanjiCSV.instance.getKanjiCSV(i,1);
                        // GameManager.instance.doSetKanji = true;
                        // GameManager.instance.KanjiPower = Power;
                        // GameManager.instance.KanjiUnique = i.ToString();
                        // GameManager.instance.KanjiKanji = ReadKanjiCSV.instance.getKanjiCSV(i,1);
                    }
                }
            }
            
        }
        
        Debug.Log(target1.GetComponent<BushuCardView>().MyTsukuriUnique);
    }
}