using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConstructorGame : MonoBehaviour
{
 
	[SerializeField]
	AllPaths allPaths; 

	List<System.Object> behaviorTypeMonster = new List<System.Object >();

    void Start ()
    {   
        ControllerGamingPerformance.onGameOver += GameOver;

        ControllerGamingPerformance.onRestart += Restart;

        for (int i = 0; i < 8; i++) 
        {
			UnityPoolManager.Instance.Push ("good" , FactoryMonstr.CreateViewMonstr ("Monstr_1", this.transform).GetComponent<UnityPoolObject>() );

			UnityPoolManager.Instance.Push ("bed" , FactoryMonstr.CreateViewMonstr ("Monstr_2", this.transform).GetComponent<UnityPoolObject>() );
        }
    }

	void FixedUpdate()   
	{    
		for (int i = 0; i < behaviorTypeMonster.Count; i++)
        {
			if ((behaviorTypeMonster [i] is BasicMechanics)) 
			{
				if (((BasicMechanics)behaviorTypeMonster [i]).GetViewMonstr.gameObject.activeSelf == false) 
				{
					behaviorTypeMonster.RemoveAt (i);
					continue;
				}

                ((IBehaviorStrategy)behaviorTypeMonster [i]).MoveMonstr ();
			}  
        }
 	}
 
	IEnumerator IAddRandomMonstr(float time)
	{
		int random = UnityEngine.Random.Range (0, 3);

		switch(random)
		{
		case 0:
 			behaviorTypeMonster.Add (FactoryMonstr.CreateTypeMonstr (
				new BehaviorFirstTypeMonster (UnityPoolManager.Instance.Pop("good") as ViewMonstr  , allPaths.GetAllPaths  )));
			break;
			 
		case 1:	
			behaviorTypeMonster.Add(FactoryMonstr.CreateTypeMonstr(
				new BehaviorThirdTypeMonster (UnityPoolManager.Instance.Pop("bed").GetComponent<ViewMonstr>()  , allPaths.GetAllPaths )));
			break;

		case 2:
			behaviorTypeMonster.Add(FactoryMonstr.CreateTypeMonstr(
				new BehaviorSecondTypeMonster (UnityPoolManager.Instance.Pop("good") as ViewMonstr  , allPaths.GetAllPaths )));
			break; 
		}

		yield return new WaitForSeconds (time);

		AddRandomMonstr (); 
 	}

	IEnumerator addRandomMonstr;

	void AddRandomMonstr()
	{
		if (addRandomMonstr != null)
			StopCoroutine (addRandomMonstr);

			addRandomMonstr = IAddRandomMonstr (0.7f);
		StartCoroutine (addRandomMonstr);
	}


    void GameOver()
    {
		for (int i = 0; i < behaviorTypeMonster.Count; i++) 
        { 
			((IBehaviorStrategy)behaviorTypeMonster [i]).StopMoveMonstr ();
        }

		behaviorTypeMonster.Clear();

        StopCoroutine (addRandomMonstr);
    }

    void Restart()
    {
        AddRandomMonstr ();          
    } 

}

 
