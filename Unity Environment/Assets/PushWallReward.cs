using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class PushWallReward : MonoBehaviour {

	public PushToWallAgent theAgent;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.gameObject.tag == "wall")
		{
			theAgent.WellDone();
		}
	}



}
