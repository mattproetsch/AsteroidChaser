using UnityEngine;
using System.Collections;

public class ShipScanner : MonoBehaviour {

	public enum BodyType {
		Earth,
		Asteroid,
		Planet
	}

	//private Minimap _Minimap;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter () {
		// Start tracking object
		// here I call _minimap.DisplayBlip(GameObject, BodyType);
	}

	void OnTriggerStay() {
		// Keep tracking object
		// here I call _minimap.DisplayBlip(GameObject, BodyType) again
	}

	void OnTriggerExit() {
		// Stop tracking object
		// here I call absolutely nothing
	}
}
