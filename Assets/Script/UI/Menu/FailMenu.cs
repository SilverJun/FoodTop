using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailMenu : UI {
    
	void Start () {
        Vars["TopScore"].GetComponent<Text>().text = PlayerPrefs.GetInt("TopScore", 0).ToString() + " m";
		Vars["Score"].GetComponent<Text>().text = PlayerPrefs.GetInt("Score", 0).ToString() + " m";

		Vars["Back"].GetComponent<Button>().onClick.AddListener(()=>{
			Close();
			UIManager.OpenUI<MainMenu>(Resources.Load<GameObject>("Prefab/MainMenu"));
		});
	}
}
