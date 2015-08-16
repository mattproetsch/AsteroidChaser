using UnityEngine;
using System.Collections;

public class AsteroidMovement : MonoBehaviour {

	//public Vector3 StartPosition;
	public float AxisRotationDegrees;
	public float XRadius;
	public float YRadius;
	public float Speed;
	public bool IsRandom;

	private float _axRotRad;
	private float _sinRot;
	private float _cosRot;

	private Vector2 _u;
	private Vector2 _v;
	private Vector2 _StartPosition;
	private float _speedFactor;

	private Vector2 _velocity;
	public Vector2 Velocity {
		get {
			return _velocity;
		}
	}

	// Use this for initialization
	void Start () {
		
		if (IsRandom) {
			AxisRotationDegrees = Random.Range (0.0f, 180.0f);
			XRadius = Random.Range(10.0f, 100.0f);
			YRadius = Random.Range(10.0f, 100.0f);
			Speed = Random.Range(0.1f, 0.01f);
		}

		_axRotRad = Mathf.Deg2Rad * AxisRotationDegrees;
		_sinRot = Mathf.Sin (_axRotRad);
		_cosRot = Mathf.Cos (_axRotRad);

		_u = new Vector2 (_cosRot, _sinRot);
		_v = new Vector2 (-_sinRot, _cosRot);

		_StartPosition = new Vector2 (transform.position.x, transform.position.y);
		if (Speed > 0) {
			_speedFactor = 1 / Speed;
		}
	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.time;
		float dt = Time.deltaTime;

		Vector2 newPos = _StartPosition + (XRadius * Mathf.Cos (t / _speedFactor) * _u) + (YRadius * Mathf.Sin (t / _speedFactor) * _v);
		_velocity = (newPos - new Vector2 (transform.position.x, transform.position.y)) / Time.deltaTime;
		transform.position = newPos;


	}
}
