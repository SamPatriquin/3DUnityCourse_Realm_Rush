using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Cube> grid = new Dictionary<Vector2Int, Cube>();
    void Start() {
        loadBlocks();
    }

    // Update is called once per frame
    void Update() {
      
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
}
