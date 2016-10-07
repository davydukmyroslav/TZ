using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ViewWindowStartLevel : UnityPoolObject , IWindowBase 
{
    [SerializeField]
    Button ButtonStart; 
 
    public void Initialization( )
    {
        ButtonStart.onClick.AddListener( ()=> {DisableWindow();});
    }

    public void ShowWindow()
    {
		UnityPoolManager.Instance.Pop ("WindowGameOver");
    }

    public void DisableWindow()
    { 
		UnityPoolManager.Instance.Push ("WindowGameOver" , this);

        ControllerGamingPerformance.onRestart();  
    }

}

 
