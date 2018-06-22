﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("" + this.gameObject.name);
        this.GetComponent<Effect>().Triggereffect();
    }
}
