using System;
using System.Collections.Generic;
using UnityEngine;

public class IdleState:State
{
	static Vector3 initialPos = Vector3.zero;
	//static Vector3 Point1;
	//static Vector3 Point2;

	GameObject enemyGameObject = GameObject.FindGameObjectWithTag("bluebot");

    public override string Description()
    {
        return "Idle State";
    }

    public IdleState(GameObject myGameObject, GameObject enemyGameObject)
        : base(myGameObject)
    {
        this.enemyGameObject = enemyGameObject;
	}



    public override void Enter()
    {
		//Point1  = new Vector3(Random.Range(-30.0f,30.0f),0,Random.Range(-30.0f,30.0f));
		//Point2  = new Vector3(Random.Range(-30.0f,30.0f),0,Random.Range(-30.0f,30.0f));
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(-30,0,30));
		myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Add(new Vector3(30,0,-30));
        myGameObject.GetComponent<SteeringBehaviours>().path.Looped = true;            
        myGameObject.GetComponent<SteeringBehaviours>().path.draw = true;
        myGameObject.GetComponent<SteeringBehaviours>().TurnOffAll();
        myGameObject.GetComponent<SteeringBehaviours>().FollowPathEnabled = true;
    }
    public override void Exit()
    {
        myGameObject.GetComponent<SteeringBehaviours>().path.Waypoints.Clear();
    }

    public override void Update()
    {
        float range = 15.0f;           
        // Can I see the enemy?
        if ((enemyGameObject.transform.position - myGameObject.transform.position).magnitude < range)
        {
            // Is the leader inside my FOV
            myGameObject.GetComponent<StateMachine>().SwitchState(new AttackingState(myGameObject, enemyGameObject));
        }
    }
}
