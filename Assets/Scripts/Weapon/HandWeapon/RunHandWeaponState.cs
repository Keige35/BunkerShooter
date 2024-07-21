using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunHandWeaponState : State
{
    private readonly WeaponAnimationController _weaponAnimationController;

    public RunHandWeaponState(WeaponAnimationController weaponAnimationController)
    {
        _weaponAnimationController = weaponAnimationController;
    }

    public override void OnStateEnter()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.HandWeaponRun, true);
    }

    public override void OnStateExit()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.HandWeaponRun, false);
    }
}
