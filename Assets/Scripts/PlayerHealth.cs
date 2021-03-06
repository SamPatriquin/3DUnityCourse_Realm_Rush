﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] Text healthText;

    void Start() {
        healthText.text = health.ToString();
    }
    private void OnTriggerEnter(Collider other) {
        health--;
        healthText.text = health.ToString();
    }
}

