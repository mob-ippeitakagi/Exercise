using System.Collections;
using UnityEngine;

class Enemy : Charactor
{
	public int Turnbase;
	public int Turn;
	public Enemy(string name,int hp,int attack,string attribute,int turn) : base(name,hp,attack,attribute)
	{
		Turnbase = turn;
		Turn = turn;
	}
	public override void Attack(Charactor player){
		base.Attack (player);
		if (Turn == 0) {
			Debug.Log (NAME + " ターンリセット");
			Turn = Turnbase;
		}
	}
}