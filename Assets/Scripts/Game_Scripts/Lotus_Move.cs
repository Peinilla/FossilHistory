using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lotus_Move : MonoBehaviour
{
    private GameObject player;
	private float velocity;
	private  Vector3 startpos;

    void Start()
    {
		velocity = Random.Range (3f, 6f);
		if (Random.value >= 0.5) {
			velocity *= -1;
		}
		player = GameObject.Find ("Player");
        Vector3 pos = this.gameObject.transform.position;
        startpos = pos;
    }

    void Update()
    {
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
    }

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag.Equals ("Ground")) {
			velocity = -velocity / Mathf.Abs (velocity) * Random.Range (3f, 6f);
			transform.Translate(new Vector2(velocity * Time.deltaTime, 0));
		}
	}

	void OnCollisionStay2D(Collision2D col){
		if (col.gameObject.tag.Equals ("Player")) {
			player.transform.Translate (new Vector2 (velocity * Time.deltaTime, 0));
		}
	}
}