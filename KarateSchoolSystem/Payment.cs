using System;
using System.Collections.Generic;
using System.Text;

namespace KarateSchoolSystem
{
    /// <summary>
    /// Represents a payment made by a student.
    /// </summary>
    public class Payment : IReportable
    {
        public int PaymentId { get; }
        public decimal Amount { get; }
        public DateTime PaymentDate { get; }
        public string PaymentMethod { get; }
        public string Status { get; private set; }
        public Student Student { get; }

        private readonly IPaymentStrategy _paymentStrategy;

        public Payment(
            int paymentId,
            decimal amount,
            DateTime paymentDate,
            string paymentMethod,
            string status,
            Student student,
            IPaymentStrategy paymentStrategy)
        {
            if (paymentId <= 0)
            {
                throw new ArgumentException(
                    "Payment ID must be greater than zero.");
            }

            if (amount <= 0)
            {
                throw new ArgumentException(
                    "Payment amount must be greater than zero.");
            }

            if (paymentDate.Date > DateTime.Today)
            {
                throw new ArgumentException(
                    "Payment date cannot be in the future.");
            }

            if (string.IsNullOrWhiteSpace(paymentMethod))
            {
                throw new ArgumentException(
                    "Payment method is required.");
            }

            if (string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentException(
                    "Payment status is required.");
            }

            Student = student ??
                throw new ArgumentNullException(nameof(student));

            _paymentStrategy = paymentStrategy ??
                throw new ArgumentNullException(nameof(paymentStrategy));

            PaymentId = paymentId;
            Amount = amount;
            PaymentDate = paymentDate.Date;
            PaymentMethod = paymentMethod.Trim();
            Status = status.Trim();
        }

        public string ProcessPayment()
        {
            string result = _paymentStrategy.Process(Amount);
            Status = "Processed";
            Student.AddPayment(this);
            return result;
        }

        public string GenerateReport()
        {
            return $"Payment Report: {Student.FirstName} {Student.LastName}, " +
                   $"Amount: {Amount:C}, Status: {Status}";
        }

        public override string ToString()
        {
            return $"{PaymentDate:d} - {Amount:C} - " +
                   $"{PaymentMethod} - {Status}";
        }
    }
}
