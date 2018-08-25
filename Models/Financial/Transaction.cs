using System;
using AltSrcBank.Models;
using ASBLib.Exceptions;

namespace ASBCLI.Financial
{
    public abstract class Transaction
    {
		private float mAmount;
		private DateTime mTimestamp;

		public DateTime Timestamp
		{
			get
			{
				return mTimestamp;
			}
		}

		public Transaction(float amount)
        {
			if (amount < 0)
				throw new ValidationException("Amount must be greater than 0.");
			mAmount = amount;
			mTimestamp = DateTime.Now;
		}

		public Transaction(float amount, DateTime timestamp) : this(amount)
		{
			mTimestamp = timestamp;
		}

        public float Amount
        {
            get
            {
                return mAmount;
            }
        }
	}
}
