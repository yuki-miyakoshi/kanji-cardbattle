using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class debug : MonoBehaviour
{
    public void OnClickEndButton()
    {
        SceneManager.LoadScene("ResultsScene");
    }

    public void OnClickReloadButton()
    {
        SceneManager.LoadScene("battle-field");
    }

}
