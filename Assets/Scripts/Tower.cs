using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEmemy;
    [SerializeField] float attackRange = 30f;
    [SerializeField] ParticleSystem projectileParticle;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (targetEmemy) {
            objectToPan.LookAt(targetEmemy);
            fireAtEnemy();
        } else { enableEmission(false); }
    }

    private void fireAtEnemy() {
        float distaceToEmemy = Vector3.Distance(targetEmemy.transform.position, gameObject.transform.position);
        if (distaceToEmemy <= attackRange) { enableEmission(true); } else { enableEmission(false); }
    }

    private void enableEmission(bool isActive) {
        var emission = projectileParticle.emission;
        emission.enabled = isActive;
    }
}
