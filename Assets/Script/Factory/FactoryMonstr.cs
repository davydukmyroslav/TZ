using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class FactoryMonstr
{
    static FactoryMonstr()
    {
 
    } 

	public static GameObject CreateViewMonstr(string nameMonstr  , Transform parent)
    { 
		GameObject monstr = GameObject.Instantiate(Resources.Load(nameMonstr)) as GameObject;
        
		monstr.transform.SetParent (parent , false);

		return monstr;    
	} 

	public static System.Object CreateTypeMonstr(IBehaviorStrategy IMotionStrategy)
	{
 		return IMotionStrategy;
	}
 
}

