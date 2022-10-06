using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class debug_end : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("ResultsScene");
    }
}
