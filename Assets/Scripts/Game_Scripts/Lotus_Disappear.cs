using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lotus_Disappear : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			Invoke ("Lot", 3);
		}
	}

	void Lot(){
		this.gameObject.SetActive (false);
		Invoke ("Reset", 3);
	}

	void Reset(){
		this.gameObject.SetActive (true);
	}
} 