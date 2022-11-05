using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class loadingAction : MonoBehaviour
{
    public GameObject pettan1Object;
    public GameObject pettan2Object;
    public GameObject pettan3Object;
    //public GameObject loadingObject;


    void Start()
    {
        pettan1Object.SetActive(false);
        pettan2Object.SetActive(false);
        pettan3Object.SetActive(false);
        StartCoroutine("pettan1Appear");
    }
    
    /*今度文字も点滅させよーとbyひなIEnumerator loadingflash(){
        loadingObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        loadingObject.SetActive(false);
    }*/

    IEnumerator pettan1Appear()
    {
        yield return new WaitForSeconds(0.7f);
        pettan1Object.SetActive(true);
        StartCoroutine("pettan2Appear");
    }
 
     IEnumerator pettan2Appear()
    {
        yield return new WaitForSeconds(0.7f);
        pettan2Object.SetActive(true);
        StartCoroutine("pettan3Appear");
    }
     
    IEnumerator pettan3Appear()
     {
        yield return new WaitForSeconds(0.7f);
        pettan3Object.SetActive(true);
     }
     
}
     