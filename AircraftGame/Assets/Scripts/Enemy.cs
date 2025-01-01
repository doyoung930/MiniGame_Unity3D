using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int hitPoints = 4;
    ScoreBoard scoreBoard;
    GameObject parent;

    void Start()
    {
        // 절대 Update에 쓰여선 안된다.
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parent = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();
    }
    void AddRigidbody(){
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }
    void OnParticleCollision(GameObject other)
    {
        PreocessHit();
        if (hitPoints < 1)
        {
            KillEnemy();
        }           
       
    }

    void PreocessHit(){
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent.transform;
        hitPoints--;
        scoreBoard.IncreaseScore(scorePerHit);
    }
    void KillEnemy(){
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent.transform;
        Destroy(gameObject);
    }
}
