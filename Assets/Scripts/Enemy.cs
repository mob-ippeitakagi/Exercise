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

	public void enemyAttack(int enemynum,Player p,int playernum)
	{
		int damage = UnityEngine.Random.Range(1, AttackPower + 1);
		p.HP -= damage;
		Debug.Log("=== Enemy" + enemynum + " Attack! ===");
		Debug.Log("Damage: " + damage);
		Debug.Log("Player" + playernum + "HP: " + p.HP);
	}
}