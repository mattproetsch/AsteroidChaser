using UnityEngine;
using System.Collections;

public class Land : MonoBehaviour {

	private GameObject _Earth;

	private bool _landing;

	private Vector3 _vel;

	public float LandingSpeed;

	public bool Landing {
		get {
			return _landing;
		}
	}


	// Use this for initialization
	void Start () {
		_Earth = GameObject.Find ("Earth");
		_landing = false;
		_vel = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (_landing) {
			transform.position = Vector3.SmoothDamp(transform.position, _Earth.transform.position, ref _vel, LandingSpeed);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == _Earth) {
			_landing = true;
		}
	}
}
