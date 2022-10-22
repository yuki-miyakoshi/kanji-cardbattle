using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultGameManager : MonoBehaviour
{
    // public static ResultGameManager instance;
 
    // public void Awake()
    // {
    //     if(instance == null)
    //     {
    //         instance = this;
    //     }
    // }
 
    void Start()
    {
        GameObject.Find("time").GetComponent<Text>().text = GameManager.instance.timerText;
        GameObject.Find("count").GetComponent<Text>().text = (GameManager.instance.countTsukuriID+1).ToString();
    }


}