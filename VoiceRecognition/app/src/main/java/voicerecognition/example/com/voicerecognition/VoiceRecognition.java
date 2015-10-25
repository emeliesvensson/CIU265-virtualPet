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
    private boolean isReady = true;

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

    public boolean isReady(){
        return isReady;
    }

    public String returnString(String text ) {
        return text;
    }

    public String getRecognisedText(){
        return recognisedText;
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


    public void listenAndCheck2(boolean value){
        if (value) {
            Intent intent = new Intent();
            intent.putExtra(RecognizerIntent.EXTRA_LANGUAGE, "fr");
            intent.putExtra("android.speech.extra.EXTRA_ADDITIONAL_LANGUAGES", new String[]{});

            isReady = false;

            speechRecognizer.startListening(intent);
          //  Toast.makeText(context, "Starting to listen", Toast.LENGTH_SHORT).show();

        } else {
            speechRecognizer.stopListening();
          //  Toast.makeText(context, recognisedText, Toast.LENGTH_SHORT).show();

            isReady = true;
          //  recognisedText = "";

        }
    }

    public void initializeSpeechRecognizer() {
        if (speechRecognizer == null) {
          //  speechRecognizer = SpeechRecognizer.createSpeechRecognizer(activity);
            speechRecognizer = SpeechRecognizer.createSpeechRecognizer(context);
            speechRecognizer.setRecognitionListener(new RecognitionListener() {

                @Override
                public void onReadyForSpeech(Bundle params) {
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
                    isReady = true;

                }

                @Override
                public void onError(int error) {
                    isReady = true;


                    if (error == SpeechRecognizer.ERROR_AUDIO) {
                        Toast.makeText(context, "1", Toast.LENGTH_SHORT).show();

                    } else if (error == SpeechRecognizer.ERROR_SPEECH_TIMEOUT) {
                       // Toast.makeText(context, "2", Toast.LENGTH_SHORT).show();

                    } else if (error == SpeechRecognizer.ERROR_CLIENT) {
                        Toast.makeText(context, "3", Toast.LENGTH_SHORT).show();

                    } else if (error == SpeechRecognizer.ERROR_INSUFFICIENT_PERMISSIONS) {
                        Toast.makeText(context, "4", Toast.LENGTH_SHORT).show();

                    } else if (error == SpeechRecognizer.ERROR_NETWORK) {
                        Toast.makeText(context, "5", Toast.LENGTH_SHORT).show();

                    } else if (error == SpeechRecognizer.ERROR_NETWORK_TIMEOUT) {
                        Toast.makeText(context, "6", Toast.LENGTH_SHORT).show();

                    } else if (error == SpeechRecognizer.ERROR_NO_MATCH) {
                      //  Toast.makeText(context, "7", Toast.LENGTH_SHORT).show();

                    } else if (error == SpeechRecognizer.ERROR_RECOGNIZER_BUSY) {
                       // Toast.makeText(context, "8", Toast.LENGTH_SHORT).show();
                        Toast.makeText(context, "Sparky is tired, please restart the App", Toast.LENGTH_LONG).show();

                    } else if (error == SpeechRecognizer.ERROR_SERVER) {
                        Toast.makeText(context, "9", Toast.LENGTH_SHORT).show();

                    }
                }

                @Override
                public void onResults(Bundle results) {
                    List<String> resultList = results.getStringArrayList(SpeechRecognizer.RESULTS_RECOGNITION);
                    if (resultList != null) {
                        recognisedText=resultList.get(0);
                    } else {
                        recognisedText = "Null Returned";
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
