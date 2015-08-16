using UnityEngine;
using System.Collections;
using UnityEngine.UI;




public class resourceText : MonoBehaviour {
	private Inventory inventory;
	private GameObject ship;
	public Text text;
	private float collectedAmount;
	private int collected;

	private float returnedAmount;
	private int returned;

	// Use this for initialization
	void Start () {
		ship = GameObject.Find ("Ship");
		inventory = ship.GetComponent<Inventory> ();
		text.text = "Resources: "+inventory.MineralXAmt.ToString();
	
	}
	
	// Update is called once per frame
	void Update () {
		collected = inventory.MineralXAmt;
		collectedAmount += (collected-collectedAmount)*0.05f;

		returned = inventory.returnedAmt;
		returnedAmount += (returned-returnedAmount)*0.05f;

		text.text = "Resources: "+Mathf.Ceil (collectedAmount).ToString()+"\nReturned: "+Mathf.Ceil (returnedAmount).ToString();
	}
}
