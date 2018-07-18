using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour {

	public GameObject player;

	private Vector3 cameraPosition;
	private Vector3 offset;

	// Use this for initialization

	void Start () {
		offset = transform.position;
		cameraPosition = offset;
	}

	// Update is called once per frame
	void Update () {

	}
	void LateUpdate(){

		cameraPosition.x = player.transform.position.x + offset.x + 8f;

		transform.position = cameraPosition;
	}
}
