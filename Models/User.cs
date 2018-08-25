using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ASBCLI.Financial;
using ASBLib.Exceptions;

namespace AltSrcBank.Models
{
	public class User
	{
		private string mEmail;
		private string mPassword;
		private readonly Regex RE_EMAIL = new Regex(".{1,100}@.{1,100}");
		private LinkedList<Transaction> mTrasactions;

		public LinkedList<Transaction> Transactions
		{
			get
			{
				return mTrasactions;
			}
		}

		public User(string email, string password)
		{
			validateEmail(email);
			mEmail = email;
			mPassword = password;
			mTrasactions = new LinkedList<Transaction>();
		}

		public void validateEmail(string email) {
			if (!RE_EMAIL.IsMatch(email)) {
				throw new ValidationException("Invalid email format");            
			}
		}

		public string getEmail()
		{
			return mEmail;
		}

		public void setEmail(string email) {
			validateEmail(email);
			this.mEmail = email;
		}

		public void setPassword(string password) {
			mPassword = password;
		}

		public bool passwordsMatch(string password) {
			return mPassword == password;
		}

		public void authenticate(string password) {
			if (!passwordsMatch(password)) {
				throw new AuthorizationException("Passwords do not match");
			}
		}

        public float GetBalance()
		{
			float total = 0.0F;
			foreach (var t in mTrasactions)
			{
				if (t.GetType() == typeof(Deposit))
					total += t.Amount;
				else if (t.GetType() == typeof(Withdrawal))
					total -= t.Amount;
			}
			return total;
		}
        
		public override bool Equals(Object obj) {
			return (obj.GetType() == this.GetType() &&
					((User)obj).getEmail() == mEmail);
		}

		public override int GetHashCode()
		{
			var hashCode = -663824591;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(mEmail);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(mPassword);
			return hashCode;
		}

		public int AddTransaction(Transaction transaction)
		{
			mTrasactions.AddLast(transaction);
			return 1;
		}
	}
}
