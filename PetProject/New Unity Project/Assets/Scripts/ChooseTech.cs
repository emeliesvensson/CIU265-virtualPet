using UnityEngine;
using System.Collections;

public class ChooseTech : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadCardboard(){
		Application.LoadLevel("Cardboard");
	}

	public void LoadPhone(){
		Application.LoadLevel("Phone");
	}
}
