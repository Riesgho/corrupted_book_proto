﻿
using Assets.CorruptedBook.Domain;
using NUnit.Framework;

namespace Assets.Editor.Domain
{
    public class PlayerShould
    {
        private Player player;
        private int amountToModify = 20;
        private int healthDelta = 0;

        [SetUp]
        public void Setup()
        {
            player = new Player("Player", 100, 90, 0, PlayerStatus.Normal);
        }

        [Test]
        public void NeverHasMoreCurrentHealthThanMaxHealth()
        {
            WhenCurrentHealthIsAddedToPlayer(player.MaxHealth + amountToModify);
            ThenPlayerIsOnMaxHealth();
        }

        [Test]
        public void IncreaseCurrentHealthWhenMaxHealthIsIncreased()
        {
            GivenADiferenceBetweenMaxAndCurrentHealth();
            WhenPlayersMaxHealthIsIncreased();
            ThenTheDifferenceStaysTheSame();
        }

        [Test]
        public void ReduceCurrentHealthWhenReceiveDamage()
        {
            GivenADiferenceBetweenMaxAndCurrentHealth();
            WhenPlayerReceiveDamage(amountToModify);
            ThenPlayersHealthIsReduced();
        }

        [Test]
        public void NeverHasLessHealthThanZero()
        {
            WhenPlayerReceiveDamage(player.MaxHealth - 1);
            ThenHealthIsZero();
        }

        [Test]
        public void ChangePlayerStatusToDeadWhenHealthIsZero()
        {
            WhenPlayerReceiveDamage(player.MaxHealth);
            Assert.AreEqual(PlayerStatus.Dead, player.PlayerStatus);
        }

        private void GivenADiferenceBetweenMaxAndCurrentHealth()
        {
            healthDelta = player.MaxHealth - player.CurrentHealth;
        }

        private void WhenPlayerReceiveDamage(int value)
        {
            player.SustractCurrentHealth(value);
        }


        private void WhenPlayersMaxHealthIsIncreased()
        {
            player.AddMaxHealth(player.MaxHealth + amountToModify);
        }


        private void WhenCurrentHealthIsAddedToPlayer(int value)
        {
            player.AddCurrentHealth(value);
        }
        private void ThenPlayersHealthIsReduced()
        {
            Assert.AreEqual(healthDelta + amountToModify, player.MaxHealth - player.CurrentHealth);
        }

        private void ThenPlayerIsOnMaxHealth()
        {
            Assert.IsTrue(player.CurrentHealth == player.MaxHealth);
        }

        private void ThenTheDifferenceStaysTheSame()
        {
            Assert.AreEqual(healthDelta , player.MaxHealth - player.CurrentHealth);
        }
        private void ThenHealthIsZero()
        {
            Assert.AreEqual(0, player.CurrentHealth);
        }

    }
}
