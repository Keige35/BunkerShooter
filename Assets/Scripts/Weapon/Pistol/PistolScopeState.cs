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
