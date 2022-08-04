using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TrapTestsScript
{
    [Test]
    public void PlayerEntersTrap_ReducesHealthByOne()
    {
        //ARRANGE
        Trap trap = new Trap();
        IPlayer player = Substitute.For<IPlayer>();

        //ASSIGN
        trap.DamagePlayerForEnteringTrap(player);

        //ASSERT
        Assert.AreEqual(-1, player.Health);
    }

    [Test]
    public void PlayerEntersTrapTwice_ReducesHealthByTwo()
    {
        //ARRANGE
        Trap trap = new Trap();
        IPlayer player = Substitute.For<IPlayer>();

        //ASSIGN
        trap.DamagePlayerForEnteringTrap(player);
        trap.DamagePlayerForEnteringTrap(player);

        //ASSERT
        Assert.AreEqual(-2, player.Health);
    }

    [Test]
    public void PlayerEntersTrap_TrapBoolGetsSet()
    {
        //ARRANGE
        Trap trap = new Trap();
        IPlayer player = Substitute.For<IPlayer>();

        //ASSIGN
        trap.OnTriggerEnter(player);

        //ASSERT
        Assert.AreEqual(true, trap.ShouldBePressed());
    }

    [Test]
    public void PlayersEnterTrap_TrapBoolStaysSetAfterFirstPlayerLeaves()
    {
        //ARRANGE
        Trap trap = new Trap();
        IPlayer player1 = Substitute.For<IPlayer>();
        IPlayer player2 = Substitute.For<IPlayer>();

        //ASSIGN
        trap.OnTriggerEnter(player1);
        trap.OnTriggerEnter(player2);
        trap.OnTriggerExit();

        //ASSERT
        Assert.AreEqual(true, trap.ShouldBePressed());
    }
    [Test]
    public void TwoPlayersEnterTrap_SecondPlayerIsNotDamaged()
    {
        //ARRANGE
        Trap trap = new Trap();
        IPlayer player1 = Substitute.For<IPlayer>();
        IPlayer player2 = Substitute.For<IPlayer>();

        //ASSIGN
        trap.OnTriggerEnter(player1);
        trap.OnTriggerEnter(player2);

        //ASSERT
        Assert.AreEqual(0, player2.Health);
    }
}
