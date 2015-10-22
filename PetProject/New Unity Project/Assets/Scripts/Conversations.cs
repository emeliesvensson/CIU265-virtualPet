using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Conversations : MonoBehaviour {
	public string [] spanishLines;
	public string [] frenchLines;
	public string[] altFrenchLines;
	private int i=0;
	private SkinnedMeshRenderer kittBody;
	private TriggerAnimations cat;
	private Text saidText;
	private int index;
	private string sCompare;

	public AudioClip [] audioLines;
	public AudioSource soundSource;

	public Image speechBubble; 
	private int tries = 0;


	// Use this for initialization
	void Start () {
		ChangeText ();
		kittBody= GameObject.FindGameObjectWithTag("EnableBubble").GetComponent<SkinnedMeshRenderer> ();
		cat = GameObject.FindGameObjectWithTag ("Cat").GetComponent<TriggerAnimations> ();
		saidText= GameObject.FindGameObjectWithTag("TextTag").GetComponent<Text>();
		speechBubble = GameObject.FindGameObjectWithTag ("CatSpeechBubble").GetComponent<Image> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (kittBody.enabled) {
			EnableText ();
		} else
			DisableText ();
		sCompare = saidText.text;
		if (Input.GetKeyDown ("t")) {
			//Debug.Log("pressed t");
			cat.triggerAngry();
		}else if(Input.GetKeyDown ("y")){
			//Debug.Log("pressed y");
			cat.triggerHappySailJump();
			ChangeText();
		}
	}

	public void ChangeText(){
		index = i % frenchLines.Length;
		foreach (Text txt in this.gameObject.GetComponentsInChildren<Text> () ){
			if(txt.tag == "ConvoTxt")
				txt.text=frenchLines[index];
		}
		i++;
		PlaySound ();
	}

	public void EnableText(){
		foreach (Text txt in this.gameObject.GetComponentsInChildren<Text> () ){
			if(txt.tag == "ConvoTxt")
			{
				txt.enabled=true;
				speechBubble.enabled = true;
			}
		}
	}
	public void DisableText(){
		foreach (Text txt in this.gameObject.GetComponentsInChildren<Text> () ){
			if(txt.tag == "ConvoTxt")
			{
				txt.enabled=false;
				speechBubble.enabled = false;

			}
		}
	}

	public void CheckIfCorrectText(){
		//TODO Remove from here
	/*	foreach (Text txt in this.gameObject.GetComponentsInChildren<Text> () ){
			if(txt.tag == "ConvoTxt")
				txt.text="compared: "+sCompare.ToLower () + " " +frenchLines [index].ToLower ();
		}*/
		//TODO to here
		if (tries == 5) 
		{
			cat.triggerSad();
			tries = 0;
			ChangeText();
		}


		else if (sCompare.ToLower () == frenchLines [index].ToLower ()|| sCompare.ToLower () == altFrenchLines [index].ToLower () ) {
			cat.triggerHappySailJump ();
			ChangeText ();
			tries = 0;
		}
		else {
			cat.triggerAngry();
			PlaySound ();
			tries++;
		}

	}

	public void PlaySound(){
		soundSource.clip = audioLines [index];
		soundSource.Play ();
	}
}

