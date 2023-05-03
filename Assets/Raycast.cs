using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    [SerializeField] bool selected;

    GameObject tor;

    private void Start()
    {
        selected = false;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRaycast();
    }

    public void CameraRaycast()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            //GameObject tor = gameObject.CompareTag("Player");

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    selected = true;
                    Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
                    tor = hit.collider.gameObject;

                    //hit.collider.transform.localPosition = hit.transform.localPosition;

                }
                


            }
            if(selected && hit.collider.CompareTag("Postazione"))
            {
                selected = false;
                Debug.DrawRay(ray.origin, ray.direction * 20, Color.cyan);
                tor.transform.position = hit.collider.transform.position;
                tor.transform.rotation = hit.collider.transform.rotation;
                
            }
            
        }

        
    }

    
}
