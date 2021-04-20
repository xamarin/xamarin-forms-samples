//using System;
//using Xamarin.Forms;
//using ConceptDevelopment.Net.Cryptography;
//
//namespace Pontifex
//{
//	public class SolitairePageOld : ContentPage
//	{
//		Entry plaintext, key, ciphertext;
//		Label  heading, intro;
//		Button encrypt, decrypt; 
//		public SolitairePageOld ()
//		{
//			heading = new Label { Text = "Solitaire♠♥♦♣", Font = Font.SystemFontOfSize(NamedSize.Large) };
//			intro = new Label { Text = "Encryption algorithm from the book Cryptonomicon by Bruce Schneier. Enter the plain text and key to Encrypt, or the ciphertext and key to Decrypt.", Font = Font.SystemFontOfSize(NamedSize.Micro) };
//			plaintext = new Entry {Placeholder= "plaintext or ciphertext" };
//			key = new Entry {Placeholder= "key" };
//			encrypt = new Button { Text = "Encrypt" , HorizontalOptions = LayoutOptions.FillAndExpand,};
//			decrypt = new Button { Text = "Decrypt" , HorizontalOptions = LayoutOptions.FillAndExpand,};
//
//			encrypt.Clicked += (sender, e) => {
//				var ps = new PontifexSolitaire (key.Text);
//				ciphertext.Text = ps.Encrypt (plaintext.Text).Pad5() ;
//			};
//			decrypt.Clicked += (sender, e) => {
//				var ps = new PontifexSolitaire (key.Text);
//				ciphertext.Text = ps.Decrypt (plaintext.Text).Pad5() ;
//			};
//			ciphertext = new Entry { Placeholder = "enter above and encrypt or decrypt", BackgroundColor = Color.Gray };
//
//			Content = new StackLayout { 
//				Padding = new Thickness (5, 20, 0, 5),
//				Children = {
//					heading,
//					intro,
//					plaintext,
//					key,
//					new StackLayout {
//						Orientation = StackOrientation.Horizontal,
//						HorizontalOptions = LayoutOptions.FillAndExpand,
//						Children = {encrypt, decrypt}
//					},
//					ciphertext
//				}
//			};
//		}
//	}
//}
//
