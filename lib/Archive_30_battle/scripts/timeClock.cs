using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timeClock : MonoBehaviour {

  public Image UIobj;
  public bool doStart;
  public float countTime = 5.0f;
  public bool isBushu;

  void Update (){
    if (doStart) {
      UIobj.fillAmount -= 1.0f / countTime * Time.deltaTime;
    }

    if( UIobj.fillAmount == 0){
      gameObject.SetActive (false);
      if( !isBushu ){
        GameManager.instance.doNextTsukuri++;
      }
      if( isBushu ){
        GameManager.instance.doNextBushu = true;
        GameObject.Find("Kanji").SetActive (false);
      }
      
    }

  }
}