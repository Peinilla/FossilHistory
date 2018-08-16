using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

	void Awake(){
		DontDestroyOnLoad (gameObject);
		SceneManager.LoadScene ("Scene_Menu");
	}
}
