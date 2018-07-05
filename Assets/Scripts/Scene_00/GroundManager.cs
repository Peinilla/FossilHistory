﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GroundManager : MonoBehaviour {

	public GameObject prefab_Ground;
	public GameObject prefab_Dirt;
	public GameObject prefab_Wall;
	public GameObject prefab_Friend;


	public GameObject Player;

	public const float tileSize = 2.56f;

	private int mapLine;

	// Use this for initialization
	void Start () {
		mapSpawn ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void mapSpawn()
	{
		TextAsset data = Resources.Load("Tutorial", typeof(TextAsset)) as TextAsset;
		StringReader sr = new StringReader(data.text);

		mapLine = 0;
		// 먼저 한줄을 읽는다. 

		string oneLine = sr.ReadLine();
		while (oneLine != null) {

			string[] mapData = oneLine.Split ('\t');

			for (int idx = 0; idx < mapData.Length; idx++) {
				switch (mapData [idx]) {
				case "0":
					Instantiate (prefab_Dirt, new Vector2 (mapLine * tileSize - 28.24f, 12.92f - (idx * tileSize)), Quaternion.identity);
					break;
				case "1":
					Instantiate (prefab_Ground, new Vector2 (mapLine * tileSize - 28.24f, 12.92f - (idx * tileSize)), Quaternion.identity);
					break;
				case "6":
					Instantiate (prefab_Friend, new Vector2 (mapLine * tileSize - 28.24f, 12.92f - (idx * tileSize)), Quaternion.identity);
					break;
				case "7":
					Player.transform.position = new Vector2 (mapLine * tileSize - 28.24f, 12.92f - (idx * tileSize));
					Player_Life pl = GameObject.Find ("Player").GetComponent<Player_Life> ();
					pl.defaultPos = Player.transform.position;
					break;
				case "8":
					break;
				case "9":
					Instantiate (prefab_Wall, new Vector2 (mapLine * tileSize - 28.24f, 12.92f - (idx * tileSize)), Quaternion.identity);
					break;
				}
			}
			mapLine++;
			oneLine = sr.ReadLine();
		}
	}

	void defaultMapSpawn () {
		for (int idx = -15; idx < 20; idx++) {
			Instantiate (prefab_Ground, new Vector2 ((float)(idx * 2.56) - 18, -5f), Quaternion.identity);
			Instantiate (prefab_Dirt, new Vector2 ((float)(idx * 2.56) - 18, -7.56f), Quaternion.identity);
			Instantiate (prefab_Dirt, new Vector2 ((float)(idx * 2.56) - 18, -10.12f), Quaternion.identity);

		}

		Instantiate (prefab_Ground, new Vector2 ((float)(10 * 2.56) - 18, -5 + 2.56f), Quaternion.identity);
	}


}