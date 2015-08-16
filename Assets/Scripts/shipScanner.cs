using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class shipScanner : MonoBehaviour {
	private GameObject _ship;
	public List<GameObject> _scannedObjects;
	public List<GameObject> _blips;
	

	// Use this for initialization
	void Start () {
		_scannedObjects = new List<GameObject> ();

	}

	void OnTriggerEnter2D(Collider2D other) {
		_scannedObjects.Add (other.gameObject);
	}
	
	void OnTriggerExit2D(Collider2D other) {
		_scannedObjects.Remove (other.gameObject);
	}


	// Update is called once per frame
	void Update () {

	}
}
