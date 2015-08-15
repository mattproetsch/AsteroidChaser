using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class scannerDisplay : MonoBehaviour {
	private GameObject _ship;
	public List<GameObject> _scannedObjects; 


	// Use this for initialization
	void Start () {
		_ship = GameObject.Find ("Ship");
		_scannedObjects = new List<GameObject> ();
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
		Debug.Log (_scannedObjects.Count);
		foreach (GameObject scanned in _scannedObjects) {
			float distance = Vector3.Distance(scanned.transform.position,_ship.transform.position);
		}


	}
}
