using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] CardController tsukuriCardPrefab;
    [SerializeField] Transform cardField;
    [SerializeField] CardController bushuCardPrefab;
    [SerializeField] Transform themeField;
    [SerializeField] CardController kanjiCardPrefab;
    [SerializeField] Transform kanjiField;

    public static GameManager instance;
    public string TsukuriUnique;
    public string BushuUnique;
    public int doNextTsukuri;
    public bool doNextBushu,doSetKanji;
    public int countTsukuriID = 0,countBushuID = 0;
    public int KanjiID = 0;
    public string KanjiUnique,KanjiKanji;
    public string timerText;
    public bool moving;

    private bool beingMeasured; // 計測中であることを表す変数
    private float start; // 計測の開始時間を格納する変数
    private float elapsedTime; // 経過時間を格納する変数
    private Rigidbody2D rb = null;



    public void Awake(){
        if(instance == null)
        {
            instance = this;
        }
    }
 
    void Start(){
        StartGame();
    }
 
    void StartGame(){
        CardController bushuCard = Instantiate(bushuCardPrefab, themeField);
        bushuCard.BushuInit(0);
        bushuCard.name = "Bushu";
        countBushuID++;

        for(int i = 0; i < 5; i++){
        CardController tsukuriCard = Instantiate(tsukuriCardPrefab, cardField);
        tsukuriCard.TsukuriInit(i);
        // tsukuriCard.name = tsukuriCard.GetComponent<TsukuriCardView>().TsukuriUnique;
        countTsukuriID++;
        }

        beingMeasured = false;
    }

    void Update(){

        if((doNextBushu == true) && !moving){
            CardController bushuCard = Instantiate(bushuCardPrefab, themeField);
            bushuCard.BushuInit(countBushuID);
            bushuCard.name = "Bushu";
            countBushuID++;
            doNextBushu = false;
        }
        if( int.Parse( GameObject.Find("myscore").GetComponent<Text>().text ) > 9){
            SceneManager.LoadScene("newresultScene");
        }
        if (!beingMeasured){
            beingMeasured = !beingMeasured;
            start = Time.time; // 開始時間を格納
        }else{
            elapsedTime = Time.time - start; // 経過時間を格納
            timerText = elapsedTime.ToString("0");
        }

    }

    public void SetNewKanji(string kanjiUnique){
 
        CardController kanjiCard = Instantiate(kanjiCardPrefab, kanjiField);
        kanjiCard.KanjiInit(kanjiUnique);
        rb = kanjiCard.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2( UnityEngine.Random.Range(-1.5f,1.5f),1.0f);
        rb.gravityScale = 0.1f;
    }

}