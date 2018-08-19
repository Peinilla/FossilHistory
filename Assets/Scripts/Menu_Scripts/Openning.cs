using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Openning : MonoBehaviour {

	void Awake(){
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Screen.SetResolution (2560, 1440, true); // Set Mobile resolution
	}

	void Start () {
		Invoke ("wow", 10.5f);
		Invoke ("GameStart", 18);
	}

	void wow(){
		//Destroy (GameObject.FindGameObjectWithTag("Player").gameObject);
		GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().enabled = false;
		for (int inx = 0; inx < transform.childCount; inx++) {
			transform.GetChild (inx).gameObject.SetActive (true);
		}
	}

	void GameStart(){
		SceneManager.LoadScene ("Scene_Sound");
	}
}
