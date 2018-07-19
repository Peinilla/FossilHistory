using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Start : MonoBehaviour {
	public void ButtonClick(){
		SceneManager.LoadScene ("Scene_00"); // Scene_00 Load, Scene_00 is Tutorial Map
		Player_Var.life = 3; // init Player Life
	}
}
