using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Conversations : MonoBehaviour {
	public string [] spanishLines;
	public string [] frenchLines;
	private int i=0;
	private SkinnedMeshRenderer kittBody;
	public GameObject cat;
	//private Text saidText;
	private int index;


	// Use this for initialization
	void Start () {
		ChangeText ();
		kittBody= GameObject.FindGameObjectWithTag("EnableBubble").GetComponent<SkinnedMeshRenderer> ();
		cat = GameObject.FindGameObjectWithTag ("Cat");
		//saidText= GameObject.FindGameObjectWithTag("TextTag").GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		if (kittBody.enabled) {
			EnableText ();
		} else
			DisableText ();

	}

	public void ChangeText(){
		index = i % frenchLines.Length;
		foreach (Text txt in this.gameObject.GetComponentsInChildren<Text> () ){
			if(txt.tag == "ConvoTxt")
				txt.text=frenchLines[index];
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
		//TODO Remove from here
		foreach (Text txt in this.gameObject.GetComponentsInChildren<Text> () ){
			if(txt.tag == "ConvoTxt")
				txt.text="compared: "+s.ToLower () + " " +frenchLines [index].ToLower ();
		}
		//TODO to here
		if (s.ToLower () == frenchLines [index].ToLower ()) {
			cat.GetComponent<TriggerAnimations> ().triggerHappySailJump ();
			ChangeText ();
		}
		else {
			cat.GetComponent<TriggerAnimations> ().triggerAngry();
		}

	}
}
