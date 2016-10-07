using UnityEngine;
using System.Collections;

public class ExplosionBomb : MonoBehaviour 
{
	void OnTriggerEnter(Collider obj)
	{
 		obj.transform.parent.gameObject.GetComponent<ViewMonstr> ().onKillMonster ();
	}	
}
