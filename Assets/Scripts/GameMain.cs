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

	int turn=1;
	State state = State.Wait;
	List<Player> playerlist =new List<Player>();	//Playerクラスのリストを作成しplayerlistに格納
	List<Enemy> enemylist =new List<Enemy>();

	void Awake(){
		this.playerlist.Add (new Player ("player1",100,15,"red"));		//playerlistにplayer情報を代入
		this.playerlist.Add (new Player ("player2",120,10,"blue"));
		this.enemylist.Add (new Enemy ("enemy1",50,10,"green",1));
		this.enemylist.Add (new Enemy ("enemy2",70,7,"red",2));
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
			Debug.Log(turn + "ターン目");
			turn++;
			foreach (Player player in playerlist) {
				foreach (Enemy enemy in enemylist) {
					if(player.HP > 0){
						if (enemy.HP > 0) {	//enemyが生きているかどうか
							player.Attack (enemy);
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
				if(enemy.Turn == 0){
					foreach (Player player in playerlist) {
						if(enemy.HP > 0){
							if (player.HP > 0) {
								enemy.Attack (player);
								break;
							}
						}
					}
				}
				else{
					Debug.Log("=== "+enemy.NAME+" あと"+enemy.Turn+"ターンで攻撃 ===");
					enemy.Turn--;
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
