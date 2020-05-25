using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 2;
    [SerializeField] Tower towerPrefab;

    Queue<Tower> towers = new Queue<Tower>();

    public void placeTower(Cube where) {
        if (towers.Count < towerLimit) {
            instantiateTower(where);
        } else {
            moveTower(where);
        }
    }

    private void instantiateTower(Cube where) {
        Vector3 placement = new Vector3(where.transform.position.x, where.transform.position.y + 5, where.transform.position.z);
        Tower towerPlaced = Instantiate(towerPrefab, placement, Quaternion.identity);
        towerPlaced.transform.parent = this.transform;
        towerPlaced.baseCube = where;
        towers.Enqueue(towerPlaced);
        where.isPlacable = false;
    }

    private void moveTower(Cube where) {
        Tower oldTower = towers.Dequeue();
        towers.Enqueue(oldTower);
        oldTower.transform.position = new Vector3(where.transform.position.x, where.transform.position.y + 5, where.transform.position.z);
        oldTower.baseCube.isPlacable = true;
        oldTower.baseCube = where;
        where.isPlacable = false;
    }
}
