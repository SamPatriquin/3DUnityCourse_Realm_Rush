using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Cube))]
public class CubeEditor : MonoBehaviour {
    Cube cube;

    private void Awake() {
        cube = GetComponent<Cube>();
    }
    void Update() {

        snapToGrid();
        updateLabel();
    }

    private void snapToGrid() {
        Vector2Int gridPos = cube.getGridPos();
        int gridSize = cube.getGridSize();
        transform.position = new Vector3(gridPos.x, 0f, gridPos.y);
    }

    private void updateLabel() {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        int gridSize = cube.getGridSize();
        Vector2Int gridPos = cube.getGridPos();
        string label = gridPos.x / gridSize + "," + gridPos.y / gridSize;
        textMesh.text = label;
        gameObject.name = label;
    }
}
