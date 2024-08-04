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

public class PistolRunState: State
{
    private readonly WeaponAnimationController _weaponAnimationController;

    public PistolRunState(WeaponAnimationController weaponAnimationController)
    {
        _weaponAnimationController = weaponAnimationController;
    }

    public override void OnStateEnter()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.PistolRun, true);
    }

    public override void OnStateExit()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.PistolRun, false);
    }
}

public class PistolShowState: State
{
    private WeaponAnimationController _weaponAnimationController;

    public PistolShowState(WeaponAnimationController weaponAnimationController)
    {
        _weaponAnimationController= weaponAnimationController;
    }
    public override void OnStateEnter()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.PistolShow, true);
    }
    public override void OnStateExit()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.PistolShow, false);
    }
}

public class PistolReloadState : State
{
    private readonly WeaponAnimationController _weaponAnimationController;

    public PistolReloadState(WeaponAnimationController weaponAnimationController)
    {
        _weaponAnimationController = weaponAnimationController;
    }

    public override void OnStateEnter()
    {
        _weaponAnimationController.SetTrigger(WeaponAnimationType.PistolReload);
    }
}

public class PistolScopeState : State
{
    private readonly WeaponAnimationController _weaponAnimationController;

    public PistolScopeState(WeaponAnimationController weaponAnimationController)
    {
        _weaponAnimationController = weaponAnimationController;
    }

    public override void OnStateEnter()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.PistolScope, true);
    }

    public override void OnStateExit()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.PistolScope, false);
    }
}

public class PistolShotState : State
{
    private readonly WeaponAnimationController _weaponAnimationController;

    public PistolShotState(WeaponAnimationController weaponAnimationController)
    {
        _weaponAnimationController = weaponAnimationController;
    }

    public override void OnStateEnter()
    {
        _weaponAnimationController.SetTrigger(WeaponAnimationType.Pist);
    }
}