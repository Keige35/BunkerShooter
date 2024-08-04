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
        _weaponAnimationController.SetBool(WeaponAnimationType.PistolIsReload, true);

    }

    public override void OnStateExit()
    {
        _weaponAnimationController.SetBool(WeaponAnimationType.PistolIsReload, false);
    }
}
