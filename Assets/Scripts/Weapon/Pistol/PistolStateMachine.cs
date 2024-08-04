using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(ShotSystem), typeof(PistolReloader))]
public class PistolStateMachine : MonoBehaviour
{
    [SerializeField] private float fireRate;
    private StateMachine _stateMachine;
    private StateMachine _shotMachine;

    public float FireRate => fireRate;

    private bool isReadyToShot => CheckReadyShot();

    private PistolReloader reloader;
    private PistolScopeState pistolScopeState;
    private PistolIdleState pistolIdleState;
    private PistolReloadState pistolReloadState;

    private void Awake()
    {
        reloader = GetComponent<PistolReloader>();
        InitializeStateMachine();
    }

    private void Update()
    {
        _stateMachine.OnUpdate();
        _shotMachine.OnUpdate();
        if (Input.GetKeyDown(KeyCode.R) && reloader.IsMagFull() == false)
        {
            StartReload();
        }
    }

    private void FixedUpdate()
    {
        _stateMachine.OnFixedUpdate();
       _shotMachine.OnFixedUpdate();
    }

    private bool CheckReadyShot()
    {
        if (reloader.CheckAmount() == false || _stateMachine.CurrentState == pistolReloadState)
        {
            return false;
        }

        if (_stateMachine.CurrentState == pistolIdleState)
        {
            return true;
        }

        if (_stateMachine.CurrentState == pistolScopeState)
        {
            return true;
        }

        return false;
    }

    private void InitializeStateMachine()
    {
        var animatorController = new WeaponAnimationController(GetComponent<Animator>());
        pistolIdleState = new PistolIdleState(animatorController);
        var pistolShowState = new PistolShowState(animatorController);
        pistolScopeState = new PistolScopeState(animatorController);
        pistolReloadState = new PistolReloadState(animatorController);
        var pistolRunState = new PistolRunState(animatorController);


        pistolShowState.AddTransition(new StateTransition(pistolIdleState,
            //new AnimationTransitionCondition(animatorController.Animator, WeaponAnimationType.PistolShow.ToString())));
            new TemporaryCondition(0.5f)));

        pistolIdleState.AddTransition(new StateTransition(pistolScopeState, new FuncCondition(() => Input.GetMouseButton(1))));
        pistolIdleState.AddTransition(new StateTransition(pistolRunState,
            new FuncCondition(() => Input.GetKey(KeyCode.LeftShift))));

        pistolRunState.AddTransition(new StateTransition(pistolIdleState,
            new FuncCondition(() => Input.GetKey(KeyCode.LeftShift) == false)));
        pistolRunState.AddTransition(new StateTransition(pistolScopeState, new FuncCondition(() => Input.GetMouseButton(1))));

        pistolScopeState.AddTransition(new StateTransition(pistolIdleState,
            new FuncCondition(() => Input.GetMouseButton(1) == false)));

        pistolReloadState.AddTransition(new StateTransition(pistolIdleState,
           // new AnimationTransitionCondition(animatorController.Animator, WeaponAnimationType.PistolReload.ToString(), 1f)));
           new TemporaryCondition(2f)));
        _stateMachine = new StateMachine(pistolShowState);
        InitializeShotStateMachine(animatorController);
    }

    private void StartReload()
    {
        if (_stateMachine.CurrentState != pistolReloadState)
        {
            _stateMachine.SetState(pistolReloadState);
        }
    }

    private void InitializeShotStateMachine(WeaponAnimationController weaponAnimationController)
    {
        var pistolIdleState = new State();
        var pistolShotState = new PistolShotState(weaponAnimationController);

        pistolIdleState.AddTransition(new StateTransition(pistolShotState,
            new FuncCondition(() => isReadyToShot && Input.GetMouseButtonDown(0))));
        pistolIdleState.AddTransition(new StateTransition(pistolIdleState, new FuncCondition(() =>
        {
            if (Input.GetMouseButton(0) && reloader.CheckAmount() == false)
            {
                StartReload();
                return true;
            }

            return false;
        })));
        pistolShotState.AddTransition(new StateTransition(pistolIdleState, new TemporaryCondition(fireRate)));

        _shotMachine = new StateMachine(pistolIdleState);
    }
}