using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour {

    // Use this for initializatioz

    public  int playercount;
    public  int enemycount;
    public  GameObject[] player;
    public  GameObject[] enemy;


    private void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        playercount = player.Length;
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        enemycount = enemy.Length;
    }

    void Start () {
        Decklist decklist0 = player[0].GetComponentInChildren<Decklist>();
        Decklist decklist1 = player[1].GetComponentInChildren<Decklist>();
        HandManager handmanager0 = player[0].GetComponentInChildren<HandManager>();
        HandManager handmanager1 = player[1].GetComponentInChildren<HandManager>();
        PlayerStats stats0 = player[0].GetComponentInChildren<PlayerStats>();
        PlayerStats stats1 = player[1].GetComponentInChildren<PlayerStats>();

        decklist0.Addcard("ShieldUp", "ShieldUp", "HeroicStrike", "Whirlwind", "MortalStrike","Execute","Execute");
        decklist1.Addcard("SinisterStrike","FoK","FoK","FoK","FoK","FoK");


       // decklist0.Draw(stats0.carddraw);
       // decklist1.Draw(stats1.carddraw);

        decklist0.Shuffledeck();
        decklist1.Shuffledeck();

        //禁用多余的玩家 
        for (int i = playercount; i > 1; i--)
        {
            player[i - 1].SetActive(false);
        }

        Debug.Log(GameObject.FindGameObjectWithTag("Turn"));
        GameObject.FindGameObjectWithTag("Turn").GetComponent<TurnManager>().BeginTurn();


    }



    // Update is called once per frame
    void Update () {
		
	}
}
