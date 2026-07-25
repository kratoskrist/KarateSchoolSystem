using System;
using System.Collections.Generic;
using System.Text;

namespace KarateSchoolSystem
{
    /// <summary>
    /// Processes a card payment.
    /// </summary>
    public class CardPaymentStrategy : IPaymentStrategy
    {
        public string Process(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(
                    "Payment amount must be greater than zero.");
            }

            return $"Card payment of {amount:C} processed.";
        }
    }
}
