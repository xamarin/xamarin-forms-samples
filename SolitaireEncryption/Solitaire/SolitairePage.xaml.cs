using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ConceptDevelopment.Net.Cryptography;

namespace Solitaire
{	
	public partial class SolitairePage : ContentPage
	{	
		public SolitairePage ()
		{
			InitializeComponent ();
		}

		public async void EncryptClicked (object sender, EventArgs e) {
			if (!ValidInputs()) {
				await DisplayAlert ("Missing input", "You must enter plaintext/ciphertext and the key", "OK");
				return;
			}
			var ps = new PontifexSolitaire (key.Text);
			ciphertext.Text = ps.Encrypt (plaintext.Text).Pad5() ;

			// was for contest (now closed) http://blog.xamarin.com/xamarin-acquires-petzold/
			//Tweet.Code = ciphertext.Text;
		}

		public async void DecryptClicked (object sender, EventArgs e) {
			if (!ValidInputs()) {
				await DisplayAlert ("Missing input", "You must enter plaintext/ciphertext and the key", "OK");
				return;
			}
			var ps = new PontifexSolitaire (key.Text);
			ciphertext.Text = ps.Decrypt (plaintext.Text).Pad5() ;

			// was for contest (now closed) http://blog.xamarin.com/xamarin-acquires-petzold/
			//Tweet.Code = ciphertext.Text;
		}

		// input validation
		bool ValidInputs () {
			return ! (String.IsNullOrWhiteSpace(key.Text) || String.IsNullOrWhiteSpace(plaintext.Text));
		}
	}
}

