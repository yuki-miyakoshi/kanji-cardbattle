using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class load: MonoBehaviour {
 
    // Use this for initialization
    void Start () {

        ReadKanjiCSV.instance.Initialized();
        ChangeScene();
    }
    
    // Update is called once per frame
    void Update () {
        
    }
 
    void ChangeScene()
    {
        SceneManager.LoadScene("battle");
    }
}