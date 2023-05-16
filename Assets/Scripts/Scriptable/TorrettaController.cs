using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorrettaController : MonoBehaviour
{
    [SerializeField] private TorrettaStats torrettaStats;

    private TorrettaMotore torrettaMotore;

    float time;

    private void Awake()
    {
        torrettaMotore = new TorrettaMotore(torrettaStats, transform);
    }

    private void Update()
    {
        torrettaMotore.RotateTorretta();
    }
}
