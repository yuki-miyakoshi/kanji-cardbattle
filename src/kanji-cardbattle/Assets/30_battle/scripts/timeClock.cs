using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class timeClock : MonoBehaviour {

  public Image UIobj;
  public bool doStart;
  public float TsukuricountTime = 3.0f;
  public float BushucountTime = 5.0f;
  public bool isBushu;

  void Update (){
    if (doStart) {

      if(!isBushu)UIobj.fillAmount -= 1.0f / TsukuricountTime * Time.deltaTime;
      if(isBushu)UIobj.fillAmount -= 1.0f / BushucountTime * Time.deltaTime;
      
    }

    if( UIobj.fillAmount == 0){
      // gameObject.SetActive (false);
      if( !isBushu ){
        // GameManager.instance.doNextTsukuri++;
        // if(doNextTsukuri > 0){
            GetComponent<CardController>().TsukuriInit(GameManager.instance.countTsukuriID);
            // CardController tsukuriCard = Instantiate(tsukuriCardPrefab, cardField);
            // tsukuriCard.TsukuriInit(countTsukuriID);
            // GameObject.Find(GetComponent<TsukuriCardView>().TsukuriUnique).name = tsukuriCard.GetComponent<TsukuriCardView>().TsukuriUnique;
            GameManager.instance.countTsukuriID++;
            UIobj.fillAmount = 5.0f;
            // doNextTsukuri--;
        // }
      }
      if( isBushu ){
        // if(GameObject.Find("GameObject").GetComponent<GameManager>().isMoving){
          
          GameManager.instance.doNextBushu = true;
          gameObject.SetActive (false);
        // }
      }
      
    }

  }
}