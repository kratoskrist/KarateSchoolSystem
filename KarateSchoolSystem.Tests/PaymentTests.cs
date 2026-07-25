using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KarateSchoolSystem.Tests
{
    [TestClass]
    public class PaymentTests
    {
        [TestMethod]
        public void Constructor_ValidData_CreatesPayment()
        {
            Payment payment = CreatePayment();

            Assert.AreEqual(75m, payment.Amount);
            Assert.AreEqual("Pending", payment.Status);
        }

        [TestMethod]
        public void Constructor_InvalidId_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Payment(
                    0,
                    75m,
                    DateTime.Today,
                    "Cash",
                    "Pending",
                    TestData.CreateStudent(),
                    new CashPaymentStrategy()));
        }

        [TestMethod]
        public void Constructor_NegativeAmount_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Payment(
                    1,
                    -1m,
                    DateTime.Today,
                    "Cash",
                    "Pending",
                    TestData.CreateStudent(),
                    new CashPaymentStrategy()));
        }

        [TestMethod]
        public void Constructor_FutureDate_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Payment(
                    1,
                    75m,
                    DateTime.Today.AddDays(1),
                    "Cash",
                    "Pending",
                    TestData.CreateStudent(),
                    new CashPaymentStrategy()));
        }

        [TestMethod]
        public void Constructor_BlankMethod_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Payment(
                    1,
                    75m,
                    DateTime.Today,
                    "",
                    "Pending",
                    TestData.CreateStudent(),
                    new CashPaymentStrategy()));
        }

        [TestMethod]
        public void Constructor_BlankStatus_ThrowsArgumentException()
        {
            Assert.ThrowsExactly<ArgumentException>(() =>
                new Payment(
                    1,
                    75m,
                    DateTime.Today,
                    "Cash",
                    "",
                    TestData.CreateStudent(),
                    new CashPaymentStrategy()));
        }

        [TestMethod]
        public void Constructor_NullStudent_ThrowsArgumentNullException()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() =>
                new Payment(
                    1,
                    75m,
                    DateTime.Today,
                    "Cash",
                    "Pending",
                    null!,
                    new CashPaymentStrategy()));
        }

        [TestMethod]
        public void Constructor_NullStrategy_ThrowsArgumentNullException()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() =>
                new Payment(
                    1,
                    75m,
                    DateTime.Today,
                    "Cash",
                    "Pending",
                    TestData.CreateStudent(),
                    null!));
        }

        [TestMethod]
        public void ProcessPayment_ValidPayment_ChangesStatus()
        {
            Student student = TestData.CreateStudent();

            Payment payment = new Payment(
                1,
                75m,
                DateTime.Today,
                "Cash",
                "Pending",
                student,
                new CashPaymentStrategy());

            string result = payment.ProcessPayment();

            Assert.AreEqual("Processed", payment.Status);
            Assert.AreEqual(1, student.Payments.Count);
            StringAssert.Contains(result, "Cash payment");
        }

        [TestMethod]
        public void GenerateReport_ReturnsPaymentReport()
        {
            Payment payment = CreatePayment();

            StringAssert.Contains(
                payment.GenerateReport(),
                "Payment Report");
        }

        [TestMethod]
        public void ToString_ReturnsMeaningfulText()
        {
            Payment payment = CreatePayment();

            StringAssert.Contains(payment.ToString(), "Pending");
        }

        [TestMethod]
        public void CashStrategy_ValidAmount_ReturnsMessage()
        {
            CashPaymentStrategy strategy = new();

            StringAssert.Contains(strategy.Process(50m), "Cash");
        }

        [TestMethod]
        public void CardStrategy_ValidAmount_ReturnsMessage()
        {
            CardPaymentStrategy strategy = new();

            StringAssert.Contains(strategy.Process(50m), "Card");
        }

        [TestMethod]
        public void OnlineStrategy_ValidAmount_ReturnsMessage()
        {
            OnlinePaymentStrategy strategy = new();

            StringAssert.Contains(strategy.Process(50m), "Online");
        }

        [TestMethod]
        public void CashStrategy_InvalidAmount_ThrowsException()
        {
            CashPaymentStrategy strategy = new();

            Assert.ThrowsExactly<ArgumentException>(() =>
                strategy.Process(0));
        }

        [TestMethod]
        public void CardStrategy_InvalidAmount_ThrowsException()
        {
            CardPaymentStrategy strategy = new();

            Assert.ThrowsExactly<ArgumentException>(() =>
                strategy.Process(0));
        }

        [TestMethod]
        public void OnlineStrategy_InvalidAmount_ThrowsException()
        {
            OnlinePaymentStrategy strategy = new();

            Assert.ThrowsExactly<ArgumentException>(() =>
                strategy.Process(0));
        }

        private static Payment CreatePayment()
        {
            return new Payment(
                1,
                75m,
                DateTime.Today,
                "Cash",
                "Pending",
                TestData.CreateStudent(),
                new CashPaymentStrategy());
        }
    }
}
