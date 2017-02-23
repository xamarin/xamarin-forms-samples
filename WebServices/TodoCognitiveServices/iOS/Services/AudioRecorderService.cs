using System;
using AVFoundation;
using Foundation;
using Xamarin.Forms;
using Todo.iOS;

[assembly: Dependency(typeof(AudioRecorderService))]
namespace Todo.iOS
{
	public class AudioRecorderService : IAudioRecorderService
	{
		AVAudioRecorder recorder;
		NSError error;
		NSUrl url;
		NSDictionary settings;

		public void StartRecording()
		{
			if (recorder == null)
			{
				InitializeRecorder();
			}
			recorder.Record();
		}

		public void StopRecording()
		{
			if (recorder == null)
			{
				throw new Exception("Start recording first.");
			}
			recorder.Stop();
		}

		void InitializeRecorder()
		{
			var audioSession = AVAudioSession.SharedInstance();
			var err = audioSession.SetCategory(AVAudioSessionCategory.PlayAndRecord);
			if (err != null)
			{
				Console.WriteLine("audioSession: {0}", err);
				return;
			}

			err = audioSession.SetActive(true);
			if (error != null)
			{
				Console.WriteLine("audioSession: {0}", err);
				return;
			}

			var localStorage = PCLStorage.FileSystem.Current.LocalStorage.Path;
			string audioFilePath = localStorage + "/Todo.wav";
			Console.WriteLine("Audio file path: " + audioFilePath);

			url = NSUrl.FromFilename(audioFilePath);

			var values = new NSObject[]
			{
				NSNumber.FromFloat (8000.0f), // Sample Rate
  				NSNumber.FromInt32 ((int)AudioToolbox.AudioFormatType.LinearPCM), // AVFormat
   				NSNumber.FromInt32 (1), // Channels
    			NSNumber.FromInt32 (16), // PCMBitDepth
    			NSNumber.FromBoolean (false), // IsBigEndianKey
    			NSNumber.FromBoolean (false) // IsFloatKey
			};

			var keys = new NSObject[]
			{
				AVAudioSettings.AVSampleRateKey,
				AVAudioSettings.AVFormatIDKey,
				AVAudioSettings.AVNumberOfChannelsKey,
				AVAudioSettings.AVLinearPCMBitDepthKey,
				AVAudioSettings.AVLinearPCMIsBigEndianKey,
				AVAudioSettings.AVLinearPCMIsFloatKey
			};

			settings = NSDictionary.FromObjectsAndKeys(values, keys);
			recorder = AVAudioRecorder.Create(url, new AudioSettings(settings), out error);
			recorder.PrepareToRecord();
		}
	}
}
