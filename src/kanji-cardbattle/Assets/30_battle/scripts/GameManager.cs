using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public int KanjiID = 0,KanjiPower = 0;
    public string KanjiUnique,KanjiKanji;

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
        ReadKanjiCSV.instance.Initialized();

        for(int i = 0; i < 5; i++){
        CardController tsukuriCard = Instantiate(tsukuriCardPrefab, cardField);
        tsukuriCard.TsukuriInit(i);
        tsukuriCard.name = tsukuriCard.GetComponent<TsukuriCardView>().TsukuriUnique;
        countTsukuriID++;
        }

        CardController bushuCard = Instantiate(bushuCardPrefab, themeField);
        bushuCard.BushuInit(0);
        bushuCard.name = "Bushu";
        countBushuID++;

    }

    void Update(){
        if(doNextTsukuri > 0){
            CardController tsukuriCard = Instantiate(tsukuriCardPrefab, cardField);
            tsukuriCard.TsukuriInit(countTsukuriID);
            tsukuriCard.name = tsukuriCard.GetComponent<TsukuriCardView>().TsukuriUnique;
            countTsukuriID++;
            doNextTsukuri--;
        }

        if(doNextBushu == true){
            CardController bushuCard = Instantiate(bushuCardPrefab, themeField);
            bushuCard.BushuInit(countBushuID);
            bushuCard.name = "Bushu";
            countBushuID++;
            doNextBushu = false;
        }

        if(doSetKanji == true){
            CardController kanjiCard = Instantiate(kanjiCardPrefab, kanjiField);
            kanjiCard.KanjiInit(KanjiID,KanjiPower,KanjiUnique,KanjiKanji);
            kanjiCard.name = "Kanji";
            KanjiID++;
            doSetKanji = false;
        }
    }

}