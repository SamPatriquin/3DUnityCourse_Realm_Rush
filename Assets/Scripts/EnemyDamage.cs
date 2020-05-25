using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;
    [SerializeField] ParticleSystem hitParticlePrefab;
    void Start() {
        
    }

    private void OnParticleCollision(GameObject other) {
        --hitPoints;
        hitParticlePrefab.Play();
        if (hitPoints <= 0) {
            Destroy(gameObject);
        }
    }

}
