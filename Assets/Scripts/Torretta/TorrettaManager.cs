using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorrettaManager : MonoBehaviour
{

    [SerializeField] float rotationSpeed;
    [SerializeField] float shootingTime;
    [SerializeField] float shootRange;
    [SerializeField] float bulletSpeed;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject muzzle;
    //GameObject enemy;

    float time;
    public CapsuleCollider cc;
    Buff buff;

    public List<GameObject> targetsInrange = new List<GameObject>();
    protected virtual void Awake()
    {
        //Physics.IgnoreCollision(cc, cc);
        buff = GetComponent<Buff>();
    }

    protected virtual void Start()
    {
        cc.radius = shootRange;
        cc.height = shootRange;
    }

    protected virtual void Update()
    {
        time += Time.deltaTime;
        //Raycast();
        //Distance();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            targetsInrange.Add(other.gameObject);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            targetsInrange.Remove(other.gameObject);
        }

    }


    protected virtual void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var lookPosition = targetsInrange[0].transform.position - transform.position;
            lookPosition.y = 0;
            var rotations = Quaternion.LookRotation(lookPosition);
            
            transform.rotation = Quaternion.Slerp(transform.rotation, rotations, rotationSpeed * Time.deltaTime);
            ShootingController();
        }
        
    }

    void ShootingController()
    {
        if(time >= shootingTime)
        {
            GameObject bullet = Instantiate(bulletPrefab, new Vector3(muzzle.transform.position.x, muzzle.transform.position.y, muzzle.transform.position.z), Quaternion.identity);
            bullet.GetComponent<Rigidbody>().AddForce(muzzle.transform.forward * bulletSpeed, ForceMode.Impulse);
            time = 0;
        }
    }

    //void Raycast()
    //{
    //    Ray upRay = new Ray(transform.position, transform.up);
    //    RaycastHit hit;
    //    if (Physics.Raycast(upRay, out hit, 10))
    //    {
    //        Debug.DrawRay(upRay.origin, upRay.direction * 20, Color.red);

    //        if (hit.collider.CompareTag("Buff"))
    //        {
    //            shootRange = shootRange + buff.addRange;
    //        }
    //    }
    //}

}
