using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	private float xVel;
	private float yVel;

	public float Speed;

	// Use this for initialization
	void Start () {
		xVel = 0.0f;
		yVel = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

		xVel += Input.GetAxis ("Horizontal") * Speed;
		yVel += Input.GetAxis ("Vertical") * Speed;

		transform.position += Time.deltaTime * new Vector3 (xVel, yVel, 0.0f);
		
	}
}
