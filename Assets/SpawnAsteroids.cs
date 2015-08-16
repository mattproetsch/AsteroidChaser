using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnAsteroids : MonoBehaviour {

	public GameObject Asteroid1;
	public GameObject Asteroid2;
	public GameObject Asteroid3;
	public GameObject Asteroid4;
	public GameObject Asteroid5;



	public Vector2 Spacing;
	public Vector2 RowsCols;

	public int NumRocksPerSpace;

	// Use this for initialization
	void Start () {
		GameObject[] asteroids = {
			Asteroid1,
			Asteroid2,
			Asteroid3,
			Asteroid4,
			Asteroid5
		};

		int minRow = (int)(RowsCols.x % 2 == 0 ? -(RowsCols.x / 2 + 1) : -RowsCols.x / 2);
		int maxRow = (int)(RowsCols.x / 2);
		int minCol = (int)(RowsCols.y % 2 == 0 ? -(RowsCols.y / 2 + 1) : -RowsCols.y / 2);
		int maxCol = (int)(RowsCols.y / 2);

		for (int i = minRow; i <= maxRow; i++) {
			for (int j = minCol; j <= maxCol; j++) {
				for (int astNum = 0; astNum < NumRocksPerSpace; astNum++)
				{
					int idx = Random.Range (0, 4);

					float xBase = j * Spacing.y;
					float yBase = i * Spacing.x;
					GameObject asteroid = GameObject.Instantiate(asteroids[idx]) as GameObject;
					asteroid.transform.position = new Vector3(xBase + Random.Range(0f, Spacing.x), yBase + Random.Range (0f, Spacing.y));
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
