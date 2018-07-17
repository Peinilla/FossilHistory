using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lotus_Move : MonoBehaviour
{
    GameObject player;
    public Vector3 startpos;
    public float velocity = 2.56f;
    // Use this for initialization
    void Start()
    {
        Vector3 pos = this.gameObject.transform.position;
        startpos = pos;
    }
    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        float movement = velocity * Time.deltaTime;
        Vector3 nowpos = this.gameObject.transform.position;
        float tr = nowpos.x - startpos.x;
        transform.Translate(new Vector3(movement, 0, 0));
        if (tr >= 5.12f && velocity >= 0.00f)
        {
            velocity = -velocity;
        }
        else if (tr <= -5.12f && velocity <= 0.00f)
        {
            velocity = -velocity;
        }

    }
}
