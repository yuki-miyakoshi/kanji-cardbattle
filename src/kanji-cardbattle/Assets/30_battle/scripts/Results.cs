using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class Results: MonoBehaviour {
 
    // Use this for initialization
    void Start () {
        Invoke("ChangeScene", 5.0f);
    }
    
    // Update is called once per frame
    void Update () {
        
    }
 
    void ChangeScene()
    {
        SceneManager.LoadScene("ResultsScene");
    }
}