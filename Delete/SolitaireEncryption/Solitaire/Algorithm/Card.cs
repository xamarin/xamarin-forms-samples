using System;
using System.Collections;


namespace ConceptDevelopment.Net.Collections {

	/// <summary>Represents a playing card (including Jokers)</summary>
	public struct Card {
		public CardSuit suit;
		public CardFace face;

		/// <summary>Constructor (using Card types)</summary>
		/// <param name="suit">CardSuit enum [ 0 ... 3 ]</param>
		/// <param name="face">CardFace enum [ 1 ... 13 ]</param>
		public Card(CardSuit suit, CardFace face) {
			this.suit = suit;
			this.face = face;
		}
		/// <summary>Constructor (using int types)</summary>
		/// <param name="suit">CardSuit enum [ 0 ... 3 ]</param>
		/// <param name="face">CardFace enum [ 1 ... 13 ]</param>
		public Card(int suit, int face) {
			this.suit = (CardSuit)suit;
			this.face = (CardFace)face;
		}
		/// <summary>ID of card [ 1 .. 53 ]</summary>
		public int ID {
			get{
				int iCalcID = (int)suit * 13 + (int)face;
				return iCalcID == 54 ? 53 : iCalcID;
			}
		}
		public bool isBlack  {
			get {
				if (suit == CardSuit.Clubs || suit == CardSuit.Spades) {
					return true;
				} else {
					return false;
				}
			}
		}
		public bool isRed  {
			get {
				if (suit == CardSuit.Hearts || suit == CardSuit.Diamonds) {
					return true;
				} else {
					return false;
				}
			}
		}
		public bool isJoker {
			get {
				if (suit == CardSuit.Joker) {
					return true;
				} else {
					return false;
				}
			}
		}

		/// <summary>Overridden equality operator</summary>
		/// <param name="arg1">Card</param>
		/// <param name="arg2">Card</param>
		/// <returns>Result of comparing two Cards</returns>
		/// <seealso cref="bool" />
		public static bool operator ==(Card arg1, Card arg2) {
			return (arg1.suit         == arg2.suit
				&& arg1.face        == arg2.face);
		}
		/// <summary>Overridden inequality operator</summary>
		/// <param name="arg1">Card</param>
		/// <param name="arg2">Card</param>
		/// <returns>Result of comparing two Cards</returns>
		/// <seealso cref="bool" />
		public static bool operator !=(Card arg1, Card arg2) {
			return (arg1.suit         != arg2.suit
				|| arg1.face        != arg2.face);
		}

		/// <summary>Overridden Equals() method uses overloaded == operator
		/// (Compiler warning if not defined)</summary>
		/// <param name="o">object</param>
		/// <returns>bool</returns>
		public override bool Equals(object o) {
			try {    // requires overloaded == operator
				return (bool) (this == (Card) o);
			}
			catch {
				return false;
			}
		}
		/// <summary>Overridden GetHashCode() method
		/// (Compiler warning if not defined)</summary>
		/// <returns>int</returns>
		public override int GetHashCode() {
			//HACK: There must be a better HashCode !!!
			return (base.GetHashCode());
		}

		/// <summary>Overridden ToString() function</summary>
		/// <returns>String representation of a Card</returns>
		public override string ToString() {
			return ("[" + suit.ToString() + face.ToString() + "]");
		}

		/// <summary>ToHtml() function</summary>
		/// <returns>HTML representation of a Card</returns>
		public string ToHtml() {
			string sColor="";
			if (this.isRed) {
				sColor = "<font color=red>";
			} else if (this.isBlack) {
				sColor = "<font color=black>";
			} else {
				sColor = "<font color=blue>";
			}

			return (sColor + "[" + suit.ToString() + face.ToString() + "]</font>");
		}
	} // struct: Card
}

