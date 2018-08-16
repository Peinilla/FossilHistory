using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move_Stage3 : MonoBehaviour {

	public GameObject player;

	private Vector3 cameraPosition;
	private Vector3 offset;

	void Start () {
	}

/*
	 * Camera Moving Function 
	 * Camera follow Player X vector
	 */
void LateUpdate(){

	cameraPosition.x = player.transform.position.x + 8f;

	transform.position = cameraPosition;
	}

void setCameraPosition(){
	cameraPosition.x = player.transform.position.x + 8f;
	cameraPosition.y = player.transform.position.y + 5f;

	transform.position = cameraPosition;
	}
}
