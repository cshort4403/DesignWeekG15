using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameManager
{
	public static GameManager Instance = new GameManager();

	private GameManager()
	{
		Instance = this;
	}

	public void ResetLevel()
	{
		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Player"))
		{
			g.GetComponent<MovePlayer>().ResetPosition();
			g.GetComponent<PlayerStateManager>().ResetPlayer();
			Debug.Log($"Reset Player {g.GetComponent<MovePlayer>().GetPlayerIndex()}");
		}

		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Items"))
		{
			g.GetComponent<ItemSpawnBehavior>().ResetItem();
		}

		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Bullet"))
		{
			GameObject.Destroy(g);
		}

	}
}
