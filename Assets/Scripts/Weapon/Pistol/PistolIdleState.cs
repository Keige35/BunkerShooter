using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolIdleState : State
{
    private readonly WeaponAnimationController _weaponAnimationController;

    public PistolIdleState(WeaponAnimationController weaponAnimationController)
    {
        _weaponAnimationController = weaponAnimationController;
    }

    public override void OnStateEnter()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.PistolIdle, true);
    }

    public override void OnStateExit()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.PistolIdle, false);
    }
}
