using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Cube> grid = new Dictionary<Vector2Int, Cube>();
    [SerializeField] Cube start, end;

    Vector2Int[] directions = { // Direction array
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    void Start() {
        loadBlocks();
        start.setColor(Color.green);
        end.setColor(Color.red);
    }

    // Update is called once per frame
    void Update() {
        checkCubes();
    }

    private void loadBlocks() {
        var cubes = FindObjectsOfType<Cube>();

        foreach (Cube cube in cubes) {
            if (grid.ContainsKey(cube.getGridPos())) {
                Debug.LogWarning("Overlapping block: " + cube);
            } else {
                grid.Add(cube.getGridPos(), cube);
            }
        }
    }

    private void checkCubes() {
        foreach (Vector2Int direction in directions) {
            Vector2Int searchLocation = start.getGridPos() + direction;
            try { grid[searchLocation].setColor(Color.blue); }
            catch { } // Do nothing
        }
    }
}
