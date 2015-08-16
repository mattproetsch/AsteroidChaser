using UnityEngine;
using System.Collections;
using UnityEngine.UI;




public class resourceText : MonoBehaviour {
	private Inventory inventory;
	private GameObject ship;
	public Text text;
	private float dispAmount;
	private int collected;
	private float deltaAmount;

	// Use this for initialization
	void Start () {
		ship = GameObject.Find ("Ship");
		inventory = ship.GetComponent<Inventory> ();
		text.text = "Resources: "+inventory.MineralXAmt.ToString();
	
	}
	
	// Update is called once per frame
	void Update () {
		collected = inventory.MineralXAmt;
		dispAmount += (collected-dispAmount)*0.05f;
		text.text = "Resources: "+Mathf.Ceil (dispAmount).ToString();
	}
}
