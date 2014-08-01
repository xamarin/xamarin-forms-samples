/* **************************************** *
* PontifexSolitaire cryptography class
* 
* Author:    Craig Dunn
*            www.ConceptDevelopment.NET
*            August 2002
* 
* Solitaire encryption system by Bruce Schneier
* --http://www.counterpane.com/solitaire.html--
* https://www.schneier.com/solitaire.html
* 
* This C# implementation draws on portions of the existing Java source at
*     http://www.counterpane.com/soljava.zip
* It is _not_ intended as an efficient implementation of the algorithm, but
* just an interesting use of C#.
* 
* **************************************** */
using System;
using System.Collections;
using System.Diagnostics;
using ConceptDevelopment.Net.Collections;    // for Deck and Card

namespace ConceptDevelopment.Net.Cryptography {
		
	/// <summary>
	/// In Neal Stephenson's novel Cryptonomicon, the character Enoch Root describes 
	/// a cryptosystem code-named "Pontifex" to another character named 
	/// Randy Waterhouse, and later reveals that the steps of the algorithm 
	/// are intended to be carried out using a deck of playing cards. 
	/// These two characters go on to exchange several encrypted messages using 
	/// this system.
	/// Solitaire gets its security from the inherent randomness in a shuffled 
	/// deck of cards. By manipulating this deck, a communicant can create a 
	/// string of "random" letters that he then combines with his message. 
	/// Of course Solitaire can be simulated on a computer, but it is designed 
	/// to be implemented by hand. 
	/// </summary>
	public class PontifexSolitaire {
		/// <summary>Deck used to generate the keystream</summary>
		protected Deck _keyDeck;
		/// <summary>Contains the string of output ints from the keystream</summary>
		protected string _output="";

		/// <summary>Output contains the string of int values calculated
		/// as part of the key stream</summary>
		public string Output {
			get {return _output;}
		}

		/// <summary>Constructor: defaults to empty, ordered Deck</summary>
		public PontifexSolitaire () {
			_keyDeck = new Deck();
		}
		/// <summary>Constructor: specify Deck</summary>
		public PontifexSolitaire (Deck useDeck) {
			_keyDeck = useDeck;
		}
		/// <summary>Constructor: create Deck from key phrase.
		/// Creates a cipher with a key based on the 
		/// specified string.</summary>
		public PontifexSolitaire(string keyPhrase) {
			_keyDeck = new Deck();
			// Shuffle deck according to key phrase.
			if (keyPhrase.Length > 0) {
				char[] keyPhrasechar = keyPhrase.ToCharArray();
				Card tempCard;
				for (int i = 0; i < keyPhrase.Length; i++) {
					// The Solitaire 'spec' says "Perform the Solitaire operation, but 
					// instead of Step 5, do another count cut based on the first 
					// character of the passphrase" HOWEVER validating against the 
					// test-vectors REQUIRES that the cut is perfomed using the 
					// _current_ character and not always the first.
					int cut_size = GetCharValue(keyPhrasechar[i]); //[1]);
					if (cut_size > 0) {
						// Perform the Solitaire operation, but instead of Step 5.
						// do another count cut based on the current character
						// of the passphrase
						NextKeyStream();
						tempCard = _keyDeck.PeekBottom(1);    // check card on bottom
						_keyDeck.CutTop(cut_size);            // perform cut
						_keyDeck.MoveDown(_keyDeck.FindTop(tempCard), 
							_keyDeck.Count() - _keyDeck.FindTop(tempCard));
						// put the card back on the bottom
					} // if (cut_size > 0)
				} // for i
			}
		} // PontifexSolitaire(String)

