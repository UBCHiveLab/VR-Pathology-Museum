using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UIManager;

public class UIControllerNudge : MonoBehaviour
{
    public Renderer triggerRight;
    public Renderer triggerLeft;

    public Material lightUpAButtonMaterial;
    public Material lightUpRightTriggerMaterial;
    public Material lightUpLeftTriggerMaterial;
    
    public Material regularRightMaterial;
    public Material regularLeftMaterial;

    public GameObject controllerRight;
    public GameObject controllerLeft;

    private Vector3 controllerRightNewlocalPosition;
    private Vector3 controllerLeftNewlocalPosition;
    private int count = 0;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void CheckControllerPart(ControllerPart controllerPart)
    {
        switch (controllerPart)
        {
            case ControllerPart.BOTH_TRIGGERS:
                StartCoroutine(LightUpRightControllerPart(triggerRight, lightUpRightTriggerMaterial));
                StartCoroutine(LightUpLeftControllerPart(triggerLeft, lightUpLeftTriggerMaterial));
                break;
            case ControllerPart.TRIGGER:
                StartCoroutine(LightUpRightControllerPart(triggerRight, lightUpRightTriggerMaterial));
                break;
            default:
                break;

        }
    }

    public void  ControllerZoomInMovement()
    {           
        controllerRightNewlocalPosition = controllerRight.transform.localPosition + new Vector3(0.25f, 0, 0);
        controllerLeftNewlocalPosition = controllerLeft.transform.localPosition - new Vector3(0.25f, 0, 0);

        StartCoroutine(MoveControllerForZoom(controllerRight, controllerLeft, controllerRightNewlocalPosition, controllerLeftNewlocalPosition, 1f));
         
    }

    public void ControllerZoomOutMovement()
    {
        StartCoroutine(MoveControllerTogether(controllerRight, controllerLeft, controllerRight.transform.localPosition, controllerLeft.transform.localPosition, 1f));

    }

    IEnumerator LightUpRightControllerPart(Renderer lightUpRight, Material lightUpMaterial)
    {
        int counter = 0;
        while(counter < 5)
        {
            lightUpRight.material = lightUpMaterial;
            yield return new WaitForSeconds(0.5f);
            lightUpRight.material = regularRightMaterial;
            yield return new WaitForSeconds(0.5f);
            counter++;
        }

    }
    IEnumerator LightUpLeftControllerPart(Renderer lightUpLeft, Material lightUpMaterial)
    {
        int counter = 0;
        while (counter < 5)
        {
            lightUpLeft.material = lightUpMaterial;
            yield return new WaitForSeconds(0.5f);
            lightUpLeft.material = regularLeftMaterial;
            yield return new WaitForSeconds(0.5f);
            counter++;
        }

    }

    IEnumerator MoveControllerForZoom(GameObject rightController, GameObject leftController, Vector3 rightNewPos, Vector3 leftNewPos, float duration)
    {

        float timer = 0;
        Vector3 rightControllerStartlocalPosition = rightController.transform.localPosition;
        Vector3 leftControllerStartlocalPosition = leftController.transform.localPosition;

        //move away
        while (timer < 1)
        {
            timer += Time.deltaTime / duration;
            rightController.transform.localPosition = Vector3.Lerp(rightControllerStartlocalPosition, rightNewPos, timer);
            leftController.transform.localPosition = Vector3.Lerp(leftControllerStartlocalPosition, leftNewPos, timer);

            yield return 0;
        }

        yield return new WaitForSeconds(0.5f);

        rightController.transform.localPosition = rightControllerStartlocalPosition;
        leftController.transform.localPosition = leftControllerStartlocalPosition;
        if (count < 2)
        {
            ControllerZoomInMovement();
            count++;
        }
        else
        {
            count = 0;
        }

    }

    IEnumerator MoveControllerTogether(GameObject rightController, GameObject leftController, Vector3 rightStartPos, Vector3 leftStartPos, float duration)
    {
        float timer = 0;
        controllerRightNewlocalPosition = controllerRight.transform.localPosition + new Vector3(0.25f, 0, 0);
        controllerLeftNewlocalPosition = controllerLeft.transform.localPosition - new Vector3(0.25f, 0, 0);

        //move together
        while (timer < 1)
        {
            timer += Time.deltaTime / duration;
            rightController.transform.localPosition = Vector3.Lerp(controllerRightNewlocalPosition, rightStartPos, timer);
            leftController.transform.localPosition = Vector3.Lerp(controllerLeftNewlocalPosition, leftStartPos, timer);

            yield return 0;
        }
        yield return new WaitForSeconds(0.5f);

        rightController.transform.localPosition = rightStartPos;
        leftController.transform.localPosition = leftStartPos;

        if (count < 2)
        {
            ControllerZoomOutMovement();
            count++;
        } else
        {
            count = 0;
        }




    }








}
