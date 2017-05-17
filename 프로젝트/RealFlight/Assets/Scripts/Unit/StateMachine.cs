using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine <T>  {

    private T Owner;
    private FSM_State<T> currentState;
    private FSM_State<T> previousState;

    public void Awake()
    {
        currentState = null;
        previousState = null;
    }

    public void ChangeState(FSM_State<T> newState)
    {
        if(newState == currentState)
        {
            return;
        }

        previousState = currentState;

        if(currentState != null)
        {
            currentState.EnterState(Owner);
        }

        currentState = newState;

        if(currentState != null)
        {
            currentState.EnterState(Owner);
        }
    }
	
    public void Init(T owner, FSM_State<T> initState)
    {
        Owner = owner;
        ChangeState(initState);
    }

    public void Update()
    {
        if(currentState != null)
        {
            currentState.UpdateState(Owner);
        }
    }

    //  이전 상태로 돌아간다
    public void StartRevert()
    {
        if(previousState != null)
        {
            ChangeState(previousState);
        }
    }
}
