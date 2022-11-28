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
    private float speed = 1.0f;
    private Rigidbody2D rb = null;
    private Vector3 CardPos;
    private Vector2 MyField;
    public bool inactive;
    public ParticleSystem particle;

    void Start()
     {
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
            CardPos = transform.position;
            MyField = GameObject.Find("enemyfield").transform.position;
            inactive = true;
            GetComponent<timeClock>().doStart = false;
            rb.velocity = new Vector2( (MyField.x - CardPos.x ) * speed, (-CardPos.y)*speed);
            GameObject target1 = GameObject.Find("Bushu");
            StartCoroutine(DelayMethod(1.0f, () =>{
                
                if( target1.GetComponent<BushuCardView>().MyTsukuriUnique.Contains(TsukuriUnique) == true){
                    rb.velocity = new Vector2( 0,0);
                    GameObject.Find("myscore").GetComponent<Text>().text = ( int.Parse(GameObject.Find("myscore").GetComponent<Text>().text) + Power ).ToString();
Debug.Log("kanjiUnique="+ReadKanjiCSV.instance.getBushuAndTsukuriToKanji_Unique(target1.GetComponent<BushuCardView>().BushuUnique,TsukuriUnique));
Debug.Log("TsukuriUnique="+TsukuriUnique);
Debug.Log("BushuUnique="+target1.GetComponent<BushuCardView>().BushuUnique);
                    SetNewKanji(ReadKanjiCSV.instance.getBushuAndTsukuriToKanji_Unique(target1.GetComponent<BushuCardView>().BushuUnique,TsukuriUnique));
                    SetNextTsukuri();
                }else{
                    Instantiate(particle, new Vector2( -1.2f,0.5f), Quaternion.identity);
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

    private void SetNewKanji(string kanjiUnique){
        GameManager.instance.SetNewKanji(kanjiUnique);
    }
        

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }

}