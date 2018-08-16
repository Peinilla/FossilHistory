using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour {

	public Text lifeText;

	private bool dieFlag = false;

	void Start () {
		setLifeText ();
	}

	void Update () {
		FallCheck ();
	}

	void FallCheck(){
		if (transform.position.y < -100) {
			//Die ();
		}
	}

	void Die(){
		if (Player_Var.life != 0) {
			dieFlag = false;
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
		} else if (col.gameObject.tag.Equals ("Monster")) {
			Die ();
		} else if (col.gameObject.tag.Equals ("Water")) {
			if (!dieFlag) {
				Invoke ("Die", 2);
				dieFlag = true;
			}
		}
    }

	void SaveFriend(Collider2D col){
		Player_Var.life++;
		Player_Var.num_Friend++;
		setLifeText ();

		col.gameObject.transform.Find ("Effect_up1").gameObject.SetActive(true);
		col.gameObject.transform.Find ("Effect_Blink").gameObject.SetActive(true);
		col.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		col.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
		col.gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		col.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
		col.gameObject.GetComponent<Animator>().Play ("Frined_Happy");
		Destroy (col.gameObject, 1.5f);
	}
}
