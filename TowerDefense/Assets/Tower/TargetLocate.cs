using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocate : MonoBehaviour
{
    [SerializeField] private Transform weapon;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon();
    }

    void AimWeapon()
    {
        weapon.LookAt(target);
    }
}
