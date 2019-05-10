using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class SoccerSub : Agent {

	public int suggestion;

	public string team;

	public RayPerception rayPer;
	

	public override void CollectObservations()
	{
		float rayDistance = 20f;
		float[] rayAngles = { 0f, 45f, 90f, 135f, 180f, 110f, 70f };
		string[] detectableObjects;
		if (team == "red")
		{
			detectableObjects = new string[] { "ball", "redGoal", "blueGoal",
				"wall", "redAgent", "blueAgent" };
		}
		else
		{
			detectableObjects = new string[] { "ball", "blueGoal", "redGoal",
				"wall", "blueAgent", "redAgent" };
		}

	


		List<float> firstList = rayPer.Perceive(rayDistance, rayAngles, detectableObjects, 0f, 0f);
		List<float> secondList = rayPer.Perceive(rayDistance, rayAngles, detectableObjects, 1f, 0f);
		AddVectorObs(firstList);
		AddVectorObs(secondList);

	}


	public override void AgentAction(float[] vectorAction, string textAction)
	{
		suggestion = Mathf.FloorToInt(vectorAction[0]);
	}


}
