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
    
 
    void Start()
    {
        StartGame();
    }
 
    void StartGame()
    {
        ReadCSV.instance.Initialized();

        for(int i = 0; i < 5; i++){
        CardController tsukuricard = Instantiate(tsukuriCardPrefab, cardField);
        tsukuricard.tsukuriInit(i);
        }

        CardController bushucard = Instantiate(bushuCardPrefab, themeField);
        bushucard.bushuInit(0);

    }

}