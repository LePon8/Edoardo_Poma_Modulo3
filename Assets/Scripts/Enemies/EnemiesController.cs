using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : Damag
{
    [SerializeField] float enemySpeed;
    [SerializeField] int takeDamage;
    [SerializeField] Points[] points;

    Torretta_controller torretta_controller;

    private void OnValidate()
    {
        
    }

    protected override void Awake()
    {
        base.Awake();
        torretta_controller = GameObject.Find("TorrettaSubMac").GetComponent<Torretta_controller>();
        torretta_controller = GameObject.Find("TorrettaOneShoot").GetComponent<Torretta_controller>();
    }
    void Start()
    {
        
        SetUpPatrolPoints();
    }

    
    void Update()
    {
        //Distance();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(takeDamage);
            Destroy(other.gameObject);
        }
    }

    protected override void TakeDamage(int dmg)
    {
        base.TakeDamage(dmg);
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            torretta_controller.targetsInrange.Remove(gameObject);
        }
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
