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

    private Vector3 CardPos;
    private Vector3 MyField;
    public bool inactive;

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

        inactive = false;
    }

    public void OnClickCombineCard(){

        if(inactive == false){
            // GameObject.Find("GameObject").GetComponent<GameManager>().isMoving = true;

            CardPos = transform.position;
            MyField = GameObject.Find("myfield").transform.position;

            inactive = true;
            GetComponent<timeClock>().doStart = false;
            rb.velocity = new Vector2( (MyField.x - CardPos.x ) * speed, (-CardPos.y)*speed);
            GameObject target1 = GameObject.Find("Bushu");

            StartCoroutine(DelayMethod(2.0f, () =>{

                if( target1.GetComponent<BushuCardView>().MyTsukuriUnique.Contains(TsukuriUnique) == true){

                    rb.velocity = new Vector2( 0,0);
                    GameObject.Find("myscore").GetComponent<Text>().text = ( int.Parse(GameObject.Find("myscore").GetComponent<Text>().text) + Power ).ToString();


                // gameObject.SetActive (false);
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
                    // GameObject.Find("GameObject").GetComponent<GameManager>().isMoving = false;
                    SetNextTsukuri();
                }else{
                    rb.velocity = new Vector2( 1,1);
                    rb.gravityScale = 1.0f;

                    // GameObject.Find("GameObject").GetComponent<GameManager>().isMoving = false;

                    StartCoroutine(DelayMethod(10.0f, () =>{
                        SetNextTsukuri();
                    }));
                }

            }));
        }
    }

    private void SetNextTsukuri(){
        GetComponent<CardController>().TsukuriInit(GameManager.instance.countTsukuriID);
        GameManager.instance.countTsukuriID++;
        transform.position = CardPos;
        rb.velocity = new Vector2( 0,0);
        rb.gravityScale = 0.0f;
        gameObject.SetActive (true);
        GetComponent<timeClock>().UIobj.fillAmount = 5.0f;
        GetComponent<timeClock>().doStart = true;
    }
        

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
    
}