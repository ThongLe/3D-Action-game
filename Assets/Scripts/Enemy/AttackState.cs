using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{

    private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;
    
    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Perform()
    {
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
            if (shotTimer > enemy.fireRate)
            {
                Shoot();
            }
            if (moveTimer > Random.Range(3,7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
            enemy.LastKnowPos = enemy.Player.transform.position;
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 8)
            {
                stateMachine.ChangeState(new SearchState());
            }
        }
    }
    public void Shoot()
    {
        Transform shootpointer = enemy.ShootPointer;
        if (!enemy.Poisoned)
        {
            GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, shootpointer.position, enemy.transform.rotation);
            Vector3 shootDirection = (enemy.Player.transform.position - shootpointer.transform.position).normalized;
            bullet.GetComponent<Rigidbody>().velocity = shootDirection * 40;
            Debug.Log("Shoot");
            shotTimer = 0;
        }
        else
        {
            GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/PoisonBullet") as GameObject, shootpointer.position, enemy.transform.rotation);
            Vector3 shootDirection = (enemy.Player.transform.position - shootpointer.transform.position).normalized;
            bullet.GetComponent<Rigidbody>().velocity = shootDirection * 40;
            Debug.Log("Shoot");
            shotTimer = 0;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
