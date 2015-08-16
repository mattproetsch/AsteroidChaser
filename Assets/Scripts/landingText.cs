using UnityEngine;
using System.Collections;
using UnityEngine.UI;




public class landingText : MonoBehaviour {
	public Text text;
	private GameObject BG;
	private bool show;
	

	// Use this for initialization
	void Start () {
		text.text = "Resources: "+inventory.MineralXAmt.ToString();
		BG = GameObject.Find ("landingTextBG");
	}

	void showText(string s){
		text.text = "Press B to land on " + s;
		text.gameObject.SetActive (true);
		return true;
	}
	
	// Update is called once per frame
	void Update () {



	}
}
