using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	public int RotVal;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, RotVal) * Time.deltaTime);
    }
}