using System.Collections;
using UnityEngine;

class Player
{
	public string NAME;
	public int HP;
	public int AttackPower;

	public Player(string name,int hp ,int attack){
		NAME = name;
		HP = hp;
		AttackPower = attack;
	}

	public void playerAttack(string playername,Enemy e,string enemyname)
	{
		int damage = UnityEngine.Random.Range(1, AttackPower + 1);
		e.HP -= damage;
		Debug.Log("=== " + playername + " Attack! ===");
		Debug.Log("Damage: " + damage);
		Debug.Log(enemyname + "HP: " + e.HP);
	}
}