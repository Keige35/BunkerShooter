using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHandWeaponState : State
{
    private readonly WeaponAnimationController _weaponAnimationController;

    public HitHandWeaponState(WeaponAnimationController weaponAnimationController)
    {
        _weaponAnimationController = weaponAnimationController;
    }

    public override void OnStateEnter()
    {
        _weaponAnimationController.SetTrigger(WeaponAnimationType.HandWeaponHit);
    }
}
