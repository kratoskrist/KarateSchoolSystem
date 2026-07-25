using System;
using System.Collections.Generic;
using System.Text;

namespace KarateSchoolSystem
{
    /// <summary>
    /// Processes a cash payment.
    /// </summary>
    public class CashPaymentStrategy : IPaymentStrategy
    {
        public string Process(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException(
                    "Payment amount must be greater than zero.");
            }

            return $"Cash payment of {amount:C} processed.";
        }
    }
}
