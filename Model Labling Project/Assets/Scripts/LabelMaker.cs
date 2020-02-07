using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelMaker : MonoBehaviour
{
    public GameObject centralObject;
    public Material lineMaterial;
    public InterestPointConstructor[] points;
    public InterestPointGroup pointGroup;

    void Start()
    {
        pointGroup = new InterestPointGroup(centralObject, 2, lineMaterial, points);
    }

    void Update()
    {
        //pointGroup.OnMove();
    }
}
