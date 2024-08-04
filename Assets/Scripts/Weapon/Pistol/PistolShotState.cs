public class PistolShotState : State
{
    private readonly WeaponAnimationController _weaponAnimationController;

    public PistolShotState(WeaponAnimationController weaponAnimationController)
    {
        _weaponAnimationController = weaponAnimationController;
    }

    public override void OnStateEnter()
    {
        _weaponAnimationController.SetTrigger(WeaponAnimationType.PistolShot);
    }
}