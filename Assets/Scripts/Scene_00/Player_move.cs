using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_move : MonoBehaviour {

	private Rigidbody2D r;
	private bool isJump;
	private Touch tempTouch;
	private Vector3 touchPos;

	public const int MAX_SPEED = 12;
	public const int JUMP_POWER = 750;
	public const int HORIZONTAL_POWER = 50;
	public const int HORIZONTAL_BEGIN = 3;

	public const bool RIGHT = true;
	public const bool LEFT = false;



	// Use this for initialization
	void Start () {
		r = GetComponent<Rigidbody2D> ();
		isJump = false;
	}

	// Update is called once per frame
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
				if (!EventSystem.current.IsPointerOverGameObject()){
					tempTouch = Input.GetTouch(idx);
					touchPos = Camera.main.ScreenToWorldPoint(tempTouch.position);

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
		}
		// Mobile Test END

		if (Input.GetMouseButtonDown (0)) {
			if (EventSystem.current.IsPointerOverGameObject () == false) {
				move_Up (RIGHT);
			}
		}
	}

	void move_Up(bool isRight){
		if (!isJump) {
			isJump = true;
			r.AddForce(Vector2.up * JUMP_POWER);

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

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag.Equals ("Ground")) {
			isJump = false;
			r.velocity = new Vector2 (0, r.velocity.y);
		}
	}

	void OnCollisionExit2D(Collision2D col){
		
	}


}
