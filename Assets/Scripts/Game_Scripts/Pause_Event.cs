using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pause_Event : MonoBehaviour {
	public Image panel;

    public void ButtonClick()
    {
		if (panel.gameObject.activeSelf) {
			Time.timeScale = 1.0f;
			panel.gameObject.SetActive(false);
		} else {
			Time.timeScale = 0;
			panel.gameObject.SetActive(true);
		}
    }
}
