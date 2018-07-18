using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col) {
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
