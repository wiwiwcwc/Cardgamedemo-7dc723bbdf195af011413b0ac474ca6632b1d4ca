using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour {

    public int carddraw=1;
    public int maxcardinhand;
    public List<GameObject> hand;



    //弃牌，送入坟场
    public void Discardfromhand(GameObject card)
    {
        var graveyard = GameObject.Find("Graveyard").GetComponent<Graveyardlist>(); //墓地
        var hand = GameObject.Find("Hand").GetComponent<HandManager>().hand;  //手牌list
        if (hand != null)
        {
            hand.Remove(card);
        }
        if (card != null)
        {
            graveyard.graveyardlist.Add(Instantiate(card));
            Destroy(card);
        }
    }

    public void Discardall()
    {
        var graveyard = GameObject.Find("Graveyard").GetComponent<Graveyardlist>();
        var hand = GameObject.Find("Hand").GetComponent<HandManager>().hand;
        //弃牌直到手牌为0
        while (hand.Count!=0)
        {
            this.Discardfromhand(hand[0]);
        }

    }
	// Use this for initialization
	void Start () {
       //GameObject.Find("Deck").GetComponent<Decklist>().Draw();
        
            //.transform.SetParent(GameObject.Find("Hand").transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
