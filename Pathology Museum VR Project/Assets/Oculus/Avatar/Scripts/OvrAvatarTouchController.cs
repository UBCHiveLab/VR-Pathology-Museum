using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OvrAvatarTouchController : MonoBehaviour
{
    public GameObject Organ;
    public Vector2 RightJoystick;
    public Vector2 LeftJoystick;

    private float moveHorizontal;
    private float moveVertical;
    private float angleOfRotation;
    private float ROTATION_SPEED = 0.25f;
    private bool flipRot = true;


    // Start is called before the first frame update
    void Start()
    {
        //RightJoystick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        //LeftJoystick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        
    }

    // Update is called once per frame
    void Update()
    {
        RotateOrganX(RightJoystick);
        RotateOrganX(LeftJoystick);

        RotateOrganY(RightJoystick);
        RotateOrganY(LeftJoystick);
    }

    void RotateOrganX(Vector2 Joystick)
    {
        //X range of joystick, -1.0f to 1.0f
        //moveHorizontal = Joystick.x;
        //moveVeritcal = Joystick.y;
        //for testing w/out headset, move mouse
        //moveHorizontal = Input.GetAxis("Mouse X");
        //moveVertical = Input.GetAxis("Mouse Y");

        angleOfRotation = Mathf.Atan2(moveHorizontal, moveVertical) * Mathf.Rad2Deg;

        angleOfRotation = flipRot ? -angleOfRotation : angleOfRotation;

        Organ.transform.Rotate(new Vector3(0, angleOfRotation * Time.deltaTime * ROTATION_SPEED, 0));
    }

    void RotateOrganY(Vector2 Joystick)
    {
        //X range of joystick, -1.0f to 1.0f
        moveHorizontal = Joystick.x;
        moveVertical = Joystick.y;
        //for testing w/out headset, move mouse
        //moveHorizontal = Input.GetAxis("Mouse X");
        //moveVertical = Input.GetAxis("Mouse Y");

        angleOfRotation = Mathf.Atan2(moveVertical, moveHorizontal) * Mathf.Rad2Deg;

        angleOfRotation = flipRot ? -angleOfRotation : angleOfRotation;

        Organ.transform.Rotate(new Vector3(0, 0, angleOfRotation * Time.deltaTime * ROTATION_SPEED));
    }
}
