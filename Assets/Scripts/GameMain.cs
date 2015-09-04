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
		for (int i=0; i<2; i++) {
			this.playerlist.Add (new Player (100 * (i+1), 15 * i));		//playerlistにplayer情報を代入
		}
		for (int i=0; i<2; i++) {
			this.enemylist.Add (new Enemy (70 * (i+1), 7 * i));
		}
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
							player.playerAttack (playerlist.IndexOf(player)+1,enemy,enemylist.IndexOf(enemy)+1);
							break;
						}
					}
				}
			}
			foreach (Enemy enemy in enemylist) {
				if(enemy.HP > 0){
					state = State.EnemyAttack;
				}
				else{
					state = State.Playerwin;
				}
			}
				break;

			case State.EnemyAttack:
			foreach (Enemy enemy in enemylist) {
				foreach (Player player in playerlist) {
					if(enemy.HP > 0){
						if (player.HP > 0) {
							enemy.enemyAttack (enemylist.IndexOf(enemy)+1,player,playerlist.IndexOf(player)+1);
							break;
						}
					}
				}
			}
			foreach (Player player in playerlist) {
				if(player.HP > 0){
					state = State.Wait;
				}
				else{
					state = State.Playerlose;
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
