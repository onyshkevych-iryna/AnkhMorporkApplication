using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace AnkhMorporkApp.Tests
{
    [TestClass]
    public class PlayerClass
    {
        [TestMethod]
        public void IsMoneyEnough_IfBalanceIsGraterThanInput_ReturnTrue()
        {
            Player player = new Player(10);
            var input = 2;

            var result = player.IsMoneyEnough(input);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsMoneyEnough_IfBalanceIsLessThanInput_ReturnFalse()
        {
            Player player = new Player(10);
            var input = 20;

            var result = player.IsMoneyEnough(input);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetMoney_InputSum_ReturnBalanceWithAddedSum()
        {
            var balance = 10;
            Player player = new Player(balance);
            var amount = 2;
            var valid = false;

            player.GetMoney(amount,ref valid);
            var newBalance = balance + amount;

            Assert.IsTrue(valid);
            Assert.AreEqual(newBalance, 12);
        }

        [TestMethod]
        public void GiveMoney_WithdrawSum_ReturnBalanceWithWithdrawSum()
        {
            var balance = 10;
            Player player = new Player(balance);
            var amount = 2;
            var valid = false;

            player.GiveMoney(amount, ref valid);
            var newBalance = balance - amount;

            Assert.IsTrue(valid);
            Assert.AreEqual(newBalance, 8);
        }

        //[TestMethod]
        //public void Skip_InputSum_ReturnBalanceWithAddedSum()
        //{
        //    var balance = 10;
        //    Player player = new Player(balance);
        //    var amount = 2;
        //    var valid = false;

        //    player.GetMoney(amount, ref valid);
        //    var newBalance = balance + amount;

        //    Assert.IsTrue(valid);
        //    Assert.AreEqual(newBalance, 12);
        //}
    }
}
