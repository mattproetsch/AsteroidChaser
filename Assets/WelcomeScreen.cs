using UnityEngine;
using System.Collections;

public class WelcomeScreen : MonoBehaviour {
	private int curstep;
	private int counter;
	// Use this for initialization
	void Start () {
		curstep = 1;
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown&&curstep==1) {
			curstep=2;
		}
		if (curstep == 2) {
			Debug.Log(counter);
			GameObject.Find ("ScrollText").GetComponent<RectTransform>().position=new Vector3(GameObject.Find ("ScrollText").GetComponent<RectTransform>().position.x,GameObject.Find ("ScrollText").GetComponent<RectTransform>().position.y+1,GameObject.Find ("ScrollText").GetComponent<RectTransform>().position.z);
			counter++;
			Debug.Log(counter);
			if(counter>100000000000000000){curstep=3;}
			Debug.Log(counter);
		}
		if (Input.anyKeyDown && curstep == 2) {
			curstep=3;
		}
		if (curstep == 3) {
			Application.LoadLevel("mainscene");
		}
	}
}
