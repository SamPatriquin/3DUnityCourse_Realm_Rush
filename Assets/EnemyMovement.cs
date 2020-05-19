using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<Cube> path;
    void Start()
    {
        StartCoroutine(followPath());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator followPath() {
        foreach (Cube cube in path) {
            transform.position = cube.transform.position;
            yield return new WaitForSeconds(1f);
        }
    }
}

