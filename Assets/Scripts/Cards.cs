using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Card", menuName ="Card") ]
public class Card : ScriptableObject {

    public int cost;
    public new string name;
    public string carddescription;
    public int attackdamage;
    public Sprite artwork;




}
