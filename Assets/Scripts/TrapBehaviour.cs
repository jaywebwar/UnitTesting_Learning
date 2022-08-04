using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour
{
    Animator _animator;
    Trap trap;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        trap = new Trap();
    }

    void OnEnable() => trap.OnTrapAnimationBoolChanged += SetAnimationBool;

    void OnDisable() => trap.OnTrapAnimationBoolChanged -= SetAnimationBool;

    void SetAnimationBool() => _animator.SetBool("isPlayerOnTrap", trap.ShouldBePressed());

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trap triggering...");

        var player = other.GetComponent<IPlayer>();

        trap.OnTriggerEnter(player);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Leaving Trap...");

        trap.OnTriggerExit();
    }
}


//This is an example of the Humble Object Design Pattern.
//We use this here to separate out the Monobehavioural functionality
//with our unit testable logic.
public class Trap
{
    bool shouldBePressed = false;
    int playersOnTrap = 0;

    public event Action OnTrapAnimationBoolChanged;

    public bool ShouldBePressed() => shouldBePressed;

    public bool isTrapFreeOfPlayers()
    {
        if (playersOnTrap == 0)
            return true;
        return false;
    }

    public void TriggerEnterAnimation()
    {
        shouldBePressed = true;
        OnTrapAnimationBoolChanged?.Invoke();
    }

    public void TriggerExitAnimation()
    {
        shouldBePressed = false;
        OnTrapAnimationBoolChanged?.Invoke();
    }

    public void AddPlayerToTrap() => playersOnTrap++;

    public void DamagePlayerForEnteringTrap(IPlayer player) => player.Health--;

    public void RemovePlayerFromTrap() => playersOnTrap--;

    public void OnTriggerEnter(IPlayer player)
    {
        if (isTrapFreeOfPlayers())
        {
            //Damages first player that enters the trap
            TriggerEnterAnimation();
            DamagePlayerForEnteringTrap(player);
        }

        AddPlayerToTrap();
    }

    public void OnTriggerExit()
    {
        RemovePlayerFromTrap();
        if (isTrapFreeOfPlayers())
            TriggerExitAnimation();
    }
}

