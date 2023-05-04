using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObjects/Torretta/Stats", fileName = "TorrettaStats")]
public class TorrettaStats : ScriptableObject
{
    [SerializeField] private float turnSpeed;
    [SerializeField] private float shootRange;
    [SerializeField] private float shootTime;
    [SerializeField] private GameObject enemy;

    public float TurnSpeed { get => turnSpeed; }

    public float ShootRange { get => shootRange; }

    public float ShootTime { get => shootTime; }

    public GameObject Enemy { get => enemy; }
}
