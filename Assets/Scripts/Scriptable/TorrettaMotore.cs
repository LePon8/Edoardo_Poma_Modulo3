using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorrettaMotore
{
    private readonly TorrettaStats torrettaStats;
    private readonly Transform transformRotate;
    
    float time;

    public TorrettaMotore(TorrettaStats _torrettaStats, Transform _transformRotate)
    {
        torrettaStats = _torrettaStats;
        transformRotate = _transformRotate;
    }

    public void RotateTorretta()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transformRotate.Rotate(Vector3.up * torrettaStats.TurnSpeed * Time.deltaTime);
        }
    }

    public void ShootController()
    {
        time += Time.deltaTime;
        if(time >= torrettaStats.ShootTime)
        {
            //GameObject bullet = 
        }
    }
}
