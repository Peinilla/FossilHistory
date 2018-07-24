using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour {

	public GameObject player;
	public float offset_Y = 3f;

	private Vector3 cameraPosition;

	void Start () {
	}

	/*
	 * Camera Moving Function 
	 * Camera follow Player X vector
	 */
	void LateUpdate(){

		cameraPosition.x = player.transform.position.x + 8f;
		//cameraPosition.y = player.transform.position.y + offset_Y;

		transform.position = cameraPosition;
	}

	void setCameraPosition(){
		cameraPosition.x = player.transform.position.x + 8f;
		cameraPosition.y = player.transform.position.y + offset_Y;
		cameraPosition.z = -10f;

		transform.position = cameraPosition;
	}
}