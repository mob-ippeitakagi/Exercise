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

	public void enemyAttack(string enemyname,Player p,string playername)
	{
		int damage = UnityEngine.Random.Range(1, AttackPower + 1);
		p.HP -= damage;
		Debug.Log("=== " + enemyname + " Attack! ===");
		Debug.Log("Damage: " + damage);
		Debug.Log(playername + "HP: " + p.HP);
	}
}