using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage00_BackGround_Sky : MonoBehaviour {

	public GameObject player;
	public float offset_Y = 3f;

	private Vector3 cameraPosition;

	// Use this for initialization
	void Start () {
		cameraPosition = transform.position;
	}

	void LateUpdate(){

		cameraPosition.x = player.transform.position.x + 8f;
		//cameraPosition.y = player.transform.position.y + offset_Y;

		transform.position = cameraPosition;
	}

	void setCameraPosition(){
		cameraPosition.x = player.transform.position.x;
		cameraPosition.y = player.transform.position.y + offset_Y;
		cameraPosition.z = 10f;

		transform.position = cameraPosition;
	}
}
