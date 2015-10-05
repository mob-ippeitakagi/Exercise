using UnityEngine;
using System.Collections;

class Charactor
{
	public string NAME;
	public int HP;
	public int AttackPower;
	public string Attribute;

	public Charactor(string name,int hp,int attack,string attribute){
		NAME = name;
		HP = hp;
		AttackPower = attack;
		Attribute = attribute;
	}

	public virtual void Attack(Charactor charactor)
	{
		int damage = UnityEngine.Random.Range (1, AttackPower + 1);
		Debug.Log ("=== " + NAME + " Attack! ===");
		if (Attribute == "red") {
			if (charactor.Attribute == "green") {
				damage *= 2;
				Debug.Log("ダメージ2倍");
			} else if (charactor.Attribute == "blue") {
				damage /= 2;
				Debug.Log("ダメージ半減");
			}
		} else if (Attribute == "blue") {
			if (charactor.Attribute == "red") {
				damage *= 2;
				Debug.Log("ダメージ2倍");
			} else if (charactor.Attribute == "green") {
				damage /= 2;
				Debug.Log("ダメージ半減");
			}
		} else if (Attribute == "green") {
			if (charactor.Attribute == "blue") {
				damage *= 2;
				Debug.Log("ダメージ2倍");
			} else if (charactor.Attribute == "red") {
				damage /= 2;
				Debug.Log("ダメージ半減");
			}
		}
		damage = Mathf.Max(damage,1);
		charactor.HP -= damage;
		Debug.Log ("Damage: " + damage);
		Debug.Log (charactor.NAME + "HP: " + charactor.HP);
	}
}