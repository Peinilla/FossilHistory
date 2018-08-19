using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Life : MonoBehaviour {

	public GameObject prefab_Die;

	private bool dieFlag = false;
	private Animator ani;
	private Rigidbody2D r;

	void Start () {
		ani = GetComponent<Animator> ();
		r = GetComponent<Rigidbody2D> ();

		GameObject.Find ("Text_Friend_Num").GetComponent<Text> ().text = "X " + Player_Var.num_Friend;
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
		ani.Play ("Player_Die");
		gameObject.SetActive (false);
		Destroy(Instantiate (prefab_Die, transform.position, Quaternion.identity),1);
		Invoke ("Reset", 1);
	}

	void Reset(){

		gameObject.SetActive (true);

		dieFlag = false;
		GameObject.FindWithTag ("Player").SendMessage ("player_Reset"); // Player Reset

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
		}else if (col.gameObject.tag.Equals ("Trap")) {
			Die ();
		}  else if (col.gameObject.tag.Equals ("Water")) {
			if (!dieFlag) {
				Invoke ("Die", 0.5f);
				dieFlag = true;
			}
		}
    }

	void SaveFriend(Collider2D col){
		Player_Var.num_Friend++;
		GameObject.Find ("Text_Friend_Num").GetComponent<Text> ().text = "X " + Player_Var.num_Friend;

		col.gameObject.transform.Find ("Effect_up1").gameObject.SetActive(true);
		col.gameObject.transform.Find ("Effect_Blink").gameObject.SetActive(true);
		col.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		col.gameObject.GetComponent<CapsuleCollider2D> ().enabled = false;
		col.gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		col.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
		col.gameObject.GetComponent<Animator>().Play ("Frined_Happy");
		Destroy (col.gameObject, 1.5f);
	}
}
