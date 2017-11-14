using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public MapGenerator boardScript;
    public static GameManager instance = null;

	// Use this for initialization
	void Awake () {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        boardScript = GetComponent<MapGenerator>();
        InitGame();
	}

    void InitGame() {
        //setup scene with the desired level
        //doingSetup = true;

        //levelImage = GameObject.Find("LevelImage");
        //levelText = GameObject.Find("LevelText").GetComponent<Text>();
        //levelText.text = "Dungeon " + level;
        //levelImage.SetActive(true);
        //Invoke("HideLevelImage",levelStartDelay);
        boardScript.SetupScene();
    }

}
