using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Paramaters
    [SerializeField] Transform objectToPan;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem projectileParticle;

    //State
    Transform targetEnemy;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        findClosestEnemy();
        if (targetEnemy) {
            objectToPan.LookAt(targetEnemy);
            fireAtEnemy();
        } else { enableEmission(false); }
    }

    private void fireAtEnemy() {
        float distaceToEmemy = Vector3.Distance(targetEnemy.transform.position, gameObject.transform.position);
        if (distaceToEmemy <= attackRange) { enableEmission(true); } else { enableEmission(false); }
    }
    private void findClosestEnemy() {
        EnemyDamage[] enemies = FindObjectsOfType<EnemyDamage>(); // THIS IS SLOW, should be something else
        if (enemies.Length == 0) { return; }
        Transform closestEnemy = enemies[0].transform;

        foreach (EnemyDamage enemy in enemies) {
            closestEnemy = GetClosest(closestEnemy.transform, enemy.transform);
        }

        targetEnemy = closestEnemy;
    }
    private Transform GetClosest(Transform current, Transform compare) {
        float currentDistance = Vector3.Distance(current.transform.position, transform.position);
        float compareDistance = Vector3.Distance(compare.transform.position, transform.position);
        if (compareDistance < currentDistance) {
            return compare;
        } else {
            return current;
        }
    }
    private void enableEmission(bool isActive) {
        var emission = projectileParticle.emission;
        emission.enabled = isActive;
    }
}
