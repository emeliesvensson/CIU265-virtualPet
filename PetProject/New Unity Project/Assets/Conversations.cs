using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Conversations : MonoBehaviour {
	public string [] lines;
	private int i=0;


	// Use this for initialization
	void Start () {
		ChangeText ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeText(){
		foreach (Text txt in this.gameObject.GetComponentsInChildren<Text> () ){
			txt.text=lines[i % lines.Length];
		}
		i++;
	}
}
