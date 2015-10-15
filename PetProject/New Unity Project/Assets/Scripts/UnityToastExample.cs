using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnityToastExample : MonoBehaviour
{
	
	private AndroidJavaObject toastExample = null;
	private AndroidJavaObject activityContext = null;
	Text text;
	Text buttonText;

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

		if (isReady) 		
			buttonText.text = "Start Listening";
		else
			buttonText.text = "Stop Listening";
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