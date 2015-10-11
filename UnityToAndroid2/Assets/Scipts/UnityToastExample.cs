using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnityToastExample : MonoBehaviour
{
	
	private AndroidJavaObject toastExample = null;
	private AndroidJavaObject activityContext = null;
	
	void Start() 
	{
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
		}
	}

	void Update(){

	}

	void OnGUI() 
	{
		int h = Screen.height;
		int w = Screen.width;
		
		if (GUI.Button (new Rect (h * 0.1f, h * 0.1f, w * 0.5f, h * 0.2f), "Toast"))
		{
			activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
			{
				toastExample.Call("showMessage", " ¯\\_(ツ)_/¯ ");
			}));
		}

		if (GUI.Button (new Rect (h * 0.1f, h * 0.3f, w * 0.5f, h * 0.2f), "Return Bool"))
		{
			Text text = GameObject.FindGameObjectWithTag("TextTag").GetComponent<Text>();

			if(toastExample.Call<bool>("getBool"))
				text.text = "TRUE";
		}

		if (GUI.Button (new Rect (h * 0.1f, h * 0.5f, w * 0.5f, h * 0.2f), "Initialize Voice"))
		{
			Text text = GameObject.FindGameObjectWithTag("TextTag").GetComponent<Text>();
		//	text.text = "Initialize VoiceRecognizer";

			activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
			                                                              {
				//text.text = toastExample.Call<string>("initializeSpeechRecognizer");
				toastExample.Call("initializeSpeechRecognizer");
			}));

		}

		if (GUI.Button (new Rect (h * 0.1f, h * 0.7f, w * 0.5f, h * 0.2f), "Start Voice"))
		{
			Text text = GameObject.FindGameObjectWithTag("TextTag").GetComponent<Text>();
			
		

			activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
			                                                              {
				if(toastExample.Call<bool>("listenAndCheck", "Hola!"))
					text.text = "HOLA";
			}));

		}
		
	}
}