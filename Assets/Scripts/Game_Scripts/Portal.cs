using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag.Equals ("Player")) {
			Invoke ("nextStage", 1);
		}
    }

	void OnTriggerExit2D(Collider2D col) {
		//CancelInvoke ();
	}

	void nextStage(){
		GroundManager g = GameObject.Find ("GroundManager").GetComponent<GroundManager>();
		switch (g.stageNum) {
		case 0:
			SceneManager.LoadScene ("Scene_01");
			break;
		case 1:
			SceneManager.LoadScene ("Scene_02");
			break;
		case 2:
			break;
		}
	}
}
