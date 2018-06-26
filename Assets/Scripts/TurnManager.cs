using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//管理行动顺序和回合开始结束的

public class TurnManager : MonoBehaviour {

    public int turncount = 0;
    public bool playerturn = true;     //看是不是玩家的回合
    public int playerturncount = 0;   //玩家行动了几次
    public int playerinaction= 0;       // 第几号玩家在行动
    public GameSetup a;
    private int frames=0;
    public int totalcount;


    private void Awake()
    {
        a = GameObject.Find("Canvas").GetComponent<GameSetup>();

    }

    public void EndTurn()
    {
        //引用各种变量
        turncount++;
        var enemy = GameObject.Find("Enemy").GetComponent<EnemyStats>();
        var mana = GameObject.Find("Mana").GetComponent<Manamanager>();
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        var handmanager = GameObject.Find("Hand").GetComponent<HandManager>();



        //a.player[turnofplayer].SetActive(true);
       // a.player[turnofplayer+1].SetActive(false);
        //处理回合结束时执行动作


        handmanager.Discardall(); //弃牌
        Updateturnstatus();
        if (playerturn == true)
        {
            BeginTurn();
        }//开始回合
        else
        {
            BeginEnemyturn();
        }
    }



    public void BeginTurn()
    {
        // a.player[turnofplayer].SetActive(true);
        var enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyStats>();
        var mana = GameObject.Find("Mana").GetComponent<Manamanager>();
        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();





        player.armor = 0;
        playerturncount++;
        Updateturnstatus();
        mana.CurrentMana = mana.MaxMana;

        GameObject.FindGameObjectWithTag("Deck").GetComponent<Decklist>().Draw(5);
        Debug.Log(GameObject.FindGameObjectWithTag("Deck"));


        //轮流当家做主人
        playerinaction = playerturncount % a.playercount ;
        a.player[playerinaction].SetActive(false);
        if (playerinaction + 1 == a.playercount)
        {
            playerinaction = 0;
            a.player[playerinaction].SetActive(true);
           // Debug.Log(playerinaction+"玩家启动");
        }
        else
        {
            a.player[playerinaction + 1].SetActive(true);
           // Debug.Log(playerinaction+1 + "玩家启动");

        }
    }
    public void BeginEnemyturn()
    {
        var enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyStats>();
        enemy.Takeaction();
        Debug.Log("Enemy turn");
        Updateturnstatus();
        EndTurn();

    }

    public void Updateturnstatus()
    {
        totalcount = a.playercount + a.enemycount;
            //判断下回合是不是玩家的回合
        if (turncount % totalcount > a.playercount || turncount % totalcount==0)
            {
                playerturn = false;
            }
            else
            {
                playerturn = true;
            }

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        frames++;
        var mana = GameObject.Find("Mana").GetComponent<Manamanager>();


        if (frames % 20 == 0)   //每x帧检查一次
        {
            if (mana.CurrentMana == 0)
            {
                EndTurn();
                Updateturnstatus();
            }

        }
    }
}
