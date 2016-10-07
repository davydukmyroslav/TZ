using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIController : MonoBehaviour   
{   
 
    void Start()
    {
         LoadWindowInPool(this.transform , "WindowGameOver");

         LoadWindowInPool(this.transform , "WindowStartLevel");

		 UnityPoolManager.Instance.Pop ("WindowStartLevel");
    }
        
    IWindowBase LoadWindowInPool(Transform parent , string nameWindow)
    {
		GameObject temp = Instantiate(Resources.Load(nameWindow)) as GameObject;

		UnityPoolManager.Instance.Push (nameWindow , temp.GetComponent<UnityPoolObject>() );

        temp.transform.SetParent(parent.transform , false);

        temp.SetActive(false);
       
        IWindowBase iWindowBase = temp.GetComponent<IWindowBase>();
       
        iWindowBase.Initialization();
        
        return iWindowBase;
    }

}

