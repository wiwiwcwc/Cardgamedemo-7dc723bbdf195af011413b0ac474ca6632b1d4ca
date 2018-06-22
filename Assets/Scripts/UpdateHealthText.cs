using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateHealthText : MonoBehaviour {

    // 显示怪物血量、


	// Use this for initialization
	void Start () {

        var health = this.transform.parent.GetComponent<EnemyStats>();



        this.transform.GetComponent<Text>().text = health.Currenthealth+"/"+health.Maxhealth;

    }

    // Update is called once per frame
    void Update () {
        var health = this.transform.parent.GetComponent<EnemyStats>();
        this.transform.GetComponent<Text>().text = health.Currenthealth + "/" + health.Maxhealth;

    }
}
