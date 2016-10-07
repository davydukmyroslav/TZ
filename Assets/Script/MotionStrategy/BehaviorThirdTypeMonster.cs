using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BehaviorThirdTypeMonster : SecondTypeMechanics , IBehaviorStrategy 
{
    public event eventMonster onKillMonster;

    public event eventMonster onDontKillMonster;

    public BehaviorThirdTypeMonster()
    {
		
    }

	public BehaviorThirdTypeMonster(ViewMonstr viewMonstr  ,List<Paths> allPaths )  
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
		viewMonstr.GetViewAnimation.PlayAnimation ("Run");
        StartMove();
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
 
		UnityPoolManager.Instance.Push ("bed" , viewMonstr);
    } 

    public void KillMonstr ()
    {
		Debug.Log ("KillMonstr");		

		ControllerGamingPerformance.onGameOver ();
     }

    public void DontKillMonstr ()
    {  
		UnityPoolManager.Instance.Push ("bed" , viewMonstr);
    } 
}
