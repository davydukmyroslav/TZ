using UnityEngine;
using System.Collections;
using System;

public class FirstTypeMechanics : BasicMechanics
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
                onFinishMoveMonstr ( );
            }
        }
    } 
}

