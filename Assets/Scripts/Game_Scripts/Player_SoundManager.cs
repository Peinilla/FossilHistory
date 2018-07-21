using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SoundManager : MonoBehaviour {

	void play_JumpSound(){
		GetComponent <AudioSource> ().Play ();
	}
}
