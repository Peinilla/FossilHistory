using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Event : MonoBehaviour {
    private bool pauseOn = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ButtonClick()
    {
        if (!pauseOn)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
        pauseOn = !pauseOn;
    }
}
