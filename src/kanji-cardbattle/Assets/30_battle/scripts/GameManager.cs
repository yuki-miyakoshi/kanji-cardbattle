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

    public string tsukuri_unique;
 
    void Start()
    {
        StartGame();
    }
 
    void StartGame()
    {
        ReadKanjiCSV.instance.Initialized();

        for(int i = 0; i < 5; i++){
        CardController tsukuricard = Instantiate(tsukuriCardPrefab, cardField);
        tsukuri_unique = tsukuricard.tsukuriInit(i);
        tsukuricard.name = tsukuri_unique;
        }

        CardController bushucard = Instantiate(bushuCardPrefab, themeField);
        bushucard.bushuInit(0);

    }

}