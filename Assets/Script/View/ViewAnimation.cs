using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class ViewAnimation 
{
	[SerializeField]
	Animation animation;

	public void PlayAnimation(string name)
	{
		animation.Play (name);
	}
}
