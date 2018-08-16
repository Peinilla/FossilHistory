using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage00_BackGround_Ground : MonoBehaviour {

	public GameObject player;

	public float incl;
	public float constant;

	private Vector3 cameraPosition;

	// Use this for initialization
	void Start () {
		cameraPosition = transform.position;
	}

	void Update(){
		if (player.transform.position.x - 35 > cameraPosition.x) {
			constant += 81.92f;
		} else if (player.transform.position.x + 46.92 < cameraPosition.x) {
			constant -= 81.92f;
		}
	}

	void LateUpdate(){
		cameraPosition.x = incl * player.transform.position.x + constant;
		//cameraPosition.y = player.transform.position.y + offset_Y;

		transform.position = cameraPosition;
	}
}