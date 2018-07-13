using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour {

	public Text lifeText;
	public  Vector2 defaultPos;

	private int life;
	private Rigidbody2D r;

	// Use this for initialization
	void Start () {
		life = 3;
		setLifeText ();
		r = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		FallCheck ();
	}

	void FallCheck(){
		if (transform.position.y < -100) {
			Die ();
		}
	}

	void ReSet(){
		r.velocity = Vector2.zero;
		transform.position = defaultPos;
	}

	void Die(){
		if (life != 0) {
			life--;
			setLifeText ();
			ReSet ();
		} else {
			SceneManager.LoadScene ("Scene_Menu");
		}
	}

	void setLifeText(){
		lifeText.text = "Life : " + life;
	}
		
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag.Equals ("Water")) {
			//Water Event
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag.Equals ("Friend")) {
			life++;
			setLifeText ();
			Destroy (col.gameObject);
		}
        if (col.gameObject.tag.Equals("Portal")) {
            SceneManager.LoadScene("Scene_01");
        }
    }
}
