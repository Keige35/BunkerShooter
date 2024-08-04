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
