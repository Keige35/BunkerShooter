using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHandWeaponState : State
{
    private readonly WeaponAnimationController _weaponAnimationController;

    public ShowHandWeaponState(WeaponAnimationController weaponAnimationController)
    {
        _weaponAnimationController = weaponAnimationController;
    }

    public override void OnStateEnter()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.HandWeaponShow, true);
    }

    public override void OnStateExit()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.HandWeaponShow, false);
    }
}
