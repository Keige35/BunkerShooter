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
