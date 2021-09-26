using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _lineRenerer;

    [SerializeField]
    [Range(3, 30)]
    private int _lineSegmentCount = 20;

    private List<Vector3> _linePoints = new List<Vector3>();

    #region Singleton

    public static TrajectoryLine Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public void GetTraj(Vector3 forcevector, Rigidbody rigidBody, Vector3 startingPoint)
    {

        Vector3 velocity = (forcevector / rigidBody.mass) * Time.fixedDeltaTime;

        float FlightDuration = (2 * velocity.y) / Physics.gravity.y;

        float stepTime = FlightDuration / _lineSegmentCount;

        _linePoints.Clear();

        for(int i = 0; i < _lineSegmentCount; i++)
        {
            float stepTimePassed = stepTime * i;

            Vector3 MovementVector = new Vector3(
                x: velocity.x * stepTimePassed,
                y: velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
                z: velocity.z * stepTimePassed);

            _linePoints.Add(item: -MovementVector + startingPoint);
        }

        _lineRenerer.positionCount = _linePoints.Count;
        _lineRenerer.SetPositions(_linePoints.ToArray());


    }

    public void HideLine()
    {
        _lineRenerer.positionCount = 0;
    }
}