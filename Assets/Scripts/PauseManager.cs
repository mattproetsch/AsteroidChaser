using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {
	private bool paused;
	public GameObject Menus;
	public GameObject Menu;
	// Use this for initialization
	void Awake () {
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (paused) {
			Vector2 tempVector = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis ("Vertical"));
			float tempAngle = Mathf.Rad2Deg*Mathf.Atan (tempVector.y/tempVector.x);
			Debug.Log (tempAngle);
			if(tempAngle<30f&&tempAngle>-30f&&tempVector.x>0f){
				GameObject.Find ("Exit").GetComponent<Image>().color=new Color (176f/255f,184f/255f,45f/255f,1f);
			}
			else{
				GameObject.Find ("Exit").GetComponent<Image>().color=new Color (109f/255f,28f/255f,108f/255f,1f);
			}
			if(tempAngle<90f&&tempAngle>30f&&tempVector.x>0f){
				GameObject.Find ("Options").GetComponent<Image>().color=new Color (176f/255f,184f/255f,45f/255f,1f);
			}
			else{
				GameObject.Find ("Options").GetComponent<Image>().color=new Color (109f/255f,28f/255f,108f/255f,1f);
			}
			if(tempAngle<-30f&&tempAngle>-90f&&tempVector.x>0f){
				GameObject.Find ("Load").GetComponent<Image>().color=new Color (176f/255f,184f/255f,45f/255f,1f);
			}
			else{
				GameObject.Find ("Load").GetComponent<Image>().color=new Color (109f/255f,28f/255f,108f/255f,1f);
			}



			if(tempAngle<30f&&tempAngle>-30f&&tempVector.x<0f){
				GameObject.Find ("Map").GetComponent<Image>().color=new Color (176f/255f,184f/255f,45f/255f,1f);
			}
			else{
				GameObject.Find ("Map").GetComponent<Image>().color=new Color (109f/255f,28f/255f,108f/255f,1f);
			}
			if(tempAngle<90f&&tempAngle>30f&&tempVector.x<0f){
				GameObject.Find ("Save").GetComponent<Image>().color=new Color (176f/255f,184f/255f,45f/255f,1f);
			}
			else{
				GameObject.Find ("Save").GetComponent<Image>().color=new Color (109f/255f,28f/255f,108f/255f,1f);
			}
			if(tempAngle<-30f&&tempAngle>-90f&&tempVector.x<0f){
				GameObject.Find ("Inventory").GetComponent<Image>().color=new Color (176f/255f,184f/255f,45f/255f,1f);
			}
			else{
				GameObject.Find ("Inventory").GetComponent<Image>().color=new Color (109f/255f,28f/255f,108f/255f,1f);
			}







			if(Input.GetButtonDown ("Fire1")){
				if(Menu.activeInHierarchy){Menu.SetActive(false);}
				else{Menu.SetActive(true);}
			}
		}
		if (Input.GetButtonDown ("Fire3") && !paused) {
			Debug.Log ("skdljfsdkljsfjslk;dajf;l");
			Time.timeScale = 0.0f;
			paused=true;
			Menus.SetActive(true);
			return;
		} 
		if (Input.GetButtonDown ("Fire3") && paused) {
			Debug.Log ("skdljfsdkljsfjslk;dajf;l");
			Time.timeScale = 1;
			paused = false;
			Menus.SetActive (false);
			return;
		}

		//Debug.Log(System.Convert.ToString(Input.GetJoystickName));
	}
}
