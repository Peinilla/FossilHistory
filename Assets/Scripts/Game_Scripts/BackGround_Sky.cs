using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Sky : MonoBehaviour {
	
	public GameObject player;

	public GameObject prefab_Cloud1;
	public GameObject prefab_Cloud2;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawnCloud", 0, 10);
	}

	void spawnCloud(){
		Vector2 Pos = new Vector2(player.transform.position.x + 25, player.transform.position.y + Random.Range (5f, 12f));

		if (Random.Range (0, 1f) > 0.5f) {
			Instantiate (prefab_Cloud1, Pos, Quaternion.identity);
		} else {
			Instantiate (prefab_Cloud2, Pos, Quaternion.identity);
		}
	}
}
