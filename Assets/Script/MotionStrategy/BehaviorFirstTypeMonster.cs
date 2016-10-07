using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BehaviorFirstTypeMonster : FirstTypeMechanics , IBehaviorStrategy
{  
    public event eventMonster onKillMonster;
    public event eventMonster onDontKillMonster;
 
    public BehaviorFirstTypeMonster()
    {
		
    }

    public BehaviorFirstTypeMonster(ViewMonstr viewMonstr ,  List<Paths> allPaths)  
	{ 
		this.allPaths = allPaths;

		this.viewMonstr = viewMonstr; 
 
		onKillMonster += KillMonstr;	

        this.viewMonstr.onKillMonster = onKillMonster; 

		StartMoveMonstr ();
	} 

	public void StartMoveMonstr()
	{
        StartMove();

		viewMonstr.GetViewAnimation.PlayAnimation ("Run");
	}

	public void MoveMonstr()
	{
        FinishMoveMonstr (allPaths[randomPath].GetFinishPos , DontKillMonstr);
 	}

	public void StopMoveMonstr ( )
	{
		StopMonstr ();

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
        StartMoveMonstr();

		ControllerGamingPerformance.AddSkipGoodMonster ();

        StartMoveMonstr();

		UnityPoolManager.Instance.Push ("good" , viewMonstr);
	}
}

