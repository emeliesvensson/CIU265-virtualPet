package voicerecognition.example.com.voicerecognition;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.os.Debug;
import android.speech.RecognitionListener;
import android.speech.RecognizerIntent;
import android.speech.SpeechRecognizer;
import android.speech.tts.Voice;
import android.widget.Toast;

import java.util.List;

public class VoiceRecognition {

    private SpeechRecognizer speechRecognizer = null;
    private String recognisedText = null;
    private Activity activity;

    //For the new test
    private Context context;
    private static VoiceRecognition instance;

   /* Maybe needed for several activities
   public VoiceRecognition(Activity activity){

        this.activity=activity;
    }*/

    //for the new test
    public VoiceRecognition() {
        this.instance = this;
    }

    public static VoiceRecognition instance(){
        if(instance == null){
            instance = new VoiceRecognition();
        }
        return  instance;
    }

    public void setContext(Context context) {
        this.context = context;
    }

    public void showMessage(String message){
        Toast.makeText(this.context, message, Toast.LENGTH_SHORT).show();
    }


    public boolean getBool(){
        return true;
    }

    public String returnString(String text ) {
        return text;
    }
    //new test end

/*
    public boolean listenAndCheck(String text){
        Intent intent = new Intent();
        intent.putExtra(RecognizerIntent.EXTRA_LANGUAGE, "fr");
        intent.putExtra("android.speech.extra.EXTRA_ADDITIONAL_LANGUAGES", new String[]{});
        speechRecognizer.startListening(intent);
      //  while(recognisedText==null){}
        boolean areEqual = text.toLowerCase().equals(recognisedText);


        recognisedText=null;

        return true;
    }*/

    public boolean listenAndCheck(String text){
        Toast.makeText(context, text, Toast.LENGTH_SHORT).show();
        Intent intent = new Intent();
        intent.putExtra(RecognizerIntent.EXTRA_LANGUAGE, "fr");
        intent.putExtra("android.speech.extra.EXTRA_ADDITIONAL_LANGUAGES", new String[]{});
        speechRecognizer.startListening(intent);
        Toast.makeText(context, "Started listening", Toast.LENGTH_SHORT).show();
        if(recognisedText==null){
            Toast.makeText(context, "Didn't work", Toast.LENGTH_SHORT).show();
            return false;
        }else{
            Toast.makeText(context, "Worked!", Toast.LENGTH_SHORT).show();
            Boolean areEqual = text.toLowerCase().equals(recognisedText);
            recognisedText=null;
            Toast.makeText(context, areEqual.toString(), Toast.LENGTH_SHORT).show();
            return areEqual;
        }
    }

    public void initializeSpeechRecognizer() {
        if (speechRecognizer == null) {
          //  speechRecognizer = SpeechRecognizer.createSpeechRecognizer(activity);
            speechRecognizer = SpeechRecognizer.createSpeechRecognizer(context);
            speechRecognizer.setRecognitionListener(new RecognitionListener() {

                @Override
                public void onReadyForSpeech(Bundle params) {
                    //Do something here?
                }

                @Override
                public void onBeginningOfSpeech() {
                }

                @Override
                public void onRmsChanged(float rmsdB) {
                }

                @Override
                public void onBufferReceived(byte[] buffer) {
                }

                @Override
                public void onEndOfSpeech() {
                }

                @Override
                public void onError(int error) {
                    if (error == SpeechRecognizer.ERROR_AUDIO) {
                        //
                    } else if (error == SpeechRecognizer.ERROR_SPEECH_TIMEOUT) {
                        //
                    } else if (error == SpeechRecognizer.ERROR_CLIENT) {
                       //
                    } else if (error == SpeechRecognizer.ERROR_INSUFFICIENT_PERMISSIONS) {
                        //
                    } else if (error == SpeechRecognizer.ERROR_NETWORK) {
                        //
                    } else if (error == SpeechRecognizer.ERROR_NETWORK_TIMEOUT) {
                        //
                    } else if (error == SpeechRecognizer.ERROR_NO_MATCH) {
                        //
                    } else if (error == SpeechRecognizer.ERROR_RECOGNIZER_BUSY) {
                        //
                    } else if (error == SpeechRecognizer.ERROR_SERVER) {
                        //
                    }
                }

                @Override
                public void onResults(Bundle results) {
                    List<String> resultList = results.getStringArrayList(SpeechRecognizer.RESULTS_RECOGNITION);
                    if (resultList != null) {
                        recognisedText=resultList.get(0);
                    } else {
                        recognisedText = "";
                    }
                }

                @Override
                public void onPartialResults(Bundle partialResults) {
                }

                @Override
                public void onEvent(int eventType, Bundle params) {
                }
            });
        }

    }
}
