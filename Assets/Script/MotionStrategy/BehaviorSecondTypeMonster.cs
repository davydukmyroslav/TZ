using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BehaviorSecondTypeMonster : SecondTypeMechanics , IBehaviorStrategy
{ 
    public event eventMonster onKillMonster;

    public event eventMonster onDontKillMonster;

    public BehaviorSecondTypeMonster()
    {
		
    }

	public BehaviorSecondTypeMonster(ViewMonstr viewMonstr , List<Paths> allPaths)  
	{
		viewMonstr.gameObject.SetActive (true);

		this.allPaths = allPaths;

		this.viewMonstr = viewMonstr;

		onKillMonster += KillMonstr;

		viewMonstr.onKillMonster = onKillMonster;

		StartMoveMonstr ();
  	} 

	public void StartMoveMonstr()
	{
        StartMove();
		viewMonstr.GetViewAnimation.PlayAnimation ("Run");

 	}

	public void MoveMonstr ()
	{
        CheckFinishMovement(allPaths[randomPath].GetFinishPos , DontKillMonstr);

        CheckFinishLeftRightMovement();
	}
 
	public void StopMoveMonstr ( )
	{
		StopMonstr ( );

		viewMonstr.GetViewAnimation.PlayAnimation ("Idle");

		UnityPoolManager.Instance.Push ("good" , viewMonstr);

	} 

	public void KillMonstr ()
	{
        ControllerGamingPerformance.AddKillMonstr();

		UnityPoolManager.Instance.Push ("good" , viewMonstr);
 	}

	public void DontKillMonstr ()
	{
        ControllerGamingPerformance.AddSkipGoodMonster ();

		UnityPoolManager.Instance.Push ("good" , viewMonstr);
	} 
}

