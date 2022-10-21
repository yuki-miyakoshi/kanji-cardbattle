using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

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
        GetComponent<timeClock>().doStart = false;
Debug.Log("タップ");
        Vector3 CardPos = transform.position;
        Vector3 MyField = GameObject.Find("myfield").transform.position;
Debug.Log("座標"+CardPos.y);
        rb.velocity = new Vector2( (MyField.x - CardPos.x ) * speed, (-CardPos.y)*speed);
        GameObject target1 = GameObject.Find("Bushu");

        StartCoroutine(DelayMethod(2.0f, () =>{

            if( target1.GetComponent<BushuCardView>().MyTsukuriUnique.Contains(TsukuriUnique) == true){
Debug.Log("ヒット！");

                gameObject.SetActive (false);
                // GameManager.instance.doNextTsukuri++;

                // rb.velocity = new Vector2( 0,0);
                // rb.gravityScale = 0.0f;

                // GetComponent<CardController>().TsukuriInit(GameManager.instance.countTsukuriID);
                // GameManager.instance.countTsukuriID++;
                // GetComponent<timeClock>().UIobj.fillAmount = 5.0f;

                // for(int i = 0; i < ReadKanjiCSV.instance.getListCount(); i++){
                //     if(ReadKanjiCSV.instance.getKanjiCSV(i,2) == target1.GetComponent<BushuCardView>().BushuUnique){
                //         if(ReadKanjiCSV.instance.getKanjiCSV(i,4) == TsukuriUnique){

                //             Transform myTransform = this.transform;
                //             Vector3 pos = transform.position;

                //             Debug.Log(pos.x);
                //             target1.GetComponent<BushuCardView>().bushuText.text = ReadKanjiCSV.instance.getKanjiCSV(i,1);
                //             GameManager.instance.doSetKanji = true;
                //             GameManager.instance.KanjiPower = Power;
                //             GameManager.instance.KanjiUnique = i.ToString();
                //             GameManager.instance.KanjiKanji = ReadKanjiCSV.instance.getKanjiCSV(i,1);
                //         }
                //     }
                // }
                
            }else{
                rb.velocity = new Vector2( 1,1);
                rb.gravityScale = 1.0f;
            }

            StartCoroutine(DelayMethod(10.0f, () =>{

                GetComponent<CardController>().TsukuriInit(GameManager.instance.countTsukuriID);
                GameManager.instance.countTsukuriID++;
                transform.position = CardPos;
                rb.velocity = new Vector2( 0,0);
                rb.gravityScale = 0.0f;
                gameObject.SetActive (true);
                GetComponent<timeClock>().doStart = true;

            }));

        }));
        
        Debug.Log(target1.GetComponent<BushuCardView>().MyTsukuriUnique);
    }

private IEnumerator DelayMethod(float waitTime, Action action)
{
    yield return new WaitForSeconds(waitTime);
    action();
}
    
}