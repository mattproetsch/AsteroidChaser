using UnityEngine;
using System.Collections;

public class hudScanner : MonoBehaviour {
	private GameObject _ship;
	private shipScanner _scanner;
	public GameObject BlipPrefab;
	private GameObject _guiCanvas;
	private GameObject _earth;
	
	// Use this for initialization
	void Start () {

		_ship = GameObject.Find ("Ship");
		_scanner = _ship.GetComponent<shipScanner> ();
		_guiCanvas = GameObject.Find ("Canvas");
		_earth = GameObject.Find ("Earth");

		//Creates pool of blips for rendering
		for (int i=0; i<15; i++) {
			_scanner._blips.Add( (GameObject.Instantiate(BlipPrefab)) as GameObject );
			_scanner._blips[i].transform.parent = _guiCanvas.transform;
		}

		// _scanner._blips[14] = Earth icon
	}
	
	//Renders GameObject to display with blip at index i
	void renderBlip(GameObject body, int i) {
		GameObject blip = _scanner._blips[i];  
		Vector3 dist = body.transform.position - _ship.transform.position;
		dist*=2.8f;
		RectTransform rTransform = blip.GetComponent<RectTransform>();
		dist = Vector3.ClampMagnitude(dist,80);
		Vector3 pos = new Vector3(100,100,0) + dist;
		rTransform.position = pos;
	}
	
	//Shitty code alert
	void Update () {
		//Reset all blip positions
		for(int i=0; i<15; i++) {
			GameObject b = _scanner._blips[i];
			RectTransform rt = b.GetComponent<RectTransform>();
			rt.position = new Vector3(-20,0,0);
		}
		//Iterate nearby objects
		for(int i=0;i<_scanner._scannedObjects.Count;i++) {
			GameObject body = _scanner._scannedObjects[i];

			//TODO
			//FINDME
			//FIXME
			// I think this should be "continue;" not "break;"
			if (body.name == "Earth"){break;}
			renderBlip(body,i);
		}
		//Always render earth
		renderBlip (_earth, 14);
	}
}
