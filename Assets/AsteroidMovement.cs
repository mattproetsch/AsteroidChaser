using UnityEngine;
using System.Collections;

public class AsteroidMovement : MonoBehaviour {

	public Vector3 StartPosition;
	public float AxisRotationDegrees;
	public float XRadius;
	public float YRadius;
	public float Speed;

	private float _axRotRad;
	private float _sinRot;
	private float _cosRot;

	private Vector2 _u;
	private Vector2 _v;
	private Vector2 _StartPosition;
	private float _speedFactor;

	// Use this for initialization
	void Start () {
		_axRotRad = Mathf.Deg2Rad * AxisRotationDegrees;
		_sinRot = Mathf.Sin (_axRotRad);
		_cosRot = Mathf.Cos (_axRotRad);

		_u = new Vector2 (_cosRot, _sinRot);
		_v = new Vector2 (-_sinRot, _cosRot);

		_StartPosition = new Vector2 (StartPosition.x, StartPosition.y);
		if (Speed > 0) {
			_speedFactor = 1 / Speed;
		}

	}
	
	// Update is called once per frame
	void Update () {
		float t = Time.time;
		float dt = Time.deltaTime;

		Vector2 newPos = _StartPosition + (XRadius * Mathf.Cos (t / _speedFactor) * _u) + (YRadius * Mathf.Sin (t / _speedFactor) * _v);
		transform.position = newPos;


	}
}
