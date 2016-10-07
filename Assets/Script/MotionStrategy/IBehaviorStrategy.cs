using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public delegate void eventMonster();

public interface IBehaviorStrategy 
{
	List<Paths> allPaths{ get ; set;}

	void StartMoveMonstr ();
	void MoveMonstr ();
	void StopMoveMonstr ();
	void KillMonstr ();

    event eventMonster onKillMonster;
    event eventMonster onDontKillMonster;
 
}
