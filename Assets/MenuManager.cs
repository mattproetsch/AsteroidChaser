using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//GameObject.Find ("Inventory").GetComponent<Button>().onClick(Debug.Log ("ok");,)
	}
	public void changeVisible(string testVal){
		switch (testVal)
		{
		case "btn1":
			Debug.Log("ok");
			break;
		}
	}
}