using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Stalactite : MonoBehaviour {

	public GameObject prefab_Stalactite;

	void Drop(){
		Destroy (Instantiate (prefab_Stalactite, transform.position, Quaternion.identity), 1.3f);
	}
}
