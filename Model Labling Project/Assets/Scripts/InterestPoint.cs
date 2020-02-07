using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InterestPointGroup
{
    GameObject c;
    float radius;
    public float radiusScale;
    public InterestPoint[] points;
    public Camera camera;

    public InterestPointGroup(GameObject go, float rScale, Material lineMaterial, params InterestPoint[] ps)
    {
        radiusScale = rScale;
        centralObject = go;
        points = ps;
        camera = Camera.main;
        OnMove();
    }
    public InterestPointGroup(GameObject go, float rScale, Material lineMaterial, params InterestPointConstructor[] psc)
    {
        radiusScale = rScale;
        centralObject = go;
        camera = Camera.main;

        points = new InterestPoint[psc.Length];
        for (int i = 0; i < psc.Length; i++)
        {
            points[i] = new InterestPoint(psc[i], lineMaterial);
        }
        OnMove();
    }

    public void OnMove()
    {
        Vector3 v;
        Vector3 cScreenSpace = camera.WorldToViewportPoint(c.transform.position);
        foreach (InterestPoint p in points)
        {
            v = p.CirclePosition(camera, c, radius);
            v = camera.WorldToViewportPoint(v);
            InterestPoint.MoveLabel(p, v, v - cScreenSpace);
        }
    }

    public GameObject centralObject
    {
        set { c = value; radius = radiusScale * c.GetComponent<MeshFilter>().mesh.bounds.extents.magnitude; }
        get { return c; }
    }
}

public class InterestPoint
{
    public string text;
    public GameObject point;
    public GameObject label;
    public LineRenderer lineRenderer;
    public Transform rectTransform;
    Vector3 circlePoint;

    public TextMeshPro textObject;

    public InterestPoint(string s, GameObject go, GameObject l)
    {
        text = s;
        point = go;
        label = l;
        rectTransform = label.GetComponent<Transform>();
        //rectTransform.offsetMin = Vector2.zero;
        //rectTransform.offsetMax = Vector2.zero;

        textObject = label.GetComponent<TextMeshPro>();
        textObject.text = text;
        //textObject.horizontalOverflow = HorizontalWrapMode.Overflow;
        //textObject.verticalOverflow = VerticalWrapMode.Overflow;
        if (point.GetComponent<LineRenderer>() == null)
        {
            lineRenderer = point.AddComponent<LineRenderer>();
        }
        else
        {
            lineRenderer = point.GetComponent<LineRenderer>();
        }
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = false;
        lineRenderer.SetPosition(0, label.transform.position);
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.0f;
    }

    public InterestPoint(InterestPointConstructor psc, Material lineMaterial)
    {
        text = psc.text;
        point = psc.gameObject;
        label = psc.label;
        rectTransform = label.GetComponent<Transform>();
        //rectTransform.offsetMin = Vector2.zero;
        //rectTransform.offsetMax = Vector2.zero;

        textObject = label.GetComponent<TextMeshPro>();
        textObject.text = text;
        //textObject.horizontalOverflow = HorizontalWrapMode.Overflow;
        //textObject.verticalOverflow = VerticalWrapMode.Overflow;
        if (point.GetComponent<LineRenderer>() == null)
        {
            lineRenderer = point.AddComponent<LineRenderer>();
        }
        else
        {
            lineRenderer = point.GetComponent<LineRenderer>();
        }
        lineRenderer.material = lineMaterial;
        lineRenderer.positionCount = 2;
        lineRenderer.useWorldSpace = true;
        lineRenderer.SetPosition(0, label.transform.position);
        lineRenderer.startColor = Color.white;
        lineRenderer.endColor = Color.white;
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.0f;
    }

    public Vector3 CirclePosition(Camera cam, GameObject c, float r)
    {
        Vector3 fwd = cam.transform.forward;
        Vector3 v = point.transform.position - c.transform.position;
        v -= Vector3.Project(v, fwd);
        v = (v.normalized * r) + c.transform.position;
        lineRenderer.SetPosition(1, point.transform.position);//InverseTransformPoint(v));
        circlePoint = v;
        return v;
    }

    public static void MoveLabel(InterestPoint p, Vector3 v, Vector3 off)
    {
        p.lineRenderer.SetPosition(0, p.textObject.transform.position);
        //p.rectTransform.position = v;

        if (off.x > 0)
        {
            if (off.y > 0)
            {
                //p.textObject.alignment = TextAnchor.LowerLeft;
            }
            else
            {
                //p.textObject.alignment = TextAnchor.UpperLeft;
            }
        }
        else
        {
            if (off.y > 0)
            {
                //p.textObject.alignment = TextAnchor.LowerRight;
            }
            else
            {
                //p.textObject.alignment = TextAnchor.UpperRight;
            }
        }

    }

    public Vector2 viewportPosition
    {
        get { return Camera.main.WorldToViewportPoint(point.transform.position); }
    }
    public Vector3 target
    {
        get { return point.transform.position; }
    }
    public Vector3 circlePosition
    {
        get { return circlePoint; }
    }
}

[System.Serializable]
public class InterestPointConstructor
{
    public string text;
    public GameObject gameObject;
    public GameObject label;
}