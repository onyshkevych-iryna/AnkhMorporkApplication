using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace AnkhMorporkApp.Tests
{
    [TestClass]
    public class PlayerClass
    {
        private Player player;
        private double initialBalance;

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
        public void IsMoneyEnough_IfBalanceIsGraterThanInput_ReturnTrue(double input)
        {
            var result = player.IsMoneyEnough(input);

            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow(20)]
        [DataRow(100)]
        [DataRow(35)]
        public void IsMoneyEnough_IfBalanceIsLessThanInput_ReturnFalse(double input)
        {
            var result = player.IsMoneyEnough(input);

            Assert.IsFalse(result);
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
        public void Skip_ShouldReturnFalse()
        {
            string number = "l";
            Assassin assassin = new Assassin("name", 11, 20, false);

            var result = player.Skip(number, assassin);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Skip_Assassin_ShouldReturnTrue()
        {
            string number = "s";
            Assassin assassin = new Assassin("name", 11, 20, false);

            var result = player.Skip(number, assassin);

            Assert.IsTrue(result);
            Assert.IsFalse(player.IsAlive);
        }

        [TestMethod]
        public void Skip_Beggar_ShouldReturnTrue()
        {
            string number = "s";
            Beggar beggar = new Beggar("practice", 11);

            var result = player.Skip(number, beggar);

            Assert.IsTrue(result);
            Assert.IsFalse(player.IsAlive);
        }

        [TestMethod]
        public void Skip_Thieve_ShouldReturnTrue()
        {
            string number = "s";
            Thieve thieve = new Thieve();

            var result = player.Skip(number, thieve);

            Assert.IsTrue(result);
            Assert.IsFalse(player.IsAlive);
        }

        [TestMethod]
        public void Skip_Fool_ShouldReturnFalse()
        {
            string number = "s";
            Fool fool = new Fool("practice", 11);

            var result = player.Skip(number, fool);

            Assert.IsTrue(result);
            Assert.IsTrue(player.IsAlive);
        }
    }
}
