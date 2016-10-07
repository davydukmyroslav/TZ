using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System;

public class ViewMonstr : UnityPoolObject , IPointerDownHandler
{
	[SerializeField]
	ViewAnimation viewAnimation;

	public ViewAnimation GetViewAnimation{get{ return viewAnimation;}}

	[SerializeField]
	Rigidbody rigidbody;

	public Rigidbody GetRigidbody{get{ return rigidbody;}}

    public eventMonster onKillMonster;
 
	public void OnPointerDown (PointerEventData eventData)
	{
		if (onKillMonster != null)
		{
			onKillMonster ( );
 		}
	}
}
