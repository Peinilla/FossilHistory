using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Start : MonoBehaviour {
	public void btn_Start(){
		SceneManager.LoadScene ("Scene_00"); // Scene_00 Load, Scene_00 is Tutorial Map
		Player_Var.num_Friend = 0;
		Player_Var.timeCount = 0;
	}
	public void btn_End(){		
		Application.Quit();
	}
}
