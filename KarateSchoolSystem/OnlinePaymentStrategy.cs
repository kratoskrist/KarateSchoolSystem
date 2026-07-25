using System;
using System.Collections.Generic;
using System.Text;

namespace KarateSchoolSystem
{
    /// <summary>
    /// Processes an online payment.
    /// </summary>
    public class OnlinePaymentStrategy : IPaymentStrategy
    {
        public string Process(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(
                    "Payment amount must be greater than zero.");
            }

            return $"Online payment of {amount:C} processed.";
        }
    }
}
