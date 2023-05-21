using System.Collections.Generic;
using UnityEngine;

public static class Data
{
	public static string playerState = "";
	public static List<enemyBehavior> enemies = new List<enemyBehavior>();      // Кол-во врагов на уровне, для возможности перейти на следующий уровень, когда все враги будут уничтожены
	private static int playerHP = 3;
	public static int PlayerHP
	{
		set 
		{
			if (playerState != "Invulnerabil")
			{
				playerHP = value;
				GameObject.Find("GameManager").GetComponent<gameManager>().UpdateHP();
			}
		}
		get { return playerHP; }
	}
}