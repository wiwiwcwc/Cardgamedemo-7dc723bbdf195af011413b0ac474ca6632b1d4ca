using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// 这个是处理玩家卡片的效果
public class Effect : MonoBehaviour {

    GameObject target;

    public void Dealdamage(int damage)      // 玩家对怪物造成伤害， 以后要改一下对象
    {
        var stats = this.gameObject.GetComponent<Stats>();
        if (stats.aoe == false)
        {

            
            var targets = GameObject.FindGameObjectsWithTag("Enemy");


            if (damage > 0)
            {
                targets[0].GetComponent<EnemyStats>().Currenthealth -= damage;
                //targets[0].GetComponent<EnemyStats>().Currenthealth -= damage;

            }
        }
        else
        {
           var targets = GameObject.FindGameObjectsWithTag("Enemy");
            if (damage>0)
            {
                foreach  (var target in targets)
                {
                    target.GetComponent<EnemyStats>().Currenthealth -= damage;
                } 
            }
            

        }
    }

    public void Increasearmor(int armor)
    {
        target = GameObject.FindGameObjectWithTag("Player");

        if (armor >= 0)
        {
            target.GetComponent<PlayerStats>().armor += armor;
        }

    }


    //弃牌 还么写好
    public void Discard(int number)
    {
        var hand = GameObject.FindGameObjectWithTag("Player");

    }


    public void Triggereffect()        // 点击后的效果
    {
        var stats = this.transform.GetComponent<Stats>();
        var mana = GameObject.Find("Mana").GetComponent<Manamanager>();

        if (stats.cost <= mana.CurrentMana)
        {
            //Debug.Log("" + this.gameObject.name + "effects has triggered");
            Dealdamage(stats.attackdamage);
            Increasearmor(stats.armor);
            mana.CurrentMana -= stats.cost;
        }
        //触发完就送入坟场
      
        var handmanger = GameObject.Find("Hand").GetComponent<HandManager>();
        handmanger.Discardfromhand(this.gameObject);

    }




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
