using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    [SerializeField] bool selectedTor;
    [SerializeField] bool selectedBuff;
    [SerializeField] LayerMask mask;
    GameObject tor;
    GameObject buff;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraRaycast();
        //CameraBuffRaycast();
    }

    public void CameraRaycast()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit,Mathf.Infinity, mask, QueryTriggerInteraction.Ignore))
            {
                

                if (hit.collider.CompareTag("Player"))
                {
                    selectedTor = true;
                    Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
                    tor = hit.collider.gameObject;
                }
                if (hit.collider.CompareTag("Buff"))
                {
                    selectedBuff = true;
                    Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
                    buff = hit.collider.gameObject;
                }

            }

            if (selectedTor && hit.collider.CompareTag("Postazione"))
            {
                selectedTor = false;
                Debug.DrawRay(ray.origin, ray.direction * 20, Color.cyan);
                tor.transform.position = hit.collider.transform.position;
                tor.transform.rotation = hit.collider.transform.rotation;

            }

            if (selectedTor && hit.collider.CompareTag("PostazioneTorretta"))
            {
                selectedTor = false;
                Debug.DrawRay(ray.origin, ray.direction * 20, Color.yellow);
                tor.transform.position = hit.collider.transform.position;
                tor.transform.rotation = hit.collider.transform.rotation;
            }
            if (selectedBuff && hit.collider.CompareTag("PostazioneTorretta"))
            {
                selectedBuff = false;
                Debug.DrawRay(ray.origin, ray.direction * 20, Color.yellow);
                buff.transform.position = hit.collider.transform.position;
            }

        }

        
    }

    //public void CameraBuffRaycast()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit2;
    //        if(Physics.Raycast(ray2, out hit2))
    //        {
    //            if (hit2.collider.CompareTag("Buff"))
    //            {
    //                selectedBuff = true;
    //                Debug.DrawRay(ray2.origin, ray2.direction * 20, Color.red);
    //                buff = hit2.collider.gameObject;
    //            }
    //        }

    //        if (selectedBuff && hit2.collider.CompareTag("PostazioneTorretta"))
    //        {
    //            Debug.DrawRay(ray2.origin, ray2.direction * 20, Color.yellow);
    //            buff.transform.position = hit2.collider.transform.position;
    //            buff.transform.rotation = hit2.collider.transform.rotation;
    //        }

    //    }
    //}

    
}
