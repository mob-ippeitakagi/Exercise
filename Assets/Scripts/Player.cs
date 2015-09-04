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

	public void playerAttack(Enemy e)
	{
		int damage = UnityEngine.Random.Range(1, AttackPower + 1);
		e.HP -= damage;
		Debug.Log("=== " + NAME + " Attack! ===");
		Debug.Log("Damage: " + damage);
		Debug.Log(e.NAME + "HP: " + e.HP);
	}
}