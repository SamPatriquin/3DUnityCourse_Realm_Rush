using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    const int gridSize = 10;
    Vector2Int gridPos;
    public bool isExplored = false;
    public bool isPlacable = true;
    public Cube exploredFrom;

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

    private void OnMouseOver() {
        if (Input.GetMouseButtonDown(0) && isPlacable) { // Left click
            isPlacable = false;
            FindObjectOfType<TowerFactory>().placeTower(this);
        }
    }
}
