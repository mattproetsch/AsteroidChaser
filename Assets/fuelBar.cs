using UnityEngine;
using System.Collections;

public class fuelBar : MonoBehaviour {

	private RectTransform _rXform;
	private float _barScale;

	// Use this for initialization
	void Start () {
		_rXform = this.GetComponent<RectTransform> ();
		_barScale = _rXform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		//_barScale = ; //Get ship fuel level
		_rXform.localScale = new Vector3 (_barScale, _rXform.localScale.y);
	}
}
