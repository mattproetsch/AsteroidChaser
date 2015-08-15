using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	private float xVel;
	private float yVel;

	public float Speed;

	public float CollisionTolerance;

	// Use this for initialization
	void Start () {
		xVel = 0.0f;
		yVel = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!gameObject.GetComponent<Land> ().Landing) {
			xVel += Input.GetAxis ("Horizontal") * Speed;
			yVel += Input.GetAxis ("Vertical") * Speed;

			transform.position += Time.deltaTime * new Vector3 (xVel, yVel, 0.0f);
		}


	}


	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("OnTriggerEnter2D");
		if (other.name.Equals ("TightCollider", System.StringComparison.CurrentCultureIgnoreCase)) {
			// Compare velocities
			GameObject otherAsteroid = other.transform.parent.gameObject;

			AsteroidMovement otherMovement = otherAsteroid.GetComponent<AsteroidMovement>();
			Vector2 otherVel = otherMovement.Velocity;
			Vector2 thisVel = new Vector2(xVel, yVel);

			float dist = Vector2.Distance(thisVel, otherVel);
			Debug.Log ("Collision! Distance: " + dist);
		}
	}
}
