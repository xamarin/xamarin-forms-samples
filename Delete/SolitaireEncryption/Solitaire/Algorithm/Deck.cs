using System;
using System.Collections;


namespace ConceptDevelopment.Net.Collections {
	/// <summary>Represents a deck of playing cards (including two Jokers).
	/// Current implementation is specific to requirements for 
	/// 'Solitaire' cryptography algorithm.</summary>
	public class Deck : IEnumerable, IEnumerator {
		/// <summary>Array of Card structs that represents the Deck.
		/// Position 0 is the _bottom_ of the deck, </summary>
		private Card[] _cardArray;
		private int _numCards;
		// IEnumerator: current position in array set to initial position
		private int _position = -1;

		/// <summary>Constructor: Create a deck of cards</summary>
		public Deck() {
			_numCards = 54;
			_cardArray = new Card[_numCards];
			for (int suits = 3; suits >= 0; suits--) {
				for (int faces = 12; faces >= 0; faces--){
					_cardArray[(suits * 13) + faces] = new Card(suits, faces + 1);
				}
			}
			// Add the jokers to the end of the deck
			_cardArray[52] = new Card(CardSuit.Joker, CardFace.Ace);
			_cardArray[53] = new Card(CardSuit.Joker, CardFace.Two);
		}
		/// <summary>Constructor: Create a deck of cards (reverse sort order)</summary>
		public Deck(bool reverseOrder) { 
			_numCards = 54;
			_cardArray = new Card[_numCards];
			for (int suits = 0; suits <= 3; suits++) {
				for (int faces = 0; faces <= 12; faces++){
					_cardArray[(suits * 13) + faces] = new Card(suits, faces + 1);
				}
			}
			// Add the jokers to the end of the deck
			_cardArray[52] = new Card(CardSuit.Joker, CardFace.Ace);
			_cardArray[53] = new Card(CardSuit.Joker, CardFace.Two);
		}
		/// <summary>Return the number of Cards in the Deck</summary>
		/// <returns>Number of Cards in the Deck</returns>
		public int Count() {
			return _numCards;
		} // count()

		/// <summary>View the card on the top of the deck</summary>
		/// <param name="position">[ 1 ... 54 ] 1 being the top card</param>
		/// <returns>First face-down Card on the Deck</returns>
		public Card PeekTop(int position) {
			if (position > 0 && position <= _numCards) {
				return _cardArray[position - 1];
			} else {
				throw new ArgumentOutOfRangeException("position", 
					"Position '" + position + "' exceeds size of Deck '" + _numCards + "'.");
			}
		} // PeekTop(int)

		/// <summary>View the card on the bottom of the deck</summary>
		/// <param name="position">[ 1 ... 54 ] 1 being the bottom card</param>
		/// <returns>Last face-down Card on the Deck</returns>
		public Card PeekBottom(int position) {
			if (position > 0 && position <= _numCards) {
				// _numCards less one, since it's the number of elements,
				// and not the array index. Since position can be zero
				// we must subtract one to avoid a OutOfRange exception.
				return _cardArray[(_numCards) - position ];
			} else {
				throw new ArgumentOutOfRangeException("position", 
					"Position '" + position + "' exceeds size of Deck '" + _numCards + "'.");
			}
		} // PeekBottom(int)

		/// <summary>Return the position of the specified card if it can
		///  be found in the deck.  Otherwise return a negative number.
		///  _cardArray[53] is the bottom of the Deck.</summary>
		/// <param name="findCard">Card</param>
		/// <returns>int [1 .. 54]</returns>
		public int FindBottom(Card findCard) {
			return (_numCards - FindTop(findCard)) + 1;    // not base 0
		} // FindTop(Card)

		/// <summary>Return the position of the specified card if it can
		///  be found in the deck.  Otherwise return a negative number.
		///  _cardArray[0] is the top of the Deck.</summary>
		/// <param name="findCard">Card</param>
		/// <returns>int [1 .. 54]</returns>
		public int FindTop(Card findCard) {
			int i = 0;
			while (i < _numCards ) {
				if (_cardArray[i] == findCard) {
					return i + 1;
				} // if (_cardArray[i] == findCard)
				i++;
			} // while (i <= UpperBound)
			return -1;
		} // FindBottom(Card)

		/// <summary>Changes the order of the cards to a random
		/// pattern using the built-in random number generator.</summary>
		public void Shuffle() {
			Random rand = new Random();
			for (int i = 0; i < _cardArray.GetUpperBound(0); i++) {
				int swap = rand.Next (0, 53); 
				Card buffer = _cardArray[i];
				_cardArray[i] = _cardArray[swap];
				_cardArray[swap] = buffer;
			} // for i
		} // Shuffle()


