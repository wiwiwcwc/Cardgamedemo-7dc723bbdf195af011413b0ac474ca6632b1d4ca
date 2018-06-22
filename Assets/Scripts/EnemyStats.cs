using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public int Maxhealth;
    public int Currenthealth;
    public List<int> damage;  
    
    // 随机抽取一个数字伤害



    //敌人回合行动内容 还没写完整
    public void Takeaction()    
    {
        Dealdamage();
      //  GameObject.FindGameObjectWithTag("Turn").GetComponent<TurnManager>().turncount++; //回合+1

    }

    public void Dealdamage()
    {
        int damagewilldeal = damage[(Random.Range(0, damage.Count()))]; //抽一个随机数造成伤害

        var target = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

        if (damagewilldeal- target.armor>=0)
        {
            target.Takedamage(damagewilldeal-target.armor);
        }

    }


	// Use this for initialization
	void Start () {

        Currenthealth = Maxhealth;
        damage.Clear();
        damage.Add(10);
        damage.Add(10);
        damage.Add(10);
    }
	
	// Update is called once per frame
	void Update () {

		
	}
}
