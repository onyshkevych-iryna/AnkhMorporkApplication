using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AnkhMorporkApp.Tests
{
    [TestClass]
    class GuildOfAssassinsClass
    {
        private Player player;
        private double initialBalance;
        private string commandToSkip;

        [TestInitialize]
        public void SetUp()
        {
            initialBalance = 10;
            player = new Player(initialBalance);
            commandToSkip = "s";
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
    }
}
