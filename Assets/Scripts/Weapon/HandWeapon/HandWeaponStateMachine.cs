using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Profiling;

[RequireComponent(typeof(Animator))]
public class HandWeaponStateMachine : MonoBehaviour
{
    private StateMachine _stateMachine;
    private StateMachine _hitMachine;

    // private bool isReadyToHit => CheckReadyHit();

    private void Awake()
    {
        InitializedStateMachine();
    }
    private void Update()
    {
        _stateMachine.OnUpdate();
        _hitMachine.OnUpdate();
    }
    private void FixedUpdate()
    {
        _stateMachine.OnFixedUpdate();
        _hitMachine.OnFixedUpdate();
    }
    private void InitializedStateMachine()
    {
        var animatorController = new WeaponAnimationController(GetComponent<Animator>());
        var idleState = new IdleHandWeaponState(animatorController);
        var showState = new ShowHandWeaponState(animatorController);
        var runState = new RunHandWeaponState(animatorController);


        showState.AddTransition(new StateTransition(idleState,
            new AnimationTransitionCondition(animatorController.Animator, WeaponAnimationType.HandWeaponShow.ToString())));

        idleState.AddTransition(new StateTransition(runState,
            new FuncCondition(() => Input.GetKey(KeyCode.LeftShift))));

        runState.AddTransition(new StateTransition(idleState,
            new FuncCondition(() => Input.GetKey(KeyCode.LeftShift) == false)));

        _stateMachine = new StateMachine(showState);
        InitializeHitStateMachine(animatorController);

    }
    private void InitializeHitStateMachine(WeaponAnimationController weaponAnimationController)
    {
        var idleState = new State();
        var hitState = new HitHandWeaponState(weaponAnimationController);

        idleState.AddTransition(new StateTransition(hitState,
            new FuncCondition(() => Input.GetMouseButton(0))));

        // hitState.AddTransition(new StateTransition(idleState, new AnimationTransitionCondition(weaponAnimationController.Animator, WeaponAnimationType.HandWeaponHit.ToString())));
        hitState.AddTransition(new StateTransition(idleState, new TemporaryCondition(1f)));

        _hitMachine = new StateMachine(idleState);
    }
}
