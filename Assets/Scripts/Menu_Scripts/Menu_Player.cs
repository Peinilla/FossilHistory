using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Player : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		InvokeRepeating ("jump",2,2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void jump() {
		anim.Play ("Player_Jump");
	}
}
