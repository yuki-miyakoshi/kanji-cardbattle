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
    // [SerializeField] CardController kanjiCardPrefab;
    // [SerializeField] Transform kanjiField;

    public static GameManager instance;

    public string TsukuriUnique;
    public string BushuUnique;
    public int doNextTsukuri;
    public bool doNextBushu,doSetKanji;
    public int countTsukuriID = 0,countBushuID = 0;

    public int KanjiID = 0,KanjiPower = 0;
    public string KanjiUnique,KanjiKanji;

    private bool beingMeasured; // 計測中であることを表す変数
    public string timerText;
    private float start; // 計測の開始時間を格納する変数
    private float elapsedTime; // 経過時間を格納する変数
 
    // public bool isMoving = false;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
 
    void Start()
    {
        StartGame();
    }
 
    void StartGame()
    {
        CardController bushuCard = Instantiate(bushuCardPrefab, themeField);
        bushuCard.BushuInit(0);
        bushuCard.name = "Bushu";
        countBushuID++;

        for(int i = 0; i < 5; i++){
        CardController tsukuriCard = Instantiate(tsukuriCardPrefab, cardField);
        tsukuriCard.TsukuriInit(i);
        tsukuriCard.name = tsukuriCard.GetComponent<TsukuriCardView>().TsukuriUnique;
        countTsukuriID++;
        }
    }

    void Update(){
        // if(doNextTsukuri > 0){
        //     // CardController tsukuriCard = Instantiate(tsukuriCardPrefab, cardField);
        //     // tsukuriCard.TsukuriInit(countTsukuriID);
        //     GameObject.Find("Bushu").name = tsukuriCard.GetComponent<TsukuriCardView>().TsukuriUnique;
        //     countTsukuriID++;
        //     doNextTsukuri--;
        // }

        if(doNextBushu == true){
            CardController bushuCard = Instantiate(bushuCardPrefab, themeField);
            bushuCard.BushuInit(countBushuID);
            bushuCard.name = "Bushu";
            countBushuID++;
            doNextBushu = false;
        }

        if( int.Parse( GameObject.Find("myscore").GetComponent<Text>().text ) > 9){
            SceneManager.LoadScene("ResultsScene");
        }

        // if(doSetKanji == true){
        //     CardController kanjiCard = Instantiate(kanjiCardPrefab, kanjiField);
        //     kanjiCard.KanjiInit(KanjiID,KanjiPower,KanjiUnique,KanjiKanji);
        //     kanjiCard.name = "Kanji";
        //     KanjiID++;
        //     doSetKanji = false;
        // }

        if (beingMeasured){
            beingMeasured = !beingMeasured;
            start = Time.time; // 開始時間を格納
        }else{
            elapsedTime = Time.time - start; // 経過時間を格納
            timerText = elapsedTime.ToString("0");
        }
    }

}