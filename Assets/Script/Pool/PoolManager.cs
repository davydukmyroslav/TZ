using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PoolManager<K , V> where V :IPoolObject<K> 
{
	public virtual int MaxInstances{ get; protected set;}
	public virtual int InstancesCount{ get; protected set;}
	public virtual int CacheInstances{ get; protected set;}

	public delegate bool Compare<T>(T value) where T:V;

	protected Dictionary<K , List<V>> objects;
	protected Dictionary<Type , List<V>> cache;

	public PoolManager(int maxInstance)
	{
		MaxInstances = maxInstance;

		objects = new Dictionary<K, List<V>> ();
		cache = new Dictionary<Type, List<V>> ();
	}

	public virtual bool CanPush()
	{
		return InstancesCount + 1 < MaxInstances;
	}

	public virtual bool Push(K groupKey , V value)
	{
		bool result = true;

		if (CanPush ()) 
		{
			value.OnPush ();

			if (!objects.ContainsKey (groupKey)) {
				objects.Add (groupKey, new List<V> ());		
			}

			objects [groupKey].Add (value);
			Type type = value.GetType ();

			if (!cache.ContainsKey (type)) {
				cache.Add (type, new List<V> ()); 
			}

			cache [type].Add (value);

 		} 
 
		return result;
	}
 
	public virtual T Pop<T>(K groupKey) where T : V
	{
		T result = default(T);
		if (objects.ContainsKey(groupKey) && objects[groupKey].Count > 0)
		{ 
			for (int i = 0; i < objects[groupKey].Count; i++)
			{
				if (objects[groupKey][i] is T)
				{
					result = (T)objects[groupKey][i];
					Type type = result.GetType();
					RemoveObject(groupKey, i);
					RemoveFromCache(result, type);
					result.Create();
					break;
				}
			}
		}
		return result;
	}
		
	protected virtual bool ValidateForPop(Type type)
	{
		return cache.ContainsKey (type) && cache [type].Count > 0;
	}

	protected virtual void RemoveObject(K groupKey , int idx)
	{
		if (idx >= 0 && idx < objects [groupKey].Count) 
		{
			objects [groupKey].RemoveAt (idx);

			if (objects [groupKey].Count == 0) 
			{
				objects.Remove (groupKey);
			}
		}
	}

	protected void RemoveFromCache(V value, Type type)
	{
		if (cache.ContainsKey(type))
		{
			cache[type].Remove(value);

			if (cache[type].Count == 0)
			{
				cache.Remove(type);
			}
		}
	}
}
