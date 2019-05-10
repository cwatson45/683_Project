using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class WallJumpSub : Agent {

	public float[] theActions;
	public GameObject ground;

	public PutTogetherAgent theAgent;
	public Rigidbody agentRB;

	public RayPerception rayPer;

	string[] detectableObjects = new string[] { "wall", "goal", "block" };

	public override void AgentAction(float[] vectorAction, string textAction)
	{
		theActions = vectorAction;
	}

	public override void CollectObservations()
	{
		float rayDistance = 20f;
		float[] rayAngles = { 0f, 45f, 90f, 135f, 180f, 110f, 70f };
		AddVectorObs(rayPer.Perceive(
			rayDistance, rayAngles, detectableObjects, 0f, 0f));
		AddVectorObs(rayPer.Perceive(
			rayDistance, rayAngles, detectableObjects, 2.5f, 2.5f));
		Vector3 agentPos = agentRB.position - ground.transform.position;

		AddVectorObs(agentPos / 20f);
		AddVectorObs(theAgent.DoGroundCheck(true) ? 1 : 0);
	}

}
