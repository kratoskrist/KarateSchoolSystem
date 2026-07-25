using System;
using System.Collections.Generic;
using System.Text;

namespace KarateSchoolSystem
{
    /// <summary>
    /// Defines a strategy for processing a payment
    /// </summary>
    public interface IPaymentStrategy
    {
        string Process(decimal amount);
    }
}
