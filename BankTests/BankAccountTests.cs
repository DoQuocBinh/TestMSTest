using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        [DataSource("Provider=SQLOLEDB;Data Source=.;Integrated Security=SSPI;initial catalog=DBTest;Persist Security Info=False", "TestSum")]
        [TestMethod]
        public void Add_NormalCase()
        {
            var target = new BankAccount("Mr. Bryan Walton", 300);

            // Access the data
            int x = Convert.ToInt32(TestContext.DataRow["FirstNumber"]);
            int y = Convert.ToInt32(TestContext.DataRow["SecondNumber"]);
            int expected = Convert.ToInt32(TestContext.DataRow["Sum"]);
            int actual = target.Add(x, y);
            Assert.AreEqual(expected, actual,
                "x:<{0}> y:<{1}>",
                new object[] { x, y });
        }


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
            Assert.AreEqual(expected, actual, "Account not debited correctly");
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
        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = 4.55;
            double expected = 16.54;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, "Account not debited correctly");
        }

        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Assert.Fail("The expected exception was not thrown.");
            //Arrange
            double beginningBalance = 11.99;
            double creditAmount = -1.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            try
            {
                account.Credit(creditAmount);

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
