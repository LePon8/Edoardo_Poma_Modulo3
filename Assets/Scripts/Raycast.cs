using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    [SerializeField] bool selectedTor;
    [SerializeField] bool selectedPosition;
    GameObject tor;

    private void Start()
    {
        
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
                    selectedTor = true;
                    selectedPosition = false;
                    Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
                    tor = hit.collider.gameObject;

                    //hit.collider.transform.localPosition = hit.transform.localPosition;

                }
                


            }
            if(selectedTor && hit.collider.CompareTag("Postazione"))
            {
                selectedTor = false;
                Debug.DrawRay(ray.origin, ray.direction * 20, Color.cyan);
                selectedPosition = true;
                tor.transform.position = hit.collider.transform.position;
                tor.transform.rotation = hit.collider.transform.rotation;
                
            }
            
        }

        
    }

    
}
