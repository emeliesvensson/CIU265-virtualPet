using UnityEngine;
using System.Collections;

public class TriggerAnimations : MonoBehaviour {
	public AnimationClip sad;
	public AnimationClip sailJump;
	public AnimationClip happy;
	private Animation anim;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		//TODO remove from here when it can be controlled by voice
		if (Input.GetKeyDown ("t")) {
			Debug.Log("pressed t");
			triggerSad();
		}else if(Input.GetKeyDown ("y")){
			Debug.Log("pressed y");
			triggerHappySailJump();
		}
		//TODO remove to here

		if (!anim.isPlaying) {
			anim.CrossFade (happy.name);
		}
	}
	public void triggerSad(){

		anim.CrossFade (sad.name);
	}

	public void triggerHappySailJump(){
		anim.CrossFade (sailJump.name);
	}

}
