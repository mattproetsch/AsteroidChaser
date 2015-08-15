using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	private Vector2 _vel;

	public float SpeedScale;
	public float MaxSpeed;
	public float RotationSpeed;

	public float CollisionTolerance;

	private Land _Land;

	public Vector2 Velocity {
		get {
			return _vel;
		}
	}

	// Use this for initialization
	void Start () {
		_vel = new Vector2 (0.0f, 0.0f);
		_Land = this.gameObject.GetComponent<Land> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Speed: " + _vel.magnitude.ToString());
		if (!_Land.Landing && !_Land.Landed) {
			transform.position += new Vector3 (_vel.x, _vel.y);
		}
	}

	// Update position based on inputs
	void FixedUpdate() {
		if (!_Land.Landing && !_Land.Landed) {
			PositionUpdate ();
		} else {
			_vel = Vector2.zero;
		}
	}


	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("OnTriggerEnter2D");
		if (other.name.Equals ("AsteroidBody", System.StringComparison.CurrentCultureIgnoreCase)) {
			// Compare velocities
			GameObject otherAsteroid = other.transform.parent.gameObject;

			AsteroidMovement otherMovement = otherAsteroid.GetComponent<AsteroidMovement>();
			Vector2 otherVel = otherMovement.Velocity;

			float dist = Vector2.Distance(_vel, otherVel);
			Debug.Log ("Collision! Distance: " + dist);
		}
	}

	void PositionUpdate ()
	{
		float thrust = 0.0f;
		if (Input.GetButton ("Fire1")) {
			thrust = 0.1f * Time.fixedDeltaTime * SpeedScale;
		}
		if (Input.GetButton ("Fire2")) {
			thrust -= 0.1f * Time.fixedDeltaTime * SpeedScale;
		}
		float pitchDelta = -Input.GetAxis ("Horizontal") * RotationSpeed;
		transform.Rotate (0, 0, pitchDelta);
		// See if adding thrust in this direction results in a speed above MaxSpeed
		// If not, apply thrust
		Vector2 accel = transform.TransformDirection (Vector3.up) * thrust;
		Vector2 newVel = _vel + accel;
		if (newVel.magnitude <= MaxSpeed) {
			_vel = newVel;
		}
	}
}
