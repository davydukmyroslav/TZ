using UnityEngine;
using System.Collections;

public class UnityPoolManager : MonoBehaviour
{
	public static UnityPoolManager Instance { get ; protected set;}

	public int maxInstanceCount = 100;

	protected PoolManager<string , UnityPoolObject > poolManager;

	void Awake()
	{
		Instance = this;

		poolManager = new PoolManager<string, UnityPoolObject> (maxInstanceCount);
	}

	public virtual bool Push(string groupKey , UnityPoolObject poolObject)
	{
		return poolManager.Push (groupKey , poolObject);
	}

	public virtual  UnityPoolObject Pop(string groupKey)
	{
  		return poolManager.Pop<UnityPoolObject> (groupKey);
	}
 
}