		/// <summary>Swaps Card at specified position with the Card 
		/// below it.</summary>
		/// <param name="position">Position in the Deck
		/// [ 1 ... 54 ] 1 being the top Card</param>
		public void MoveDown(int cardPosition) {
			int position = cardPosition; //_numCards - cardPosition;
			if (position > 0 && position < _cardArray.Length) {
				Card buffer = _cardArray[position - 1];
				_cardArray[position - 1] = _cardArray[position];
				_cardArray[position] = buffer;
			} else if (position == _cardArray.Length ){
				// It's already at the bottom, need to move it to the top
				// Remembering that this doesn't actually constitute a 'MoveDown'
				Card buffer = _cardArray[_cardArray.Length - 1];
				for (int j = (_cardArray.Length - 1); j >= 1; j--) {
					_cardArray[j] = _cardArray[j - 1];
				}
				_cardArray[0] = buffer;
				// now it's on the top, perform the MoveDown
				MoveDown(1);
			} else {
				throw new ArgumentOutOfRangeException("Out of range", 
					"Position " + position.ToString() + " is invalid.");
			}

		}
		/// <summary>Swaps Card at specified position with the Card 
		/// below it. Repeats 'count' times.</summary>
		/// <param name="position">Position in the Deck 
		/// [ 1 ... 54 ] 1 being to top Card</param>
		/// <param name="count">Number of times to move the Card down [ 1 ...]</param>
		public void MoveDown(int position, int count) {
			while (count > 0) {
				MoveDown(position);
				if (position == _numCards){
					position = 2; // MoveDown(_numCards) puts the Card in position 1
					// so must skip this and go to position 2.
				} else {
					position++;
				}
				count--;
			} // while (count > 0)
		} // MoveDown(int)

		/// <summary>Switch cards below the specified position with 
		/// the cards above, up to the specified limit.
		/// A position of 1 or limit will not change the deck.</summary>
		/// <param name="fromPosition">Where to start the cut.
		/// 0 or 54 will not cause any cut.</param>
		/// <param name="toPosition">Where to stop the cut</param>
		public void BasicCut(int fromPosition, int toPosition) {
			if ((fromPosition > 0) && (fromPosition < toPosition)) {
				// number of elements must be +1 because 
				// position 9 requires an array size 
				// of 10 (don't forget position 0).
				Card[] buffer = new Card[toPosition+1];
				// First move the lower cards to the top 
				// [0 .. from_position] -> [to_position-from_position ... ]
				for (int i = 0; i < fromPosition; i++) {
					buffer[i + (toPosition - fromPosition)] = _cardArray[i];
				} // for i

				// Then move the upper cards down.
				// [ from_position .. to_position ] -> [ 0 .. ]
				for (int i = fromPosition; i < toPosition; i++) {
					buffer[i - fromPosition] = _cardArray[i];
				} // for i

				// Then replace the range in the original deck.
				for (int i = 0; i < toPosition; i++) {
					_cardArray[i] = buffer[i];
				} // for i
			} // if positionInDeck
		} // BasicCut(int, int)

		/// <summary>Switch cards below the specified position with the
		/// cards above.
		/// A size of zero or marker will not change the deck.</summary>
		/// <param name="size">[ 1 .. 54 ] where 1 is the top of the Deck</param>
		public void CutTop(int size) {
			BasicCut(size, _numCards);
			//BasicCut(_numCards - size, _numCards - 1);
		} // cutTop(int)

		/// <summary>Switch cards below the specified position with the
		/// cards above.
		/// A size of zero or marker will not change the deck.</summary>
		/// <param name="size">[ 1 .. 54 ] where 1 is the bottom of the Deck</param>
		public void CutBottom(int size) {
			BasicCut(_numCards - size, _numCards);
		} // cutBottom(int)

		/// <summary>Swaps the cards above the highest of the
		/// specified positions with cards below the lowest.</summary>
		/// <param name="low">[ 1 .. 54 ]</param>
		/// <param name="high">[ 1 .. 54 ] > low</param>
		public void TripleCut(int low, int high) {
			// Requires: 0 < low <= high <= this.Count()
			if ((0 < low) && (low <= high) && (high <= _numCards)) {
				BasicCut(low - 1, high);
				BasicCut(high, _numCards);    // must subtract to make 53
			} // if low && high
		} // tripleCut();


		/// <summary>ToHtml() function</summary>
		/// <returns>HTML representation of a Deck (9 rows of 6 cards)</returns>
		public string ToHtml() {
			string sReturn = "";
			for (int i = 0; i < _cardArray.Length ; i++) {
				sReturn += _cardArray[i].ToHtml() + " ";
				sReturn += ((i+1) % 6 == 0 ? "<br>" : "");

			}
			return (sReturn);
		}
		/// <summary>Overridden ToString() function</summary>
		/// <returns>String representation of a Deck</returns>
		public override string ToString() {
			string sReturn = "";
			for (int i = 0; i < _cardArray.Length ; i++) {
				sReturn += _cardArray[i].ToString() + " ";
				sReturn += ((i+1) % 13 == 0 ? "\n" : "");
			}
			return (sReturn);
		}

		/// <summary>Implement IEnumerable.GetEnumerator</summary>
		public IEnumerator GetEnumerator() {
			return (IEnumerator)this;
		}

		/// <summary>Implement IEnumerator.MoveNext</summary>
		/// <returns>Whether there is another Card in this Deck [ true | false ]</returns>
		public bool MoveNext() {
			_position++;
			if (_position < _cardArray.Length) {
				return true;
			} else {
				return false;
			}
		}
		/// <summary>Implement IEnumerator.Reset</summary>
		public void Reset() {
			_position = -1;
		}
		/// <summary>Implement IEnumerator.Current</summary>
		public object Current {
			get{return _cardArray[_position];}
		}

	} // class: Deck
}

