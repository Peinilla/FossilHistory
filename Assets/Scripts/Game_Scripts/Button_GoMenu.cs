using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_GoMenu : MonoBehaviour {
	
	public void ButtonClick(){
		Time.timeScale = 1.0f; // init TimeScale
		SceneManager.LoadScene ("Scene_Menu"); // Goto Menu
	}
}
