using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour {

	public GameObject player;

	private Vector3 cameraPosition;
	private Vector3 offset;

	void Start () {
		offset = transform.position;
		cameraPosition = offset;
	}

	/*
	 * Camera Moving Function 
	 * Camera follow Player X vector
	 */
	void LateUpdate(){

		cameraPosition.x = player.transform.position.x + offset.x + 8f;

		transform.position = cameraPosition;
	}
}
