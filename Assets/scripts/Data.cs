using System.Collections.Generic;

public static class Data
{
	public static string playerState = "";
	public static List<enemyBehavior> enemies = new List<enemyBehavior>();      // Кол-во врагов на уровне, для возможности перейти на следующий уровень, когда все враги будут уничтожены
	private static int playerHP = 3;
	public static int PlayerHP
	{
		set { if(playerState != "Invulnerabil") playerHP = value; }
		get { return playerHP; }
	}
	public static int currectLevel = 1;         // Номер текущей сцены
}