using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class FSM_State<T> {

    abstract public void EnterState(T Unit);

    abstract public void UpdateState(T Unit);

    abstract public void ExitState(T Unit);
	
}
