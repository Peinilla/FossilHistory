using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lotus_Move : MonoBehaviour
{
	private float velocity;
	private Rigidbody2D r;

    void Start()
    {
		velocity = 2.5f;
		if (Random.value >= 0.5) {
			velocity *= -1;
		}
        Vector3 pos = this.gameObject.transform.position;
		r = GetComponent<Rigidbody2D> ();

		r.velocity = new Vector2 (velocity, 0);
    }

    void Update()
    {
		/*
        float movement = velocity * Time.deltaTime;
        Vector3 nowpos = this.gameObject.transform.position;
        float tr = nowpos.x - startpos.x;

		transform.Translate(new Vector2(movement, 0));

        if (tr >= 5.12f && velocity >= 0.00f)
        {
			velocity = -velocity / Mathf.Abs (velocity) * Random.Range (3f, 6f);
        }
        else if (tr <= -5.12f && velocity <= 0.00f)
        {
			velocity = -velocity / Mathf.Abs (velocity) * Random.Range (3f, 6f);
        }
        */
    }
		
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag.Equals ("Player")) {
			BoxCollider2D[] c = GetComponents<BoxCollider2D> ();
			c [1].offset = new Vector2 (0, 0.1f);
		}
	}
	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag.Equals ("Player")) {
			BoxCollider2D[] c = GetComponents<BoxCollider2D> ();
			c [1].offset = new Vector2 (0, 0);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag.Equals ("Player")) {
			col.gameObject.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
			col.gameObject.GetComponent<Rigidbody2D> ().velocity = r.velocity;
		}
	}
}