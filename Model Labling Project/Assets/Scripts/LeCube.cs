using NewtonVR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeCube : NVRInteractable
{
    public NVRPlayer Player;
    public float DistanceBtwnControllers;
    private float scaleFactor = 2.0f;
    private bool twoHands;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (twoHands)
        {
            Zoom();
        }
    }

    public override void BeginInteraction(NVRHand hand)
    {   
        base.BeginInteraction(hand);
        twoHands = (AttachedHands.Count == 2);

    }

    public override void EndInteraction(NVRHand hand)
    {
        base.EndInteraction(hand);
        twoHands = (AttachedHands.Count == 2);

    }

    void Zoom()
    {
        DistanceBtwnControllers = Vector3.Distance(Player.RightHand.transform.position, Player.LeftHand.transform.position);
        Debug.Log(DistanceBtwnControllers);

        if (DistanceBtwnControllers <= 0.2f)
        {   

            Debug.Log("got into if statement");

            while(DistanceBtwnControllers <= 1.0f)
            {
                transform.localScale *= scaleFactor;
                DistanceBtwnControllers = Vector3.Distance(Player.RightHand.transform.position, Player.LeftHand.transform.position);
                Debug.Log("organ size is: " + transform.localScale);
            }
        }

    }
}
