using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

public static class ControllerBomb  
{
	public static Action<Vector3> onUseBomb;

	public static void UseBomb(Vector3 mousePosition)
	{
		if (onUseBomb != null)	
			onUseBomb (mousePosition);
	}
}

