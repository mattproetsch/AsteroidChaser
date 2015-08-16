using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	private Vector2 _vel;
	private ParticleSystem _particles;

	public float SpeedScale;
	public float MaxSpeed;
	public float RotationSpeed;

	public float CollisionTolerance;

	private Land _Land;

	bool _emitForward;
	bool _emitBackward;

	public Vector2 Velocity {
		get {
			return _vel;
		}
	}

	// Use this for initialization
	void Start () {
		_vel = new Vector2 (0.0f, 0.0f);
		_Land = this.gameObject.GetComponent<Land> ();
		_particles = this.gameObject.GetComponentInChildren<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Speed: " + _vel.magnitude.ToString());
		if (!_Land.Landing && !_Land.Landed) {
			transform.position += new Vector3 (_vel.x, _vel.y);
		}

		PositionUpdate ();
	}

	// Update position based on inputs
	void FixedUpdate() {
		if (!_Land.Landing && !_Land.Landed) {
			VelocityUpdate ();
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

	void VelocityUpdate ()
	{
		_emitForward = false;
		_emitBackward = false;

		float thrust = 0.0f;
		if (Input.GetButton ("Fire1")) {
			thrust = 0.1f * Time.fixedDeltaTime * SpeedScale;
			_emitForward = true;
		}
		if (Input.GetButton ("Fire2")) {
			thrust -= 0.1f * Time.fixedDeltaTime * SpeedScale;
			_emitBackward = true;
		}
		// See if adding thrust in this direction results in a speed above MaxSpeed
		// If not, apply thrust
		Vector2 accel = transform.TransformDirection (Vector3.up) * thrust;
		Vector2 newVel = _vel + accel;
		if (newVel.magnitude <= MaxSpeed) {
			_vel = newVel;
		} 
	}

	void PositionUpdate() {
		
		
		float pitchDelta = -Input.GetAxis ("Horizontal") * RotationSpeed;
		transform.Rotate (0, 0, pitchDelta);

		_particles.enableEmission = _emitForward || _emitBackward;
		
		if (_emitForward) {
			_particles.transform.rotation = Quaternion.Euler (90, 0, 0);
		} else if (_emitBackward) {
			_particles.transform.rotation = Quaternion.Euler (270, 0, 0);
		}
	}
}
