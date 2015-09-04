using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMain : MonoBehaviour {

	enum State{
		Wait,
		PlayerAttack,
		EnemyAttack,
		Playerwin,
		Playerlose
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
		switch (state)
		{
			case State.Wait:
				if (Input.GetMouseButtonDown(0))
				{
					state = State.PlayerAttack;
				}
				break;
			case State.PlayerAttack:
				foreach(Player player in playerlist){
					foreach(Enemy enemy in enemylist){
						if(enemy.HP>0){	//enemyのHPが0以上かどうか
							player.playerAttack(enemy);
							break;
						}
					}
				}
			bool win=true;
			foreach(Enemy enemy in enemylist){
				if(enemy.HP>0){
					win=false;
					break;
				}
			}
			if(win){
				state=State.Playerwin;
			}
			else{
				state = State.EnemyAttack;
			}
				break;
			case State.EnemyAttack:
				foreach(Enemy enemy in enemylist){
					foreach(Player player in playerlist){
						if(player.HP>0){
							enemy.enemyAttack(player);
							break;
						}
					}
				}
			bool lose = true;
			foreach(Player player in playerlist){
				if(player.HP>0){
					lose=true;
					break;
				}
			}
			if(lose){
				state=State.Playerlose;
			}
			else{
				state=State.Wait;
			}
			state = State.Wait;
				break;
			case State.Playerwin:
					Debug.Log("=== Player Win! ===");
				break;
			case State.Playerlose:
					Debug.Log("=== Player Lose... ===");
				break;
			}

		}
	}
