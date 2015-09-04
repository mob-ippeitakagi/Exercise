using System.Collections;
using UnityEngine;

class Enemy
{
	public string NAME;
	public int HP;
	public int AttackPower;

	public Enemy(string name,int hp,int attack){
		NAME = name;
		HP = hp;
		AttackPower = attack;
	}

	public void enemyAttack(Player p)
	{
		int damage = UnityEngine.Random.Range(1, AttackPower + 1);
		p.HP -= damage;
		Debug.Log("=== " + NAME + " Attack! ===");
		Debug.Log("Damage: " + damage);
		Debug.Log(p.NAME + "HP: " + p.HP);
	}
}