using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    List<Cube> path;
    void Start() {
        List<Cube>path = FindObjectOfType<PathFinder>().getPath();
        StartCoroutine(followPath(path));
    }

    // Update is called once per frame
    void Update() {

    }

    IEnumerator followPath(List<Cube> path) {
        foreach (Cube cube in path) {
            transform.position = cube.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }
}

