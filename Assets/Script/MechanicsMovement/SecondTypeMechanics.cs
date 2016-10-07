using UnityEngine;
using System.Collections;
using System;

public class SecondTypeMechanics : BasicMechanics 
{

    private IEnumerator frequencyShear;

    protected void StartMove()
    {
        base.MoveStraight ();

        viewMonstr.transform.position = allPaths [randomPath].GetStartPos;
    }

    protected void CheckFinishMovement(Vector3 endMarker  , Action onFinishMoveMonstr = null)
    {
        if (Vector3.Distance (viewMonstr.transform.position, endMarker) < 3f) 
        { 
            if (onFinishMoveMonstr != null)
            {
                onFinishMoveMonstr ();
            }
        }
    }
 
    protected void CheckFinishLeftRightMovement()
    {
		Mathf.Clamp (viewMonstr.transform.position.x , 0 , 0.25f);
		
        if (Mathf.Abs(viewMonstr.transform.position.x - allPaths[randomPath].GetFinishPos.x) < 0.25f )
        {
            MoveStraight();

            Shear();
        }
    }

    private IEnumerator IFrequencyShear(float t , Action action)
    {
        yield return new WaitForSeconds(t);

        MoveLeftRight( );

        if (action != null)
        {
            action();
        }
    }

    private void Shear()
    {        
		if (viewMonstr.gameObject.activeSelf == true)
		{
			if (frequencyShear != null)
				viewMonstr.StopCoroutine (frequencyShear);

			frequencyShear = IFrequencyShear (0.5f, null);

			viewMonstr.StartCoroutine (frequencyShear);
		}
    }

 }
