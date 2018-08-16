using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Cloud : MonoBehaviour {

	private float speed;

	// Use this for initialization
	void Start () {
		speed = Random.Range (1f, 2f);

	}
	
	// Update is called once per frame
	void Update () {
		float movement = -speed * Time.deltaTime;
		Vector3 nowpos = this.gameObject.transform.position;

		transform.Translate(new Vector2(movement, 0));
	}

	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag.Equals ("Sky")) {
			Destroy (this.gameObject);
		}
	}
}
