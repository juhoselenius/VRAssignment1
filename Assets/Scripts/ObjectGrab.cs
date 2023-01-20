using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectGrab : MonoBehaviour
{
    public XRRayInteractor rayInteractor;
    
    public InputActionReference rotationReference = null;

    public GameObject selectable;

    public float rotationAngle;

    private float length;
    private float currentRotation;

    // Update is called once per frame
    void Update()
    {
        currentRotation = rotationReference.action.ReadValue<Quaternion>().z * 100;

        if(gameObject.name == "LeftHand Controller")
        {
            if (currentRotation < rotationAngle)
            {
                RaycastHit hit;
                if (rayInteractor.TryGetCurrent3DRaycastHit(out hit))
                {
                    if (hit.collider.gameObject.name == "Cube")
                    {
                        selectable = hit.collider.gameObject;

                        //Testi
                        selectable.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

                        length = Vector3.Distance(transform.position, selectable.transform.position);

                        selectable.transform.GetComponent<Rigidbody>().isKinematic = true;

                        selectable.transform.position = transform.position + transform.forward * length;
                    }
                }
            }
            else
            {
                if(selectable.transform != null)
                {
                    selectable.GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
                    selectable.transform.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
        }
        else if(gameObject.name == "RightHand Controller")
        {
            if (currentRotation > rotationAngle)
            {
                RaycastHit hit;
                if (rayInteractor.TryGetCurrent3DRaycastHit(out hit))
                {
                    if (hit.collider.gameObject.name == "Sphere")
                    {
                        selectable = hit.collider.gameObject;

                        //Testi
                        selectable.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);

                        length = Vector3.Distance(transform.position, selectable.transform.position);

                        selectable.transform.GetComponent<Rigidbody>().isKinematic = true;

                        selectable.transform.position = transform.position + transform.forward * length;
                    }
                }
            }
            else
            {
                if (selectable.transform != null)
                {
                    selectable.GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);
                    selectable.transform.GetComponent<Rigidbody>().isKinematic = false;
                }
            }
        }

    }
}
