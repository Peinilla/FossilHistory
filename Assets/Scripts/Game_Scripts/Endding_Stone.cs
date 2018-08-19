using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endding_Stone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("End", 7);
	}

	void End (){
		GetComponent<SpriteRenderer> ().enabled = true;
	}
}
