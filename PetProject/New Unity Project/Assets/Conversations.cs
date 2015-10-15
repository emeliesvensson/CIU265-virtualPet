using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Conversations : MonoBehaviour {
	public string [] spanishLines;
	public string [] frenchLines;
	private int i=0;
	private SkinnedMeshRenderer kittBody;
	public GameObject cat;


	// Use this for initialization
	void Start () {
		ChangeText ();
		kittBody= GameObject.FindGameObjectWithTag("EnableBubble").GetComponent<SkinnedMeshRenderer> ();
		cat = GameObject.FindGameObjectWithTag ("Cat");

	}
	
	// Update is called once per frame
	void Update () {
		if (kittBody.enabled) {
			EnableText ();
		} else
			DisableText ();

	}

	public void ChangeText(){
		foreach (Text txt in this.gameObject.GetComponentsInChildren<Text> () ){
			if(txt.tag == "ConvoTxt")
				txt.text=frenchLines[i % frenchLines.Length];
		}
		i++;
	}

	public void EnableText(){
		foreach (Text txt in this.gameObject.GetComponentsInChildren<Text> () ){
			if(txt.tag == "ConvoTxt")
				txt.enabled=true;
		}
	}
	public void DisableText(){
		foreach (Text txt in this.gameObject.GetComponentsInChildren<Text> () ){
			if(txt.tag == "ConvoTxt")
				txt.enabled=false;
		}
	}

	public void CheckIfCorrectText(string s){
		if (s.ToLower() == frenchLines [i % frenchLines.Length].ToLower())
			cat.GetComponent<TriggerAnimations> ().triggerHappySailJump ();
		else {
			cat.GetComponent<TriggerAnimations> ().triggerAngry();
		}
	}
}
