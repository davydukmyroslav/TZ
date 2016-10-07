using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AllPaths : MonoBehaviour 
{
	[SerializeField]
	GameObject targetController;

	public List<Paths> GetAllPaths = new List<Paths>();
 
	void Start()
	{
		GetPoint ();
	}

	void GetPoint()
	{
		foreach (Transform t in targetController.transform) 
		{
			GetAllPaths.Add (new Paths(t.GetChild(0).transform.position , t.GetChild(1).transform.position));
		}
	} 

	void OnDrawGizmos () 
	{ 
		if (GetAllPaths != null) 
		{
			for (int i = 0; i < GetAllPaths.Count; i++)
			{
				Gizmos.color = Color.blue;
				Gizmos.DrawLine (GetAllPaths[i].GetStartPos, GetAllPaths[i].GetFinishPos);
			}
		}
  	}

}

public class Paths
{
	private Vector3 startPos;
	public Vector3 GetStartPos{ get { return startPos; } private set{ }}

	private Vector3 finishPos;
	public Vector3 GetFinishPos{ get { return finishPos; } private set{ }}

	public Paths(Vector3 startPos , Vector3 finishPos)
	{
		this.finishPos = finishPos;
		this.startPos = startPos;
	}
}