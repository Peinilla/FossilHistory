using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GroundManager : MonoBehaviour {

	public GameObject prefab_Ground;
	public GameObject prefab_Dirt;
	public GameObject prefab_Water;
	public GameObject prefab_WaterDeep;
	public GameObject prefab_Lotus;
	public GameObject prefab_Wall;
	public GameObject prefab_Friend;
    public GameObject prefab_Portal;
	public GameObject prefab_InnerDirt;
	public GameObject prefab_InnerGround;
	public GameObject prefab_Mushroom;

	public GameObject Player;


	public string stageData;
	public int stageNum;

	private const float tileSize = 2.56f;
	private int mapLine = 0;

	void Start () {
		mapSpawn ();
	}

	public void mapSpawn()
	{
		TextAsset data = Resources.Load(stageData, typeof(TextAsset)) as TextAsset; // Read Mapdata
		StringReader sr = new StringReader(data.text);

		mapLine = 0;

		string oneLine = sr.ReadLine(); // Read oneLine
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
				case "2":
					Instantiate (prefab_WaterDeep, new Vector2 (mapLine * tileSize - 28.24f, 12.92f - (idx * tileSize)), Quaternion.identity);
					break;
				case "3":
					Instantiate (prefab_Water, new Vector2 (mapLine * tileSize - 28.24f, 12.92f - (idx * tileSize)), Quaternion.identity);
					break;
				case "4":
					Instantiate (prefab_Lotus, new Vector2 (mapLine * tileSize - 28.24f, 12.92f - (idx * tileSize)), Quaternion.identity);
					break;
				case "6":
					Instantiate (prefab_Friend, new Vector2 (mapLine * tileSize - 28.24f, 12.92f - (idx * tileSize)), Quaternion.identity);
					break;
				case "7":
					Player.transform.position = new Vector2 (mapLine * tileSize - 28.24f, 12.92f - (idx * tileSize));
					Player_move pl = GameObject.Find ("Player").GetComponent<Player_move> ();
					pl.defaultPos = Player.transform.position;
					break;
				case "8":
                        Instantiate(prefab_Portal, new Vector2(mapLine * tileSize - 28.24f, 12.92f - (idx * tileSize)), Quaternion.identity);
                        break;
				case "9":
					Instantiate (prefab_Wall, new Vector2 (mapLine * tileSize - 28.24f, 12.92f - (idx * tileSize)), Quaternion.identity);
					break;
				case "10":
					Instantiate (prefab_InnerDirt, new Vector2 (mapLine * tileSize - 28.24f, 12.92f - (idx * tileSize)), Quaternion.identity);
					break;
				case "11":
					Instantiate (prefab_InnerGround, new Vector2 (mapLine * tileSize - 28.24f, 12.92f - (idx * tileSize)), Quaternion.identity);
					break;
				case "12":
					Instantiate (prefab_Mushroom, new Vector2 (mapLine * tileSize - 28.24f, 12.92f - (idx * tileSize)), Quaternion.identity);
					break;

				}
			}
			mapLine++;
			oneLine = sr.ReadLine();
		}
	}
}
