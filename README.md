# Xamarin.Forms Speech Recognition issue

https://stackoverflow.com/questions/68930859/text-to-speech-playback-has-very-low-volume-after-trying-speech-to-text-in-xamar 

## Issue

After Speech-To-Text has worked, Text-To-Speech volume is reduced significantly and not automatically returned to the volume setting before the Speech-To-Text happened.

See step 6 below. Once Secret phrase is detected, speech recognition stops and Text-To-Speech works, but the volume is much lower than previously. I basically want the volume to be the pre Speech-To-Text device volume. 

## steps to reproduce:

1. Build and run the solution.
2. Press the 'Text-To-Speech without Speech-To-Text' button.
3. Notice how volume is in line with device audio 
4. Press the transcribe button.
5. Say some arbitrary voice commands (e.g. Hello World, hi, etc.). Notice how your speech is being recognised and shown in the transcribedText label in MainPage.xaml. 
6. Now say "secret phrase". As you can see in MainPage.xaml.cs lines 100-116, once the secret phrase is detected, speech recognition should stop and a different string variable (in this case, the string variable called 'TextForTextToSpeechAfterSpeechToText' on line 108) should be played. Once the success string has finished playing, speech recognition may commence again. 

