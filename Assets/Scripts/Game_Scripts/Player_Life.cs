using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour {

	public Text lifeText;

	private Rigidbody2D r;

	void Start () {
		setLifeText ();
		r = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		FallCheck ();
	}

	void FallCheck(){
		if (transform.position.y < -10) {
			//Die ();
		}
	}

	void Die(){
		if (Player_Var.life != 0) {
			Player_Var.life--;
			setLifeText ();
			GameObject.FindWithTag ("Player").SendMessage ("player_Reset"); // Player Reset
		} else {
			SceneManager.LoadScene ("Scene_Menu");
		}
	}

	void setLifeText(){
		lifeText.text = "Life : " + Player_Var.life;
	}
		
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag.Equals ("Water")) {
			//Water Event
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag.Equals ("Friend")) {
			SaveFriend (col);
		}else if (col.gameObject.tag.Equals ("Monster")) {
			Die ();
		}
    }

	void SaveFriend(Collider2D col){
		Player_Var.life++;
		Player_Var.num_Friend++;
		setLifeText ();
		Destroy (col.gameObject);
	}
}
