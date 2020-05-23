﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    const int gridSize = 12;
    Vector2Int gridPos;
    public bool isExplored = false;
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public int getGridSize() {
        return gridSize;
    }

    public Vector2Int getGridPos() {
        return new Vector2Int(
                Mathf.RoundToInt(transform.position.x / gridSize),
                Mathf.RoundToInt(transform.position.z / gridSize)
            );
    }

    public void setColor(Color color) {
        transform.Find("Top").GetComponent<MeshRenderer>().material.color = color;
    }
}
