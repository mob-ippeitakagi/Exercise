using System.Collections;
using UnityEngine;

class Player
{
	public int HP;
	public int AttackPower;

	public Player(int hp ,int attack){
		HP = hp;
		AttackPower = attack;
	}

	public void playerAttack(int playernum,Enemy e,int enemynum)
	{
		int damage = UnityEngine.Random.Range(1, AttackPower + 1);
		e.HP -= damage;
		Debug.Log("=== Player" + playernum + " Attack! ===");
		Debug.Log("Damage: " + damage);
		Debug.Log("Enemy" + enemynum + "HP: " + e.HP);
	}
}