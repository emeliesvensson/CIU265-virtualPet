using UnityEngine;
using System.Collections;

public class testAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Animation>()["Ithcing"].layer  = 1;
		GetComponent<Animation>()["Ithcing"].wrapMode = WrapMode.Once;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("k")) {
			GetComponent<Animation> ().Play ("Ithcing");
		} 

	}

}
