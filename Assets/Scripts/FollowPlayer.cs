using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	
	public float dampTime = 0.1f;
	private Vector3 velocity = Vector3.zero;
	public GameObject target;
	private Transform targetTransform;
	private Camera camera;

	void Start()
	{
		camera = this.gameObject.GetComponent<Camera> ();
		targetTransform = target.transform;
	}


	
	// Update is called once per frame
	void Update () 
	{
		if (targetTransform)
		{
			Vector3 point = camera.WorldToViewportPoint(targetTransform.position);
			Vector3 delta = targetTransform.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
			Vector3 destination = transform.position + delta;
			// smooth:
			//transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
			// directly follow:
			transform.position = destination;
		}
	}
}