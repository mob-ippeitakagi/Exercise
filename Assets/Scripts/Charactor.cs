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

		float rate = Hantei (charactor);
		damage = (int)(Mathf.Max(damage,1) * rate);
		if (rate == 2f) {
			Debug.Log ("ダメージ2倍");
		} else if (rate == 0.5f) {
			Debug.Log ("ダメージ半減");
		}
		charactor.HP -= damage;
		Debug.Log ("Damage: " + damage);
		Debug.Log (charactor.NAME + "HP: " + charactor.HP);
	}
	float Hantei(Charactor charactor){
		float rate;
		if (Attribute == "red") {
			if (charactor.Attribute == "green") {
				rate = 2f;
			} else if (charactor.Attribute == "blue") {
				rate = 0.5f;
			}
		} else if (Attribute == "blue") {
			if (charactor.Attribute == "red") {
				rate = 2f;
			} else if (charactor.Attribute == "green") {
				rate = 0.5f;
			}
		} else if (Attribute == "green") {
			if (charactor.Attribute == "blue") {
				rate = 2f;
			} else if (charactor.Attribute == "red") {
				rate = 0.5f;
			}
		}
		return rate;
	}
}