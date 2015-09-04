using System.Collections;
using UnityEngine;

class Enemy
{
	public int HP;
	public int AttackPower;

	public Enemy(int hp,int attack){
		HP = hp;
		AttackPower = attack;
	}

	public void enemyAttack(Player p)
	{
		int damage = UnityEngine.Random.Range(1, AttackPower + 1);
		p.HP -= damage;
		Debug.Log("=== Enemy Attack! ===");
		Debug.Log("Damage: " + damage);
		Debug.Log("PlayerHP: " + p.HP);
	}
}