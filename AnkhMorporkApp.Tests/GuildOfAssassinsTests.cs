using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnkhMorporkApp.Abstracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AnkhMorporkApp.Tests
{
    [TestClass]
    public class GuildOfAssassinsTests:ConsoleNameRetriever
    {
        private Player player;
        private decimal initialBalance;
        private string commandToSkip;

        [TestInitialize]
        public void SetUp()
        {
            initialBalance = 10;
            player = new Player(initialBalance);
            commandToSkip = "s";
        }
        public override string GetNextName()
        {
            return commandToSkip;
        }

        [TestMethod]
        public void IsMoneyEnough_IfBalanceIsGraterThanInput_ReturnTrue()
        {
            List<Assassin> assassins = new List<Assassin>()
            {
                new Assassin("name", 10, 20, false)
            };

            var fake = new Mock<IFileService>();

            fake.Setup(fr => fr.GetText("name")).Returns("");
            GuildOfAssassins guild = new GuildOfAssassins(fake.Object);
            GetNextName();
            guild.BalanceChange(player,assassins);
            decimal newBalance = player.Balance;
            Assert.AreNotEqual(initialBalance,newBalance);
        }
    }
}
