using UnityEngine;
using System.Collections;
using System;

public static class ControllerGamingPerformance
{
	private static int maxSkipGoodMonster = 3;
    public static int GetSkipGoodMonster{get{ return maxSkipGoodMonster;}}
    public static Action onUpdateCountSkipMonst; 


    private static int contKillMonstr;
    public static int GetContKillMonstr{get{ return contKillMonstr;}}
    public static Action onUpdateKillMonstr; 

	public static int countBomb = 3;
	public static int GetCountBomb{get{ return countBomb;}}
	public static Action onUpdateCountBomb; 
	public static bool CheckFinishedBomb = true; 

	public static Action onGameOver;

    public static Action onRestart; 

	static ControllerGamingPerformance()
	{
		onRestart += ResrtartGame;
	}

	public static void AddSkipGoodMonster()
	{
		if (maxSkipGoodMonster >=  0) 
		{
			maxSkipGoodMonster--;

			if (onUpdateCountSkipMonst != null)
				onUpdateCountSkipMonst ();
		}

        if (maxSkipGoodMonster <=  0)  
		{
            if (onGameOver != null)
            {
                 onGameOver();
            }		 	

		    onUpdateCountSkipMonst ();
		}
	}

    public static void AddKillMonstr()
    {
        contKillMonstr++;

        if (onUpdateKillMonstr != null)
            onUpdateKillMonstr();
    }

	public static void MinusCountBomb()
	{
		if (countBomb != 0) 
		{
			countBomb--;	

			if (onUpdateCountBomb != null)
				onUpdateCountBomb ();
		}

		if (countBomb == 0)  
		{
			CheckFinishedBomb = false;
		}
	}

	static void ResrtartGame()
	{
		CheckFinishedBomb = true;
		
		maxSkipGoodMonster = 3;
		countBomb = 3;
		contKillMonstr = 3;

		onUpdateKillMonstr();
		onUpdateCountSkipMonst ();
        onUpdateCountBomb ();
	}
}


 

