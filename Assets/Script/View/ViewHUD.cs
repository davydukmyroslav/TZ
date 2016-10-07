using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ViewHUD : MonoBehaviour 
{
	[SerializeField]
	Text countLife;

    [SerializeField]
    Text scoreLine;

 	void Start () 
	{
		ControllerGamingPerformance.onUpdateCountSkipMonst += ShowCountLife;

		ControllerGamingPerformance.onUpdateCountSkipMonst ();

        ControllerGamingPerformance.onUpdateKillMonstr += ShowScore;

        ControllerGamingPerformance.onUpdateKillMonstr ();
	}

	void ShowCountLife()
	{
		countLife.text = ControllerGamingPerformance.GetSkipGoodMonster.ToString ();
	}

    void ShowScore()
    {
        scoreLine.text = ControllerGamingPerformance.GetContKillMonstr.ToString ();
    }
}
