using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manamanager : MonoBehaviour {

    // Use this for initialization
    public int MaxMana;
    public int CurrentMana;
    public Text manatext;
    
	void Start () {
        CurrentMana = MaxMana;
        manatext.text = "Mana " + CurrentMana + "/" + MaxMana;
	}
	
	// Update is called once per frame
	void Update () {

        var manadisplay = GameObject.Find("ManaDisplay");
        manadisplay.GetComponent<Text>().text = "" + CurrentMana + "/" + MaxMana;
    }
}
