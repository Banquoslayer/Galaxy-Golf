using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class BallCont : MonoBehaviour
{
    public float forceMultiplier;

    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;

    public bool isShoot;

    private Vector3 forceV;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        Vector3 forceInit = (Input.mousePosition - mousePressDownPos);
        forceV = (new Vector3(forceInit.y, forceInit.y, z: forceInit.x)) * forceMultiplier;
        Debug.Log("ForceInit x: " + forceInit.x + "||ForceInit y: " + forceInit.y + "||ForceInit z: " + forceInit.z);
        Debug.Log("ForceV x: " + forceV.x + "||ForceV y: " + forceV.y + "||ForceV z: " + forceV.z);
        if (!isShoot)
            TrajectoryLine.Instance.GetTraj(forcevector: forceV, rb, startingPoint: transform.position);
    }

    private void OnMouseUp()
    {

        TrajectoryLine.Instance.HideLine();
        mouseReleasePos = Input.mousePosition;
        Shoot(Force: mousePressDownPos - mouseReleasePos);

    }

    

    void Shoot(Vector3 Force)
    {

        if (isShoot)
        {
            isShoot = false;
            return;
        }

        rb.AddForce(new Vector3(Force.y, Force.y, z: Force.x) * forceMultiplier);
        isShoot = true;
        
    }
}