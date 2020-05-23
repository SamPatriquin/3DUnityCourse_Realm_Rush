using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    // Data structures;
    Dictionary<Vector2Int, Cube> grid = new Dictionary<Vector2Int, Cube>();
    Queue<Cube> queue = new Queue<Cube>();
    List<Cube> path = new List<Cube>();

    //States
    bool isRunning = true;
    [SerializeField] Cube start, end;

    Vector2Int[] directions = { 
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

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
        if (!isRunning) { return; }
        foreach (Vector2Int direction in directions) {
            Vector2Int searchLocation = from.getGridPos() + direction;
            if (grid.ContainsKey(searchLocation)) {
                Cube neighbor = grid[searchLocation];
                if (neighbor.isExplored || queue.Contains(neighbor)) { } // do nothing
                else {
                    queue.Enqueue(neighbor);
                    neighbor.isExplored = true;
                    neighbor.exploredFrom = from;
                    //print("explored " + searchLocation);
                }
            }
        }
    }

    private void breatdhFirstSearch() {
        queue.Enqueue(start);
        while (queue.Count > 0 && isRunning) {
            Cube searchCenter = queue.Dequeue();
            if (searchCenter == end) { isRunning = false; }
            searchCenter.isExplored = true;
            checkNeighbors(searchCenter);
        }
    }

    private void createPath(){
        path.Add(end);
        Cube previous = end.exploredFrom;
        while (previous != start) {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Reverse();
    }

    public List<Cube> getPath() {
        loadBlocks();
        breatdhFirstSearch();
        createPath();
        return path;
    }
}
