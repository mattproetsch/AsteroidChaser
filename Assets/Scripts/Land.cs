using UnityEngine;
using System.Collections;

public class Land : MonoBehaviour {

	public enum LandingStage {
		CantLand,
		CanLand,
		Landing,
		Landed
	}
	
	public float LandingSpeed;
	public float Tolerance;

	private GameObject _Earth;
	private LandingStage _landingStage;
	private GameObject _landingObj;

	private SpriteRenderer _sr;
	private float _landedWhenThisClose = 2.5f;
	private Vector3 _vel;

	public Sprite RegularSprite;
	public Sprite LandingSprite;
	public Sprite LandedSprite;

	private float _landingStartTime;
	public float MaxLandingTime;

	public bool Landing {
		get {
			return _landingStage == LandingStage.Landing;
		}
	}

	public bool Landed {
		get {
			return _landingStage == LandingStage.Landed;
		}
	}

	public bool CanLand {
		get {
			return _landingStage == LandingStage.CanLand;
		}
	}


	// Use this for initialization
	void Start () {
		_Earth = GameObject.Find ("Earth");
		_vel = new Vector3 (0, 0, 0);
		_sr = this.gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Landed) {
			transform.position = _landingObj.transform.position;
		}
		
		if (Landed && Input.GetButtonDown ("Jump")) {
			BlastOff ();
		}

		if (Landing) {
			transform.position = Vector3.SmoothDamp (transform.position, _landingObj.transform.position, ref _vel, LandingSpeed);
			if (Vector3.Distance(transform.position, _landingObj.transform.position) <= _landedWhenThisClose
			    || Time.time - _landingStartTime >= MaxLandingTime)
			{
				FinalizeLanding();
			}
		}

		if (CanLand && Input.GetButtonDown ("Jump")) {
			InitiateLandingSequence ();
		}
	}

	void OnGUI()
	{
		if (CanLand) {
			string msg;
			if (IsAsteroid(_landingObj)) {
				msg = "PRESS Y TO LAND ON " + _landingObj.name + "\n(" + _landingObj.GetComponent<AsteroidValue>().Value + " RESOURCES)";
			}
			else {
				msg = "PRESS Y TO LAND ON " + _landingObj.name;
			}
			GUI.Box (new Rect (new Vector2 (Screen.width / 2 - 100, Screen.height / 2 - 100), new Vector2 (200, 200)), msg);
		} else if (Landed) {
			GUI.Box (new Rect (new Vector2 (Screen.width / 2 - 100, Screen.height / 2 - 100), new Vector2 (200, 200)), "PRESS Y TO BLAST OFF");
		}
	}
		
	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject == _Earth) {

			if (_landingStage != LandingStage.CantLand) {

				switch (_landingStage) {

				case LandingStage.CanLand:
					CancelLandingPreparations(_landingObj);
					break;
				case LandingStage.Landing:
					FinalizeLanding();
					BlastOff();
					break;
				case LandingStage.Landed:
					BlastOff();
					break;
				}
			}

			PrepareToLandOn(_Earth);

		} else if (other.gameObject.name.Contains ("AsteroidLandingZone")) {

			Debug.Log ("Entered asteroid landing zone");
			// Test velocity to see if we can land
			if (_landingObj == null && CanLandOnAsteroid(other.gameObject.transform.parent.gameObject)) {

				PrepareToLandOn(other.gameObject.transform.parent.gameObject);

			} else {

				Debug.Log ("MATCH ITS SPEED");

			}
		}
	}

	void OnTriggerStay2D(Collider2D other) {

		if (IsAsteroidLandingZone (other.gameObject)) {

			if (_landingObj == null && !CanLandOnAsteroid (other.gameObject.transform.parent.gameObject)) {

				Debug.Log ("MATCH ITS SPEED");

			} else if (_landingObj == null && CanLandOnAsteroid (other.gameObject.transform.parent.gameObject)) {

				PrepareToLandOn (other.gameObject.transform.parent.gameObject);

			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == _Earth && other.gameObject == _landingObj) {

			CancelLandingPreparations (_Earth);

		} else if (IsAsteroidLandingZone(other.gameObject)) {

			if (other.gameObject.transform.parent.gameObject == _landingObj) {

				CancelLandingPreparations (other.gameObject.transform.parent.gameObject);

			}
		}
	}

	void PrepareToLandOn(GameObject target) {
		_landingStage = LandingStage.CanLand;
		_landingObj = target;
	}

	void CancelLandingPreparations (GameObject _Earth)
	{
		_landingStage = LandingStage.CantLand;
		_landingObj = null;
	}

	void InitiateLandingSequence ()
	{
		_landingStage = LandingStage.Landing;
		_sr.sprite = LandingSprite;
		_landingStartTime = Time.time;
	}

	/// <summary>
	/// Finalizes the landing. Extracts resources, adds to inventory.
	/// </summary>
	void FinalizeLanding ()
	{
		_landingStage = LandingStage.Landed;
		_sr.sprite = LandedSprite;

		if (IsAsteroid (_landingObj)) {
			// Extract resources from this asteroid and add them to inventory
			this.GetComponent<Inventory> ().MineralXAmt += _landingObj.GetComponent<AsteroidValue> ().Extract();
		}
	}

	bool CanLandOnAsteroid(GameObject other) {
		// Compare velocities
		Move myMovement = gameObject.GetComponent<Move> ();
		Vector2 myVel = myMovement.Velocity;
		AsteroidMovement otherMovement = other.GetComponent<AsteroidMovement>();
		Vector2 otherVel = otherMovement.Velocity;
		
		float dist = Vector2.Distance(_vel, otherVel);
		return dist < Tolerance;
	}

	void BlastOff() {
		_landingStage = LandingStage.CantLand;
		_sr.sprite = RegularSprite;

		float radius = 0.0f;
		if (_landingObj == _Earth)
			radius = 10.0f;
		else if (IsAsteroid(_landingObj)) {
			radius = 13.0f;
		}

		Vector2 random = (new Vector2 (Random.Range (-1.0f, 1.0f), Random.Range (-1.0f, 1.0f))).normalized;
		Vector3 delta = radius * random;
		transform.position = transform.position + delta;

		
		_landingObj = null;
	}

	bool IsAsteroid (GameObject _landingObj)
	{
		return _landingObj.name.Contains ("Asteroid");
	}

	bool IsAsteroidLandingZone(GameObject other) {
		return other.name.Contains("AsteroidLandingZone");
	}

}
