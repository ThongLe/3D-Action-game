using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public StateMachine stateMachine;
    private NavMeshAgent agent;
    public Path path;
    public NavMeshAgent Agent { get => agent; }
    public GameObject Player { get => player; }

    public string currentState;

    private Vector3 lastKnowPos;
    public Vector3 LastKnowPos { get => lastKnowPos; set => lastKnowPos = value; }
    public GameObject player;
    [Header("Sight Values")]
    public float sightDistance = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight;
    [Header("Weapon Values")]
    public Transform ShootPointer;
    public float fireRate;
    //[Range(0.1f,10f)]
    

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialize();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
    }
    public Boolean CanSeePlayer()
    {
        if (player != null)
        {
            if(Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angletoPlayer = Vector3.Angle(targetDirection, transform.forward);
                if(angletoPlayer >= -fieldOfView && angletoPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo,sightDistance))
                    {
                        if (hitInfo.transform.gameObject == player)
                            return true;
                    }
                        Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                 
                    if (Physics.Raycast(ray, out RaycastHit hit, sightDistance))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                
            }
        
        }
        return false;


    }


}
