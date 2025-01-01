using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 15;
    ScoreBoard scoreBoard;

    void Start()
    {
        // 절대 Update에 쓰여선 안된다.
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }
    void OnParticleCollision(GameObject other)
    {
        PreocessHit();
        KillEnemy();
       
    }

    void PreocessHit(){
        scoreBoard.IncreaseScore(scorePerHit);
    }
    void KillEnemy(){
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }
}
