using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace AnkhMorporkApp.Tests
{
    [TestClass]
    public class PlayerTests
    {
        private Player player;
        private decimal initialBalance;

        [TestInitialize]
        public void SetUp()
        {
            initialBalance = 10;
            player = new Player(initialBalance);
        }
        
        [DataTestMethod]
        [DataRow(2)]
        [DataRow(9)]
        [DataRow(10)]
        public void IsOutOfMoney_IfBalanceIsGraterThanInput_ReturnFalse(decimal input)
        {
            var result = player.IsOutOfMoney(input);

            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow(20)]
        [DataRow(100)]
        [DataRow(35)]
        public void IsOutOfMoney_IfBalanceIsLessThanInput_ReturnTrue(decimal input)
        {
            var result = player.IsOutOfMoney(input);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetMoney_InputSum_ReturnBalanceWithAddedSum()
        {
            var amount = 2;
            var valid = false;

            player.GetMoney(amount,ref valid);
            var newBalance = initialBalance + amount;

            Assert.IsTrue(valid);
            Assert.AreEqual(newBalance, 12);
        }

        [TestMethod]
        public void GiveMoney_WithdrawSum_ReturnBalanceWithWithdrawSum()
        {
            var amount = 2;
            var valid = false;

            player.GiveMoney(amount, ref valid);
            var newBalance = initialBalance - amount;

            Assert.IsTrue(valid);
            Assert.AreEqual(newBalance, 8);
        }
        
        [TestMethod]
        public void Skip_ChoseToSkipAssassin_ShouldReturnFalse()
        {
            Assassin assassin = new Assassin("name", 11, 20, false);

            player.Skip(assassin);

            Assert.IsFalse(player.IsAlive);
        }

        [TestMethod]
        public void Skip_ChoseToSkipBeggar_ShouldReturnFalse()
        {
            Beggar beggar = new Beggar("practice", 11);

            player.Skip(beggar);

            Assert.IsFalse(player.IsAlive);
        }

        [TestMethod]
        public void Skip_ChoseToSkipThieve_ShouldReturnFalse()
        {
            Thieve thieve = new Thieve();

            player.Skip(thieve);

            Assert.IsFalse(player.IsAlive);
        }

        [TestMethod]
        public void Skip_ChoseToSkipFool_ShouldReturnTrue()
        {
            Fool fool = new Fool("practice", 11);

            player.Skip(fool);

            Assert.IsTrue(player.IsAlive);
        }

        [DataTestMethod]
        [DataRow(2)]
        [DataRow(9)]
        [DataRow(10)]
        public void EnteredSumIsCorrect_IfBalanceIsGraterThanInput_ReturnTrue(decimal input)
        {
            var result = player.EnteredSumIsCorrect(input);

            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow(20)]
        [DataRow(100)]
        [DataRow(35)]
        public void EnteredSumIsCorrect_IfBalanceIsLessThanInput_ReturnFalse(decimal input)
        {
            var result = player.EnteredSumIsCorrect(input);

            Assert.IsFalse(result);
        }
    }
}
