using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMain : MonoBehaviour {

	enum State{
		Wait,
		PlayerAttack,
		EnemyAttack,
		Playerwin,
		Playerlose,
		finish
	};

	State state = State.Wait;
	List<Player> playerlist =new List<Player>();	//Playerクラスのリストを作成しplayerlistに格納
	List<Enemy> enemylist =new List<Enemy>();

	void Awake(){
		this.playerlist.Add (new Player ("player1",100,15));		//playerlistにplayer情報を代入
		this.playerlist.Add (new Player ("player2",120,10));
		this.enemylist.Add (new Enemy ("enemy1",50,10));
		this.enemylist.Add (new Enemy ("enemy2",70,7));
	}

	void Update()
	{
		switch (state) {
			case State.Wait:
			if (Input.GetMouseButtonDown (0)) {
				state = State.PlayerAttack;
			}
				break;

			case State.PlayerAttack:
			foreach (Player player in playerlist) {
				foreach (Enemy enemy in enemylist) {
					if(player.HP > 0){
						if (enemy.HP > 0) {	//enemyが生きているかどうか
							player.playerAttack (player.NAME,enemy,enemy.NAME);
							break;
						}
					}
				}
			}
			state = State.Playerwin;
			foreach (Enemy enemy in enemylist) {
				if(enemy.HP > 0){
					state = State.EnemyAttack;
				}
			}
				break;

			case State.EnemyAttack:
			foreach (Enemy enemy in enemylist) {
				foreach (Player player in playerlist) {
					if(enemy.HP > 0){
						if (player.HP > 0) {
							enemy.enemyAttack (enemy.NAME,player,player.NAME);
							break;
						}
					}
				}
			}
			state = State.Playerlose;
			foreach (Player player in playerlist) {
				if(player.HP > 0){
					state = State.Wait;
				}
			}
			break;

			case State.Playerwin:
			Debug.Log ("=== Player Win! ===");
			state = State.finish;
				break;

			case State.Playerlose:
			Debug.Log ("=== Player Lose... ===");
			state = State.finish;
				break;

			case State.finish:
				break;
		}
	}
}
