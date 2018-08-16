using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Pass : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag.Equals ("Player")) {
			Rigidbody2D r = col.gameObject.GetComponent<Rigidbody2D> ();
			if (r.velocity.y > 0) {
				GetComponent<BoxCollider2D> ().isTrigger = true;
			} else if (r.velocity.y < 0) {
				GetComponent<BoxCollider2D> ().isTrigger = false;
			}
		}
	}
	void OnTriggerExit2D(Collider2D col){
	}

	void OnCollisionExit2D(Collision2D col){
	}

}
