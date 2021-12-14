using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Range(0, 100)] public int health = 100;
    NavMeshAgent nav = null!;
    

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    private void Start() {
        nav.updateRotation = false;
        nav.updateUpAxis = false;
        nav.SetDestination(new Vector3(7,4,0));
    }

    void Update()
    {
        //TODO: destroy on life < 0
    }

    //TODO: show GUI life
    
}
