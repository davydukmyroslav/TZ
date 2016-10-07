using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ViewWindowGameOver : UnityPoolObject ,  IWindowBase 	  
{
    [SerializeField]
    Button ButtonStart;

    [SerializeField]
    Button ButtonExitGame;

    void Awake()
    {
 
    }

	void Start () 
    {
        ButtonStart.onClick.AddListener( ()=> {DisableWindow();});

        ButtonExitGame.onClick.AddListener( ()=> {ExitGame();});
  	}

    public void Initialization( )
    {
        ControllerGamingPerformance.onGameOver += ShowWindow    ;
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

    void ExitGame()
    {
        
    }
 
 
 
}
