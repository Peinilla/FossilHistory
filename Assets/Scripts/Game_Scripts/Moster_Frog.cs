using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moster_Frog : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		InvokeRepeating ("grab", 3, 3);
	}

	void grab(){
		anim.Play ("Frog_Grab");
	}
}
