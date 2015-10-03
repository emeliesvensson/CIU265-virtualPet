using UnityEngine;
using System.Collections;

public class TriggerAnimations : MonoBehaviour {
	public AnimationClip angry;
	public AnimationClip sailJump;
	public AnimationClip happy;
	private Animation anim;

	int fingerCount;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animation>();
		Debug.Log (anim.GetClipCount());
	}
	
	// Update is called once per frame
	void Update () {
		//TODO remove from here when it can be controlled by voice
		if (Input.GetKeyDown ("t")) {
			Debug.Log("pressed t");
			triggerAngry();
		}else if(Input.GetKeyDown ("y")){
			Debug.Log("pressed y");
			triggerHappySailJump();
		}

		fingerCount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				fingerCount++;
			
		}
		if (fingerCount == 1)
			triggerAngry ();
		else if (fingerCount > 1)
			triggerHappySailJump ();

		//TODO remove to here

		if (!anim.isPlaying) {
			anim.CrossFade (happy.name);
		}
	}
	public void triggerAngry(){

		anim.CrossFade (angry.name);
	}

	public void triggerHappySailJump(){
		anim.CrossFade (sailJump.name);
	}

}
