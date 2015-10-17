using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnityToastExample : MonoBehaviour
{
	
	private AndroidJavaObject toastExample = null;
	private AndroidJavaObject activityContext = null;
	public GameObject conver;
	Text text;
	Text buttonText;
	private bool hasListened=false;
	private bool doOnce=false;

	bool isReady;
	
	void Start() 
	{
		text = GameObject.FindGameObjectWithTag("TextTag").GetComponent<Text>();
		buttonText = GameObject.FindGameObjectWithTag("ButtonText").GetComponent<Text>();

		if(toastExample == null)
		{
			using(AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
			{
				activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
			}
			
			//using(AndroidJavaClass pluginClass = new AndroidJavaClass("com.nraboy.testplugin.ToastExample"))
			using(AndroidJavaClass pluginClass = new AndroidJavaClass("voicerecognition.example.com.voicerecognition.VoiceRecognition"))
			{
				if(pluginClass != null) 
				{
					toastExample = pluginClass.CallStatic<AndroidJavaObject>("instance");
					toastExample.Call("setContext", activityContext);
				}
			}

			activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
			                                                              {
				//text.text = toastExample.Call<string>("initializeSpeechRecognizer");
				toastExample.Call("initializeSpeechRecognizer");
			}));
		}
	}

	void Update(){
#if UNITY_ANDROID
		text.text = toastExample.Call<string> ("getRecognisedText");

		isReady = toastExample.Call<bool> ("isReady");
		if (hasListened&&doOnce){
			conver.GetComponent<Conversations>().CheckIfCorrectText(toastExample.Call<string> ("getRecognisedText"));
			//conver.GetComponent<Conversations>().CheckIfCorrectText(text.text);
			hasListened=false;
			doOnce=false;
		}

		if (isReady){ 
			buttonText.text = "Start Listening";
			doOnce=true;
		}
		else{
			buttonText.text = "Stop Listening";
			hasListened=true;
		}
#endif
	}



	public void VoiceButton()
	{
		activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
		                                                              {
			toastExample.Call("listenAndCheck2", isReady);
			
		}));

	}




}