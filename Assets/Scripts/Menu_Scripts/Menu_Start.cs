using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Start : MonoBehaviour {
	public void btn_Start(){
		SceneManager.LoadScene ("Scene_00"); // Scene_00 Load, Scene_00 is Tutorial Map
	}
	public void btn_End(){		
		Application.Quit();
	}
}
