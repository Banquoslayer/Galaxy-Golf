using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

	const float G = 667.4f;

	public static List<Gravity> Attractors;

	public Rigidbody rb;

	public bool inGravity = false;

	private Rigidbody rbToAttract;

	private GameObject ball;

	void FixedUpdate()
	{
		if (inGravity)
		{
			//rbToAttract.useGravity = false;
			Vector3 direction = rb.position - rbToAttract.position;
			float distance = direction.magnitude;

			if (distance == 0f)
			{
				return;
			}


			float forceMagnitude = G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
			Vector3 force = direction.normalized * forceMagnitude;

			rbToAttract.useGravity = false;
			rbToAttract.AddForce(force);

		}

	}

	void OnEnable()
	{
		if (Attractors == null)
			Attractors = new List<Gravity>();

		rb.mass = 0.0001f;
		Attractors.Add(this);

		Debug.Log(this);
	}

	void OnDisable()
	{
		Attractors.Remove(this);
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.name == "Ball")
		{
			
			rb.mass = 750;
			rbToAttract = other.gameObject.GetComponent<Rigidbody>();
			inGravity = true;
			//rbToAttract.useGravity = true;

		}
		

	}


}