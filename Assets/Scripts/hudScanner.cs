using UnityEngine;
using System.Collections;

public class hudScanner : MonoBehaviour {
	private GameObject _ship;
	private shipScanner _scanner;
	public GameObject BlipPrefab;
	private GameObject _guiCanvas;

	
	// Use this for initialization
	void Start () {

		_ship = GameObject.Find ("Ship");
		_scanner = _ship.GetComponent<shipScanner> ();
		_guiCanvas = GameObject.Find ("Canvas");

		//Creates pool of blips for rendering
		for (int i=0; i<15; i++) {
			_scanner._blips.Add( (GameObject.Instantiate(BlipPrefab)) as GameObject );
			_scanner._blips[i].transform.parent = _guiCanvas.transform;
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0;i<_scanner._scannedObjects.Count;i++) {
			GameObject body = _scanner._scannedObjects[i];
			GameObject blip = _scanner._blips[i];  

			float dist = Vector3.Distance(body.transform.position,_ship.transform.position);
			dist /= 200;
			RectTransform rTransform = blip.GetComponent<RectTransform>();
			rTransform.position = new Vector3(100,100,0);


		}
	}
}
