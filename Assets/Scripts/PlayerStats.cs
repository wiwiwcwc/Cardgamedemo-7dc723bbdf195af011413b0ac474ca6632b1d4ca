using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public int maxhealth;
    public int currenthealth;
    public int armor;
    public string playername;
    public string spec;
    public int carddraw;

    public Text healthtext;
    public Text nametext;
    public Text armortext;

    public void Takedamage(int damage){
        if (damage >= 0)
        {
            currenthealth -= damage;
        }
    }

    // Use this for initialization
    void Start () {
        currenthealth = maxhealth;
        healthtext.text = "" + currenthealth+"/"+maxhealth;
        //this.gameObject.SetActive(false);
        //nametext.text = playername;
	}
	
	// Update is called once per frame
	void Update () {
        healthtext.text = "" + currenthealth + "/" + maxhealth;
        armortext.text = "" + armor + "";
    }
}
