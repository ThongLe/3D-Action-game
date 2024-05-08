using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int WaypointIndex;
    public float WaitTimer;

    public override void Enter()
    {
        
    }

    public override void Perform()
    {
        PatrolCycle();
        if (enemy.CanSeePlayer())
        {
            stateMachine.ChangeState(new AttackState());
        }
    }

    public override void Exit()
    {
        
    }


    public void PatrolCycle()
    {
        if (enemy.Agent.remainingDistance < 0.2f)
        {
            WaitTimer += Time.deltaTime;
            if (WaitTimer > 5)
            {
                if (WaypointIndex < enemy.path.waypoints.Count - 1)
                    WaypointIndex++;
                else
                    WaypointIndex = 0;
                enemy.Agent.SetDestination(enemy.path.waypoints[WaypointIndex].position);
                WaitTimer = 0;
            }
        }
    }


    // Start is called before the first frame update

}
