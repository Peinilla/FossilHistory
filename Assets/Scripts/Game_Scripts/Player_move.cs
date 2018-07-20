using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_move : MonoBehaviour {

	public Vector2 defaultPos;

	private Rigidbody2D r;
	private bool isJump;
	private bool isWater;
	private Touch tempTouch;
	private Animator ani;

	private const int MAX_SPEED = 12;
	private const int JUMP_POWER = 750;
	private const int HORIZONTAL_POWER = 50;
	private const int HORIZONTAL_BEGIN = 3;

	private const bool RIGHT = true;
	private const bool LEFT = false;

	void Start () {
		r = GetComponent<Rigidbody2D> ();
		ani = GetComponent<Animator> ();

		player_Reset ();
	}

	void Update () {

		if (Mathf.Abs(r.velocity.x) > MAX_SPEED) {
			float f = MAX_SPEED;
			if (r.velocity.x < 0) {
				f = -f;
			}
			r.velocity = 
				new Vector2 (f, r.velocity.y);
		}
	
		// KeyBorad test
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			move_Up (RIGHT);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			move_Right ();
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			move_Up (LEFT);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			move_Left ();
		}
		// KeyBoard test END

		// Mobile Test
		if (Input.touchCount > 0) {
			for (int idx = 0; idx < Input.touchCount; idx++) {

				if (EventSystem.current.IsPointerOverGameObject(idx)) { return; } // Check UI

				tempTouch = Input.GetTouch (idx);

				switch (tempTouch.phase) {
				case TouchPhase.Began:
					move_Up (tempTouch.position.x > 1280);
					break;
				case TouchPhase.Moved:
					if (tempTouch.position.x > 1280) {
						move_Right ();
					} else {
						move_Left ();
					}
					break;
				case TouchPhase.Stationary:
					if (tempTouch.position.x > 1280) {
						move_Right ();
					} else {
						move_Left ();
					}
					break;
				case TouchPhase.Ended:
					break;
				}
			}
		}
		// Mobile Test END
	}

	void move_Up(bool isRight){
		if (!isJump) {
			isJump = true;
			r.AddForce(Vector2.up * JUMP_POWER);
			ani.Play ("Player_Jump", -1, 0);
			if (isRight) {
				r.velocity = Vector2.right * HORIZONTAL_BEGIN;
			} else {
				r.velocity = Vector2.left * HORIZONTAL_BEGIN;
			}
		}
	}

	void move_Right(){
		if (isJump) {
			r.AddForce (Vector2.right * HORIZONTAL_POWER);
		}
	}

	void move_Left(){
		if (isJump) {
			r.AddForce (Vector2.left * HORIZONTAL_POWER);
		}
	}

	void player_Reset(){
		r.velocity = Vector2.zero;
		r.gravityScale = 10f;
		r.mass = 0.5f;
		transform.position = defaultPos;

		isJump = false;
		isWater = false;

		ani.SetBool ("Jump", false);
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag.Equals ("Ground")) {
			r.velocity = new Vector2 (0, r.velocity.y);
		} 
	}

	void OnCollisionExit2D(Collision2D col){
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag.Equals("Ground")){
			isJump = false;
		}
		else if (col.gameObject.tag.Equals("Jump_Mushroom")){
			isJump = true;
			r.velocity = Vector2.zero;
			r.velocity = Vector2.up * 45;
		}else if (col.gameObject.tag.Equals ("Water")) {
			if (!isWater) {
				r.velocity = Vector2.down;
				r.mass = 100;
				r.gravityScale = 0.2f;
				isWater = true;
			}
		}
	}
}
