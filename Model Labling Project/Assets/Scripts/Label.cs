using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Label : MonoBehaviour
{
    public TMPro.TextMeshPro label;
    public Transform point;
    public Material mat;
    public LineRenderer lineRenderer;
    public MeshRenderer pointMesh;

    private void Start()
    {
        
        Create();
        //point.gameObject.GetComponent<MeshRenderer>().enabled = false;
        pointMesh.enabled = false;

    }

    private void Create()
    {
        
        //lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;
        lineRenderer.material = mat;
        lineRenderer.SetPosition(0, label.transform.position);
        lineRenderer.SetPosition(1, point.position); // TODO: origin on Organ
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        lineRenderer.startWidth = 0.005f;
        lineRenderer.endWidth = 0.0f;
    }

    void Update()
    {
        //label.transform.rotation = Quaternion.identity;
        lineRenderer.SetPosition(0, label.transform.position);
        lineRenderer.SetPosition(1, point.position); // TODO: origin on Organ
    }
}