		/// <summary>Performs the basic stream encryption operation
		//   and returns the next element of the key stream.</summary>
		/// <returns>int [ 1 ... 26 ] to be converted to a character</returns>
		public int NextKeyStream() {
			Card JokerA = new Card(CardSuit.Joker, CardFace.Ace);
			Card JokerB = new Card(CardSuit.Joker, CardFace.Two);

			// Step one: Move Joker A one card down.
			_keyDeck.MoveDown(_keyDeck.FindTop(JokerA));

			// Step two: Move Joker B two cards down.
			_keyDeck.MoveDown(_keyDeck.FindTop(JokerB), 2);
			Debug.WriteLine ("\n\nAfter Step 1,2:<br>" + _keyDeck.ToString());
			// Step three: Perform a triple cut.
			int iJokerAPos = _keyDeck.FindTop(JokerA);
			int iJokerBPos = _keyDeck.FindTop(JokerB);
			_keyDeck.TripleCut(Math.Min(iJokerAPos, iJokerBPos), 
				Math.Max (iJokerAPos, iJokerBPos));
			Debug.WriteLine ("\n\nAfter Step 3:<br>" + _keyDeck.ToString());
			// Step four: Perform a count cut (value of bottom card) from
			// the top (ensure the bottom card remains at the bottom).
			Card count = _keyDeck.PeekBottom(1);
			_keyDeck.CutTop(count.ID);
			_keyDeck.MoveDown(_keyDeck.FindTop(count), _keyDeck.Count() - _keyDeck.FindTop(count));
			Debug.WriteLine ("\n\nAfter Step 4:<br>" + _keyDeck.ToString());
			// Step five: Find the output card.
			// Peek at the top card to find it's value, then count down 
			// and peek at the card *after* that position (hence +1).
			Card output = _keyDeck.PeekTop( _keyDeck.PeekTop(1).ID + 1 );
			Debug.WriteLine ("\n\nAfter Step 5:<br>" + _keyDeck.ToString());
			// Step six: Convert output card to a number.
			int result = output.ID; //getCardValue(output);
			Debug.WriteLine ("\n\nAfter Step 6:<br>" + _keyDeck.ToString());

			Debug.WriteLine ("\n\n==== RESULT: " + result);
			// If Joker, repeat process
			if (result == 53 | result == 54) {
				_output += " (" + result + ")";
				return NextKeyStream();
			} else if (result > 26) {
				_output += " " + result;
				result = result - 26;
			}
			return result;
		} // NextKeyStream()

		/// <summary>Returns the plaintext result </summary>
		/// <param name="ciphertext">Text to decrypt</param>
		/// <returns>plaintext</returns>
		public String Decrypt(String ciphertext) {
			string buffer = "";
			char[] ciphertextchar =ciphertext.ToCharArray ();
			for (int i = 0; i < ciphertext.Length; i++) {
				int plain = GetCharValue(ciphertextchar[i]);
				if (plain > 0) {
					plain -= NextKeyStream();
					if (plain < 1) plain += 26;
					buffer += (GetValueChar(plain));
				} // if (plain > 0)
			} // for i

			return buffer.ToString();
		} // decrypt(String)

		/// <summary>Returns the ciphertext corresponding to the specified
		/// plaintext, according to the current key deck ordering.  Any
		/// string with a length that is not a multiple of five will be
		/// padded with the character 'X'.</summary>
		/// <param name="plaintext">text to encrypt</param>
		/// <returns>ciphertext</returns>
		public string Encrypt(string plaintext) {
			return Encrypt(plaintext, true);
		} // encrypt(String)

		/// <summary>Returns the ciphertext corresponding to the specified
		/// plaintext, according to the current key deck ordering.</summary>
		/// <param name="plaintext">text to encrypt</param>
		/// <param name="padded">whether to pad to multiple of 5 chars</param>
		/// <returns>ciphertext</returns>
		public string Encrypt(string plaintext, bool padded) {
			string buffer = "";
			char[] plaintextchar = plaintext.ToCharArray ();
			for (int i = 0; i < plaintext.Length; i++) {
				int cipher = GetCharValue(plaintextchar[i]) ;
				if (cipher > 0) {
					cipher += NextKeyStream();
					if (cipher > 26) cipher -= 26;
					buffer += (GetValueChar(cipher));
				} // if (cipher > 0)
			} // for i

			if (padded) {
				while (buffer.Length % 5 != 0) {
					buffer += (Encrypt("X", false));
				} // while buffer
			} // if (padded)
			return buffer.ToString();
		} // encrypt(String, boolean)


		protected static int GetCharValue(char c) {
			// Effect: return the position of the specified character in
			//   the alphabet regardless of case, or zero if the character
			//   is not in the Latin alphabet.
			if (c >= 'A' && c <= 'Z') {
				return (int)c - 'A' + 1;
			} else if (c >= 'a' && c <= 'z') {
				return (int)c - 'a' + 1;
			} else {
				return 0;
			} // if c
		} // getCharValue(char)

		protected static char GetValueChar(int v) {
			// Effect: return the position of the specified character in
			//   the alphabet regardless of case, or zero if the character
			//   is not in the Latin alphabet.
			if (v >= 1 && v <= 26) {
				return (char)((v - 1) + (int)'A');
			} else {
				return '*';
			} // if c
		} // getCharValue(char)
	}
} // namespace: Cryptography