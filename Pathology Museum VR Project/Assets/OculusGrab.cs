using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusGrab : MonoBehaviour
{

    // identifying objects
    public GameObject CollidingObject;
    public GameObject objectInHand;
    public GameObject handParent;
    public OculusGrab otherController;
    public float scaleFactor = 5;
    public Material defaultMaterial;
    public Material nudgingMaterial;

    private Renderer[] renderers;
    private bool isGrabing;
    private bool isScaling;
    private float distanceBetweenControllers;

    public bool isRight;

    void Start()
    {
    }
    // trigger functions after adding trigger zones to controllers and adding script to controllers
    public void OnTriggerEnter(Collider other) //picking up objects with rigidbodies
    {
        if (other.gameObject && other.gameObject.CompareTag("Structure"))
        {
            CollidingObject = other.gameObject;
            if (renderers == null) renderers = handParent.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in renderers)
            {
                rend.material = nudgingMaterial;
            }
        }
    }
    public void OnTriggerExit(Collider other) // releasing those objects with rigidbodies
    {
        CollidingObject = null;
        if (renderers == null) renderers = handParent.GetComponentsInChildren<Renderer>();
        foreach(Renderer rend in renderers)
        {
            rend.material = defaultMaterial;
        }
    }

    void Update() // refreshing program confirms trigger pressure and determines whether holding or releasing object
    {
        float triggerValue = (!isRight) ? 
            OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) + OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) : 
            OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) + OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        //Debug.Log(triggerValue);
        if (triggerValue > 0.2 && CollidingObject)
        {
            if(!isGrabing)
                GrabObject();
            isGrabing = true;
        }
        if (triggerValue < 0.2 && objectInHand)
        {
            ReleaseObject();
            isGrabing = false;
            isScaling = false;
            otherController.StopScaling();
        }

        if(isScaling)
        {
            float newDistance = Vector3.Distance(transform.position, otherController.transform.position);
            float delta = newDistance - distanceBetweenControllers;

            if(objectInHand)
            {
                Vector3 newScale = objectInHand.transform.localScale + Vector3.one * delta * scaleFactor;
                if(newScale.x > 0.5f)
                {
                    objectInHand.transform.localScale = newScale;

                }
                else
                {
                    
                    OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
                    OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.LTouch);
                }
            }

            distanceBetweenControllers = newDistance;
        }
    }

    public void GrabObject() //create parentchild relationship between object and hand so object follows hand
    {
        objectInHand = CollidingObject;
        if(objectInHand.transform.parent != null && objectInHand.transform.parent == otherController.transform)
        {
            distanceBetweenControllers = Vector3.Distance(transform.position, otherController.transform.position); 
            isScaling = true;
            otherController.ReleaseObject();
        }
        else
        {
            objectInHand.transform.SetParent(this.transform);
            objectInHand.GetComponent<Rigidbody>().isKinematic = true;
        }
        GlowyHeartControl TempControl = objectInHand.GetComponentInChildren<GlowyHeartControl>();
        if(TempControl != null)
        {
            TempControl.SelfDestruct();
        }
    }

    public void StopScaling()
    {
        isGrabing = false;
        isScaling = false;
    }

    public void ReleaseObject() //removing parentchild relationship so you drop the object
    {
        if(objectInHand && objectInHand.GetComponent<Rigidbody>())
            objectInHand.GetComponent<Rigidbody>().isKinematic = false;
        objectInHand.transform.SetParent(null);
        objectInHand = null;
    }
}