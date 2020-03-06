using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void AddNumber2()
        {   
            int num1 = 23, num2 = 33;
            int result = 56;
            BankAccount account = new BankAccount("Mr. Bryan Walton",33);
            Assert.AreEqual(result, account.Add(num1, num2));
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Assert.Fail("The expected exception was not thrown.");
            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = -1.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            try
            {
                account.Debit(debitAmount);

            }
            catch (ArgumentOutOfRangeException ex)
            {
                //i expect to have exception here;done
                return;
            }

            Assert.Fail("The expected exception was not thrown.");


        }
    }
}
