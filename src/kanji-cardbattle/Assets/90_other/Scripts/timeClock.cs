using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class timeClock : MonoBehaviour {
  public Image UIobj;
  public bool isStart;
  public float countTime = 5.0f;
  // Update is called once per frame
  void Update (){
    if (isStart) {
      UIobj.fillAmount -= 1.0f / countTime * Time.deltaTime;
    }
  }
}