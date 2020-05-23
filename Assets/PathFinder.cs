using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    // Data structures;
    Dictionary<Vector2Int, Cube> grid = new Dictionary<Vector2Int, Cube>();
    Queue<Cube> queue = new Queue<Cube>();

    //States
    bool isRunning = true;
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
        pathFind();
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

    private void checkNeighbors(Cube from) {
        if (isRunning == false) { return; }
        foreach (Vector2Int direction in directions) {
            Vector2Int searchLocation = from.getGridPos() + direction;
            try {
                Cube neighbor = grid[searchLocation];
                if (neighbor.isExplored == false) {
                    queue.Enqueue(neighbor);
                    neighbor.setColor(Color.blue);
                    neighbor.isExplored = true;
                    print("explored " + searchLocation);
                }
            } catch { } // Do nothing
        }
    }

    private void pathFind() {
        queue.Enqueue(start);
        while (queue.Count > 0 && isRunning) {
            Cube searchCenter = queue.Dequeue();
            if (searchCenter == end) { isRunning = false; }
            searchCenter.isExplored = true;
            checkNeighbors(searchCenter);
        }
    }
}
