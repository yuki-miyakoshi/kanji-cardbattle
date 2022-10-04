using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultButton : MonoBehaviour
{
    public void OnClickStartButtonReplay()
    {
        SceneManager.LoadScene("loading");
    }

    public void OnClickStartButtonStart()
    {
        SceneManager.LoadScene("start");
    }
}
