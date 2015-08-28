using UnityEngine;
using System.Collections;

public class GameMain : MonoBehaviour {

	bool finishedFlg = false;

	enum State{
		Wait,
		PlayerAttack,
		EnemyAttack,
		Finish
	};

	class Player
	{
		public int HP = 150;
		public int AttackPower = 15;
		public void playerAttack(Enemy e)
		{
			int damage = UnityEngine.Random.Range(1, AttackPower + 1);
			e.HP -= damage;
			Debug.Log("=== Player Attack! ===");
			Debug.Log("Damage: " + damage);
			Debug.Log("EnemyHP: " + e.HP);
		}
	}

	class Enemy
	{
		public int HP = 100;
		public int AttackPower = 10;
		public void enemyAttack(Player p)
		{
			int damage = UnityEngine.Random.Range(1, AttackPower + 1);
			p.HP -= damage;
			Debug.Log("=== Enemy Attack! ===");
			Debug.Log("Damage: " + damage);
			Debug.Log("PlayerHP: " + p.HP);
		}
	}

	Player p = new Player ();
	Enemy e = new Enemy ();

	State state = State.Wait;
	void Update()
	{
		switch (state)
		{
			case State.Wait:
				if (Input.GetMouseButtonDown(0))				{
					state = State.PlayerAttack;
				}
				break;
			case State.PlayerAttack:
				p.playerAttack(e);
				if (e.HP <= 0)
				{
					state = State.Finish;
				}
				else
				{
					state = State.EnemyAttack;
				}
				break;
			case State.EnemyAttack:
				e.enemyAttack(p);
				if (p.HP <= 0)
				{
					state = State.Finish;
				}
				else
				{
					state = State.Wait;
				}
				break;
			case State.Finish:
				if (!finishedFlg)
				{
					if (e.HP <= 0)
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


}
