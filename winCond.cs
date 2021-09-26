using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winCond : MonoBehaviour
{
	SphereCollider win;
	void OnTriggerEnter(Collider other)
	{
		other = this.win;
		if (other.name == "Ball")
		{

			Debug.Log("Winnished");

		}


	}
}
