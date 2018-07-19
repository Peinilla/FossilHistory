using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScreen : MonoBehaviour {
	
	void Awake(){
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		Screen.SetResolution (2560, 1440, true); // Set Mobile resolution
	}
}
