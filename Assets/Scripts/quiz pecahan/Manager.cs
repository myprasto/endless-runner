using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    public LevelData[] allLevelData;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);

        //SceneManager.LoadScene("MenuSc")
	}
	
    public LevelData GetCurrentLevelData()
    {
        return allLevelData[0];
    }

	// Update is called once per frame
	void Update () {
		
	}
}
