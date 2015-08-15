using UnityEngine;
using System.Collections;

public class Land : MonoBehaviour {

	private GameObject _Earth;

	private bool _canLand;
	private bool _landing;
	private GameObject _landingObj;

	private Vector3 _vel;

	public float LandingSpeed;
	public float Tolerance;

	public bool Landing {
		get {
			return _landing;
		}
	}


	// Use this for initialization
	void Start () {
		_Earth = GameObject.Find ("Earth");
		_landing = false;
		_canLand = false;
		_vel = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (_landing) {
			transform.position = Vector3.SmoothDamp (transform.position, _landingObj.transform.position, ref _vel, LandingSpeed);
		}

		if (_canLand && Input.GetButton ("Jump")) {
			_landing = true;
			_canLand = false;
		}
	}

	void OnGUI()
	{
		if (_canLand) {
			GUI.Box (new Rect (new Vector2 (Screen.width / 2 - 100, Screen.height / 2 - 100), new Vector2 (200, 200)), "PRESS A TO LAND");
		}
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject == _Earth) {
			PrepareToLandOn(_Earth);
		} else if (other.gameObject.name.Contains ("AsteroidLandingZone")) {
			Debug.Log ("Entered asteroid landing zone");
			// Test velocity to see if we can land
			if (CanLandOn(other.gameObject.transform.parent.gameObject)) {
				PrepareToLandOn(other.gameObject.transform.parent.gameObject);
			}
		}
	}

	bool CanLandOn(GameObject other) {
		// Compare velocities
		AsteroidMovement otherMovement = other.GetComponent<AsteroidMovement>();
		Vector2 otherVel = otherMovement.Velocity;
		
		float dist = Vector2.Distance(_vel, otherVel);
		return dist < Tolerance;
	}

	void PrepareToLandOn(GameObject target) {
		_canLand = true;
		_landing = false;
		_landingObj = target;
	}
}
