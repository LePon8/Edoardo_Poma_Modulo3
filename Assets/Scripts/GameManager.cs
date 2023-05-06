using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;



    [SerializeField] public Points[] mapPoints;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GM is null");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }



}
