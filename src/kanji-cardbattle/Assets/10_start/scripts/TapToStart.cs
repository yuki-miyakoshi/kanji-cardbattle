using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapToStart : MonoBehaviour
{
    
   public void OnClickTapToStart()
    {
        SceneManager.LoadScene("loading");
    }
}
