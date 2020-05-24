using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;
    void Start() {
        
    }

    private void OnParticleCollision(GameObject other) {
        --hitPoints;
        if (hitPoints <= 0) {
            Destroy(gameObject);
        }
    }

}
