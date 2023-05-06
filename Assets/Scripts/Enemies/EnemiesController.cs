using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : Damag
{
    [SerializeField] float enemySpeed;
    [SerializeField] Points[] points;
    


    


    //[SerializeField] public List<Transform> PPoints;

    // Start is called before the first frame update
    void Start()
    {
        SetUpPatrolPoints();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        MoveToPoints();
    }

    int index = 0;
    void MoveToPoints()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, points[index].transform.position, enemySpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, points[index].transform.position) <= 0)
        {
            if (points.Length - 1 != index)
                index++;
        }
    }

    void SetUpPatrolPoints()
    {
        points = GameManager.Instance.mapPoints;
    }
}
