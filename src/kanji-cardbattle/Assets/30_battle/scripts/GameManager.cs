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

    public string TsukuriUnique;
    public string BushuUnique;
 
    void Start()
    {
        StartGame();
    }
 
    void StartGame()
    {
        ReadKanjiCSV.instance.Initialized();

        for(int i = 0; i < 5; i++){
        CardController tsukuriCard = Instantiate(tsukuriCardPrefab, cardField);
        TsukuriUnique = tsukuriCard.TsukuriInit(i);
        tsukuriCard.name = TsukuriUnique;
        }

        CardController bushuCard = Instantiate(bushuCardPrefab, themeField);
        BushuUnique = bushuCard.BushuInit(0);
        bushuCard.name = BushuUnique;

    }

}