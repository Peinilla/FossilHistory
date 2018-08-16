using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Sky : MonoBehaviour {

	public GameObject prefab_Cloud1;
	public GameObject prefab_Cloud2;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnCloud", 0, 10);
		Instantiate (prefab_Cloud1, new Vector2 (transform.position.x + Random.Range(-10f,10f), transform.position.y + Random.Range(2f,11f)), Quaternion.identity).transform.parent = GameObject.Find("Main Camera").GetComponent<Transform>();
		Instantiate (prefab_Cloud2, new Vector2 (transform.position.x + Random.Range(-10f,10f), transform.position.y + Random.Range(2f,11f)), Quaternion.identity).transform.parent = GameObject.Find("Main Camera").GetComponent<Transform>();
	}

	void spawnCloud(){
		if (Random.Range (0, 1f) > 0.5f) {
			Instantiate (prefab_Cloud1, new Vector2 (transform.position.x + 25, transform.position.y + Random.Range(2f,11f)), Quaternion.identity).transform.parent = GameObject.Find("Main Camera").GetComponent<Transform>();
		} else {
			Instantiate (prefab_Cloud2, new Vector2 (transform.position.x + 25, transform.position.y + Random.Range(2f,11f)), Quaternion.identity).transform.parent = GameObject.Find("Main Camera").GetComponent<Transform>();
		}
	}
}
