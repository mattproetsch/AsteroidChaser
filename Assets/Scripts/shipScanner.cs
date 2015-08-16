using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class shipScanner : MonoBehaviour {
	private GameObject _ship;
	public List<GameObject> _scannedObjects;
	private List<GameObject> _blips;

	public GameObject BlipPrefab;

	// Use this for initialization
	void Start () {
		_ship = GameObject.Find ("Ship");
		_scannedObjects = new List<GameObject> ();

		//Creates pool of blips for rendering
		for (int i=0; i<=15; i++) {
			Debug.Log(i);
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		_scannedObjects.Add (other.gameObject);
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		_scannedObjects.Remove (other.gameObject);
	}


	// Update is called once per frame
	void Update () {
		foreach (GameObject scanned in _scannedObjects) {
			float dist = Vector3.Distance(scanned.transform.position,_ship.transform.position);
			dist /= 200;

		}


	}
}
