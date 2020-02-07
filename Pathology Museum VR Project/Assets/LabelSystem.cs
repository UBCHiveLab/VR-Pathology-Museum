using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelSystem : MonoBehaviour
{
    public Material lineMaterial;
    public Label[] labels;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var label in labels)
        {
            label.Create(lineMaterial);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var label in labels)
        {
            label.Update();
        }
    }

    [System.Serializable]
    public class Label
    {
        public TMPro.TextMeshPro label;
        public Transform point;
        private LineRenderer lineRenderer;

        public void Create(Material lineMaterial)
        {
            lineRenderer = label.gameObject.AddComponent<LineRenderer>();
            lineRenderer.positionCount = 2;
            lineRenderer.useWorldSpace = true;
            lineRenderer.material = lineMaterial;
            lineRenderer.SetPosition(0, label.transform.position);
            lineRenderer.SetPosition(1, point.position);
            lineRenderer.startColor = Color.white;
            lineRenderer.endColor = Color.white;
            lineRenderer.startWidth = 0.005f;
            lineRenderer.endWidth = 0.0f;
        }

        public void Update()
        {
            label.transform.rotation = Quaternion.identity;
            lineRenderer.SetPosition(0, label.transform.position);
            lineRenderer.SetPosition(1, point.position);
        }
    }
}
