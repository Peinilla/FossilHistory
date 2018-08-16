using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Environment : MonoBehaviour {

	void Start () {
		if (Random.Range (0, 1f) > 0.3) {
			int inx = Random.Range (6, 16);
			transform.Find ("Asset " + inx).gameObject.SetActive (true);
		}
	}
}
