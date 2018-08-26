using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lotus_Disappear : MonoBehaviour
{

	public GameObject prefab_Clone;
	private Vector2 pos;
	private bool isLotten;
    // Use this for initialization
    void Start()
    {
		pos = transform.parent.position;

		isLotten = false;
		transform.localPosition = new Vector2 (0, -0.8f);
    }

    void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" && !isLotten) {
			Invoke ("Lot", 3);
			isLotten = true;
		}
	}

	void Lot(){
		gameObject.SetActive (false);
		Invoke ("Reset", 3);
		Destroy (transform.parent.gameObject ,3f);
	}

	void Reset(){
		gameObject.SetActive (true);
		Instantiate (prefab_Clone, pos, Quaternion.identity);
	}
} 