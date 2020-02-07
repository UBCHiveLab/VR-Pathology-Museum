using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class TableManager : MonoBehaviour
{
    public NVRPlayer Player;
    private Vector3 HeadPosition;
    private Vector3 DistanceBwtnTableAndHead = new Vector3(1.46f, -0.33f, 0.25f);
    // Start is called before the first frame update
    void Start()
    {
        HeadPosition = Player.Head.transform.position;
        PositionObject();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PositionObject()
    {
        transform.position = HeadPosition + DistanceBwtnTableAndHead;

    }
}
