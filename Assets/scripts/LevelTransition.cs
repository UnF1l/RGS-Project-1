using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
	public int sceneNumber = 0;								// Номер сцены, на которую севершается переход
	private void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject whatHit = collision.gameObject;
		if (whatHit.CompareTag("Player") && Data.enemies.Count == 0)
		{
			sceneNumber = nextScene(Data.currectLevel);
			Data.currectLevel = sceneNumber;	
			changeScene(sceneNumber);
		}
	}

	// Загрузка сцены под номером, номера сцен в File -> Build Settings -> Scenes In Build
	private void changeScene(int scene)
	{
		SceneManager.LoadScene(scene);
	}

	private void FixedUpdate()
	{
		if(Data.enemies.Count == 0)
		{
			GameObject.Find("NextLevelArrow").GetComponent<SpriteRenderer>().enabled = true;
		}
	}

	// Выбор рандомной сцены из готовых, кроме текущей
	private int nextScene(int curScene)
	{
		int nextScene = -1;
		do
		{
			nextScene = Random.Range(1, 4);		// Подставить актуальные значения
		} 
		while (nextScene == curScene);
		return nextScene;
	}
}
