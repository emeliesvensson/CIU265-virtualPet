package voicerecognition.example.com.voicerecognition;

import android.content.Intent;
import android.speech.RecognitionListener;
import android.speech.RecognizerIntent;
import android.speech.SpeechRecognizer;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import java.util.List;

public class MainActivity extends AppCompatActivity {

    private SpeechRecognizer speechRecognizer = null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        initializeSpeechRecognizer();

        final Button button = (Button) this.findViewById(R.id.button);

        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (button.getText().equals(getResources().getString(R.string.recognize_voice))) {
                    Intent intent = new Intent();
                    intent.putExtra(RecognizerIntent.EXTRA_LANGUAGE, "sv-SE");
                    intent.putExtra("android.speech.extra.EXTRA_ADDITIONAL_LANGUAGES", new String[]{});
                    speechRecognizer.startListening(intent);
                    button.setText(R.string.stop_recognizing);
                } else {
                    speechRecognizer.stopListening();
                    button.setText(R.string.recognize_voice);
                }
            }
        });
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }


    public void initializeSpeechRecognizer() {
        if (speechRecognizer == null) {
            speechRecognizer = SpeechRecognizer.createSpeechRecognizer(this);
            final TextView textView = (TextView) this.findViewById(R.id.text_field);
            speechRecognizer.setRecognitionListener(new RecognitionListener() {

                @Override
                public void onReadyForSpeech(Bundle params) {
                    textView.setText(R.string.ready_speak);
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
                        textView.setText("Audio error");
                    } else if (error == SpeechRecognizer.ERROR_SPEECH_TIMEOUT) {
                        textView.setText("Speech timeout error");
                    } else if (error == SpeechRecognizer.ERROR_CLIENT) {
                        textView.setText("Client error");
                    } else if (error == SpeechRecognizer.ERROR_INSUFFICIENT_PERMISSIONS) {
                        textView.setText("Insuficient permissions error");
                    } else if (error == SpeechRecognizer.ERROR_NETWORK) {
                        textView.setText("Network error");
                    } else if (error == SpeechRecognizer.ERROR_NETWORK_TIMEOUT) {
                        textView.setText("Network timeout error");
                    } else if (error == SpeechRecognizer.ERROR_NO_MATCH) {
                        textView.setText("No match error");
                    } else if (error == SpeechRecognizer.ERROR_RECOGNIZER_BUSY) {
                        textView.setText("Recognizer busy error");
                    } else if (error == SpeechRecognizer.ERROR_SERVER) {
                        textView.setText("Server error");
                    }
                }

                @Override
                public void onResults(Bundle results) {
                    List<String> resultList = results.getStringArrayList(SpeechRecognizer.RESULTS_RECOGNITION);
                    if (resultList != null) {
                        textView.setText(resultList.get(0));
                    } else {
                        textView.setText(R.string.null_returned);
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
