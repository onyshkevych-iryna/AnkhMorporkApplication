using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace AnkhMorporkApp.Tests
{
    [TestClass]
    public class PlayerTests
    {
        private Player _player;
        private decimal _initialBalance;

        [TestInitialize]
        public void SetUp()
        {
            _initialBalance = 10;
            _player = new Player(_initialBalance);
        }
        
        [DataTestMethod]
        [DataRow(2)]
        [DataRow(9)]
        [DataRow(10)]
        public void IsOutOfMoney_IfBalanceIsGraterThanInput_ShouldReturnFalse(int input)
        {
            var result = _player.IsOutOfMoney(Convert.ToDecimal(input));

            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow(20)]
        [DataRow(100)]
        [DataRow(35)]
        public void IsOutOfMoney_IfBalanceIsLessThanInput_ShouldReturnTrue(int input)
        {
            var result = _player.IsOutOfMoney(Convert.ToDecimal(input));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetMoney_InputSum_ShouldReturnBalanceWithAddedAmount()
        {
            var amount = 2;
            var valid = false;
            var newBalance = _initialBalance + amount;

            _player.GetMoney(amount,ref valid);

            Assert.IsTrue(valid);
            Assert.AreEqual(newBalance, 12);
        }

        [TestMethod]
        public void GiveMoney_WithdrawSum_ShouldReturnBalanceWithWithdrawAmount()
        {
            var amount = 2;
            var valid = false;
            var newBalance = _initialBalance - amount;

            _player.GiveMoney(amount, ref valid);

            Assert.IsTrue(valid);
            Assert.AreEqual(newBalance, 8);
        }
        
        [TestMethod]
        public void Skip_PlayerChoseToSkipAssassin_IsAliveShouldBeFalse()
        {
            List<Assassin> assassins = new List<Assassin>()
            {
                new Assassin("name", 11, 20, false)
            };

            _player.Skip(assassins.GetType());

            Assert.IsFalse(_player.IsAlive);
        }

        [TestMethod]
        public void Skip_PlayerChoseToSkipBeggar_IsAliveShouldBeFalse()
        {
            Beggar beggar = new Beggar("practice", 11);

            _player.Skip(beggar.GetType());

            Assert.IsFalse(_player.IsAlive);
        }

        [TestMethod]
        public void Skip_PlayerChoseToSkipThieve_IsAliveShouldBeFalse()
        {
            Thief thieve = new Thief();

            _player.Skip(thieve.GetType());

            Assert.IsFalse(_player.IsAlive);
        }

        [TestMethod]
        public void Skip_PlayerChoseToSkipFool_IsAliveShouldBeTrue()
        {
            Fool fool = new Fool("practice", 11);

            _player.Skip(fool.GetType());

            Assert.IsTrue(_player.IsAlive);
        }

        [DataTestMethod]
        [DataRow(2)]
        [DataRow(9)]
        [DataRow(10)]
        public void EnteredSumIsCorrect_IfBalanceIsGraterThanInput_ShouldReturnTrue(int input)
        {
            var result = _player.EnteredSumIsCorrect(Convert.ToDecimal(input));

            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow(20)]
        [DataRow(100)]
        [DataRow(35)]
        public void EnteredSumIsCorrect_IfBalanceIsLessThanInput_ShouldReturnFalse(int input)
        {
            var result = _player.EnteredSumIsCorrect(Convert.ToDecimal(input));

            Assert.IsFalse(result);
        }
    }
}
