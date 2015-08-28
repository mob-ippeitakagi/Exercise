using UnityEngine;
using System.Collections;

public class GameMain : MonoBehaviour {
	int playerHP = 150;
	int playerAttackPower = 15;
	int enemyHP = 100;
	int enemyAttackPower = 10;
	bool finishedFlg = false;

	string state = "wait";
	void Update()
	{
		switch (state)
		{
			case "wait":
				if (Input.GetMouseButtonDown(0))
				{
					state = "playerAttack";
				}
				break;
			case "playerAttack":
				playerAttack();
				if (enemyHP <= 0)
				{
					state = "finish";
				}
				else
				{
					state = "enemyAttack";
				}
				break;
			case "enemyAttack":
				enemyAttack();
				if (playerHP <= 0)
				{
					state = "finish";
				}
				else
				{
					state = "wait";
				}
				break;
			case "finish":
				if (!finishedFlg)
				{
					if (enemyHP <= 0)
					{
						Debug.Log("=== Player Win! ===");
					}
					else
					{
						Debug.Log("=== Player Lose... ===");
					}
					finishedFlg = true;
				}
				break;
		}
	}
	void playerAttack()
	{
		int damage = UnityEngine.Random.Range(1, playerAttackPower + 1);
		enemyHP -= damage;
		Debug.Log("=== Player Attack! ===");
		Debug.Log("Damage: " + damage);
		Debug.Log("EnemyHP: " + enemyHP);
	}
	void enemyAttack()
	{
		int damage = UnityEngine.Random.Range(1, enemyAttackPower + 1);
		playerHP -= damage;
		Debug.Log("=== Enemy Attack! ===");
		Debug.Log("Damage: " + damage);
		Debug.Log("PlayerHP: " + playerHP);
	}
}
