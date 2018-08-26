using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Endding_TimeScore : MonoBehaviour {

	void Start () {
		int min = (int)Player_Var.timeCount / 60;
		float sec = Player_Var.timeCount % 60;
		GetComponent<Text> ().text = "Play Time\n" + string.Format ("{0:d2}m {1:d2}s", min, (int)sec);
	}

}
