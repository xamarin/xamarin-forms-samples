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
		private const int _numCards = 54;
		// IEnumerator: current position in array set to initial position
		private int _position = -1;

		/// <summary>Constructor: Create a deck of cards</summary>
		public Deck() {
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
		} // FindBottom(Card)

		/// <summary>Return the position of the specified card if it can
		///  be found in the deck.  Otherwise return a negative number.
		///  _cardArray[0] is the top of the Deck.</summary>
		/// <param name="findCard">Card</param>
		/// <returns>int [1, 54]</returns>
		public int FindTop(Card findCard) {
			int i = 0;
			while (i < _numCards ) {
				if (_cardArray[i] == findCard) {
					return i + 1;
				} // if (_cardArray[i] == findCard)
				i++;
			} // while (i <= UpperBound)
			return -1;
		} // FindTop(Card)

		/// <summary>Changes the order of the cards to a random
		/// pattern using the built-in random number generator.</summary>
		public void Shuffle() {
			Random rand = new Random();
			for (int i = 0; i < _cardArray.Length; i++) {
				int swap = rand.Next(0, 54);
				Card buffer = _cardArray[i];
				_cardArray[i] = _cardArray[swap];
				_cardArray[swap] = buffer;
			} // for i
		} // Shuffle()


		/// <summary>Swaps Card at specified position with the Card 
		/// below it. If the card is on the bottom of the deck, it is moved to the top 
		/// and then swapped with the one below it.</summary>
		/// <param name="position">Position in the Deck [1,54] 1 being the top Card</param>
		public void MoveDown(int cardPosition) {
			int position = cardPosition; //_numCards - cardPosition;
			if (position > 0 && position < _cardArray.Length) {
				Card buffer = _cardArray[position - 1];
				_cardArray[position - 1] = _cardArray[position];
				_cardArray[position] = buffer;
			} else if (position == _cardArray.Length ){ 
				// It's already at the bottom, need to move it to the top
				// Remembering that this doesn't actually constitute a 'MoveDown'
				Card lastCard = _cardArray[_cardArray.Length - 1];
				for (int j = (_cardArray.Length - 1); j >= 1; j--) {
					_cardArray[j] = _cardArray[j - 1];
				}
				_cardArray[0] = lastCard;
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
		/// [1, 54] 1 being to top Card</param>
		/// <param name="count">Number of times to move the Card down [ 1 ...]</param>
		public void MoveDown(int position, int count) {
			while (count-- > 0) {
				MoveDown(position);
				if (position == _numCards){
					position = 2; // MoveDown(_numCards) puts the Card in position 2
				} else {
					position++;
				}
			} // while (count > 0)
		} // MoveDown(int)
		
		/// <summary>Switch cards 1 to upperLimitBottom with 
		/// cards from upperLimitBottom + 1 to upperLimitTop.
		/// A upperLimitBottom of 1 or 54 will not change the deck.</summary>
		/// <param name="upperLimitBottom">The last bottom card.
		/// [1,54] are valid arguments</param>
		/// <param name="upperLimitTop">The last top card. 
		/// [1,54] are valid arguments </param>
		public void BasicCut(int upperLimitBottom, int upperLimitTop) {

            		if (upperLimitBottom < 1 || upperLimitBottom > 54 || upperLimitTop > 54) {
				throw new ArgumentOutOfRangeException(String.Format("toPosition and fromPosition must be in the range [1,54], you passed {0} and {1}", 
			upperLimitBottom, upperLimitTop));
            		}

            		if (upperLimitBottom < upperLimitTop) {
				Card[] buffer = new Card[upperLimitTop];

				// First move the lower cards to the top 
				// [0, upperLimitBotom) -> [upperLimitTop-upperLimitBottom, upperLimitTop)
				for (int i = 0; i < upperLimitBottom; i++) {
					buffer[i + (upperLimitTop - upperLimitBottom)] = _cardArray[i];
				}

				// Then move the upper cards down.
				// [upperLimitBottom, upperLimitTop) -> [0, upperLimitTop-upperLimitBottom)
				for (int i = upperLimitBottom; i < upperLimitTop; i++) {
					buffer[i - upperLimitBottom] = _cardArray[i];
				}

				// Then replace the range in the original deck.
				for (int i = 0; i < upperLimitTop; i++) {
					_cardArray[i] = buffer[i];
				}
			} // if positionInDeck
		} // BasicCut(int, int)

		/// <summary>Pull all cards between 1 and count (inclusive) and move them to the bottom of the deck</summary>
		/// <param name="size">[1,54] where 1 is the top of the Deck</param>
		public void CutTop(int count) {
			if (count < 1 || count > 54) {
				throw new ArgumentOutOfRangeException("Count must be between 1 and 53");
			}
            		BasicCut(count, _numCards);
		} // cutTop(int)

		/// <summary>Pull count cards from bottom and move them to the top of the deck</summary>
		/// <param name="count">[1,54] where 1 is the bottom of the Deck</param>
		public void CutBottom(int count) {
			if (count < 1 || count > 54) {
				throw new ArgumentOutOfRangeException("Count must be between 1 and 53");
			}
			CutTop(_numCards - count);
		} // cutBottom(int)

		/// <summary>Swaps the cards above the highest of the
		/// specified positions with cards below the lowest.</summary>
		/// <param name="low">[1,54]</param>
		/// <param name="high">[2,54] && greater than low</param>
		public void TripleCut(int low, int high) {
			if (low < high) {
				if ((1 < low)) {
					BasicCut(low - 1, high);
				}
				if (high < _numCards) {
					CutTop(high);
				}
			} else {
				throw new ArgumentException("0 < low <= high <= 54");
			}
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

