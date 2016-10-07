using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BasicMechanics  
{
    //движение с помощью физики
	protected int randomPath ;

	protected int numberPathNow;

	protected List<int> allNumberPath = new List<int> ();

	protected ViewMonstr viewMonstr;

	public ViewMonstr GetViewMonstr{get{ return viewMonstr;}} 
   
    protected float speedMoveStraight = 10f;

    protected float speedMoveLeftRight = 8f;

 
	private void MotionControl(Vector3  directionsOfMotionVector  )
	{
		StopMonstr ();           
 
		viewMonstr.GetRigidbody.AddForce (directionsOfMotionVector.normalized * speedMoveStraight , ForceMode.Impulse);  
	} 

	private void MotionControl(Vector3  directionsOfMotionVector  , float speed )
	{ 
		viewMonstr.GetRigidbody.isKinematic = false;

		viewMonstr.GetRigidbody.AddForce (directionsOfMotionVector.normalized * speed , ForceMode.Impulse); 
	} 

    internal void MoveStraight ()
    {
        allNumberPath.Clear ();

        for (int i = 0; i < 3; i++)     
        {
            allNumberPath.Add (i);
        }

        randomPath = UnityEngine.Random.Range (0  , allPaths.Count);

        MotionControl (allPaths[randomPath].GetFinishPos- allPaths[randomPath].GetStartPos);

        numberPathNow = allNumberPath[randomPath];

        allNumberPath.Remove (allNumberPath[randomPath]);
    }

    protected void MoveLeftRight( )
    {  
        randomPath = allNumberPath[UnityEngine.Random.Range (0  , allNumberPath.Count)];
 
		Vector3 norma = (new Vector3 (allPaths [randomPath].GetFinishPos.x,
			viewMonstr.transform.position.y, viewMonstr.transform.position.z) - viewMonstr.transform.position);

		MotionControl ( new Vector3(norma.x  , norma.y , norma.z)  , speedMoveLeftRight);

        allNumberPath.Add (numberPathNow);

        numberPathNow = allNumberPath[randomPath];

        allNumberPath.Remove (allNumberPath[randomPath]);
    } 

	public void StopMonstr()
	{
		viewMonstr.GetRigidbody.Sleep (); 
	}

	protected void FinishMoveMonstr(Vector3 endMarker  , Action onFinishMoveMonstr = null)
	{
		if (Vector3.Distance (viewMonstr.transform.position, endMarker) < 3f) 
		{ 
			if (onFinishMoveMonstr != null)
			{
				onFinishMoveMonstr ( );
			}
		} 
	} 

	protected void FinishMoveMonstr(Action onFinishMoveMonstr = null)
	{
		if (onFinishMoveMonstr != null)
			onFinishMoveMonstr ();
	}

	public List<Paths> allPaths{ get ; set;}
}

 

