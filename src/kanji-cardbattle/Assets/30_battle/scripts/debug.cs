using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class debug : MonoBehaviour
{
    public void OnClickEndButton()
    {
        SceneManager.LoadScene("newresultScene");
    }

    public void OnClickReloadButton()
    {
        SceneManager.LoadScene("battle");
    }

}
