using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class b01_onClick : MonoBehaviour {
	// Use this for initialization
	public GameObject MenusObject;

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.anyKeyDown) {
		if (Input.GetKeyDown("p")){
			//Debug.Log (system.convert.ToString(Input.Ke);
			//if(Input.GetKeyDown("p");
			if (!MenusObject.activeInHierarchy){MenusObject.SetActive(true);}
			else {MenusObject.SetActive (false);}
			Debug.Log (MenusObject.activeInHierarchy);
		}
		Debug.Log ("H"+Input.GetAxis ("Horizontal")+"V"+Input.GetAxis ("Vertical"));
	}
	private void displayMenu()
	{

		//GameObject toChange = GameObject.Find ("Menus");
		//Debug.Log (toChange);
	//	GameObject.Find("Menus").SetActive (true);
	}
	public void getSound (string soundName)
	{
		switch (soundName) {
		case "Inventory":
			//GameObject.Find ("InvScreen").GetComponent<;
			GameObject.Find ("Dimmer").GetComponent<Image>().enabled=true;
			GameObject.Find ("InventoryExit").GetComponent<Image>().enabled=true;
			GameObject.Find ("InventoryExit").GetComponent<Button>().enabled=true;
			GameObject.Find ("InventoryExit").GetComponentInChildren<Text>().enabled=true;
			break;
		case "InventoryClose":
			GameObject.Find ("Dimmer").GetComponent<Image>().enabled=false;
			GameObject.Find ("InventoryExit").GetComponent<Image>().enabled=false;
			GameObject.Find ("InventoryExit").GetComponent<Button>().enabled=false;
			GameObject.Find ("InventoryExit").GetComponentInChildren<Text>().enabled=false;
			break;
		case "Options":
			Debug.Log ("options too");
			break;
		case "Map":
			break;
		}
	}
}
