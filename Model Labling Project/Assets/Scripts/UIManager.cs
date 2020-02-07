using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // position of menus to the left of user
    private readonly Vector3 SYSTEM_MENU_FINAL_REST_POSITION = new Vector3(-1f, 1.0f, 1.5f);
    private readonly Vector3 ORGAN_MENU_FINAL_REST_POSITION = new Vector3(-1f, 0.2f, 1.5f);

    // position of system menu on top of organ menu
    private Vector3 SYSTEM_MENU_FIRST_REST_POSITION;

    // controllers for nudging
    public GameObject bothControllers;
    public Quaternion controllerStartRotation;
    public enum ControllerPart { BOTH_TRIGGERS, TRIGGER, A_BUTTON };
    public enum UIInstructions { ZOOM_IN, ZOOM_OUT, GRAB, SELECT};

    public UISystemMenu systemMenu;
    public UIOrganMenu organMenu;
    public UIInfoPopup infoPopup;
    public UIDiseaseMenu diseaseMenu;
    public UIControllerNudge controllerNudge;
    public Instructions_Popup instructionsPopup;

    public Animator rotateController;

    private Dictionary<BodySystem, Sprite> systemToSprite;
    [Header("System Sprites")]
    public Sprite cardiovascularSprite;
    public Sprite nervousSprite;
    public Sprite gastrointestinalSprite;
    public Sprite respiratorySprite;
    public Sprite maleReproductiveSprite;
    public Sprite femaleReproductiveSprite;

    private Dictionary<Organ, Sprite> organToSprite;
    [Header("Organ Sprites")]
    public Sprite heartSprite;
    public Sprite brainSprite;
    // Start is called before the first frame update
    void Start()
    {
        bothControllers.SetActive(false);
        systemToSprite = new Dictionary<BodySystem, Sprite>()
        {
            { BodySystem.CARDIOVASCULAR, cardiovascularSprite },
            { BodySystem.NERVOUS, nervousSprite },
            { BodySystem.GASTROINTESTINAL, gastrointestinalSprite },
            { BodySystem.RESPIRATORY, respiratorySprite },
            { BodySystem.MALE_REPRODUCTIVE, maleReproductiveSprite },
            { BodySystem.FEMALE_REPRODUCTIVE, femaleReproductiveSprite }
        };

        organToSprite = new Dictionary<Organ, Sprite>()
        {
            { Organ.HEART, heartSprite },
            { Organ.BRAIN, brainSprite }
        };

        systemMenu.Create(systemToSprite);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnStartButtonPressed()
    {   
        StartCoroutine(ScaleCanvas(systemMenu.transform, Vector3.one, 1f));
        StartCoroutine(ShowAllInstructions());
    }

    public void OnSystemSelected(BodySystem system, OrganData[] organs)
    {

        if (systemMenu.transform.localPosition != SYSTEM_MENU_FINAL_REST_POSITION)
        {  
            if(systemMenu.transform.localPosition != SYSTEM_MENU_FIRST_REST_POSITION)
            {
                //move system menu on top of organ menu
                SYSTEM_MENU_FIRST_REST_POSITION = systemMenu.transform.localPosition + new Vector3(0, 0.8f, 0);
                StartCoroutine(MoveCanvas(systemMenu.transform, SYSTEM_MENU_FIRST_REST_POSITION, 1f));
            }

        }
            
        
        
        organMenu.CreateButtons(organs, organToSprite);
        StartCoroutine(ScaleCanvas(organMenu.transform, Vector3.one, 1f));


    }

    public void OnOrganSelected(OrganData data)
    {   

        //move both menus to the left of user
        StartCoroutine(MoveCanvas(organMenu.transform, ORGAN_MENU_FINAL_REST_POSITION, 1f));
        StartCoroutine(MoveCanvas(systemMenu.transform, SYSTEM_MENU_FINAL_REST_POSITION, 1f));

        StartCoroutine(ScaleCanvas(organMenu.transform, Vector3.one * 0.7f, 1f));
        StartCoroutine(ScaleCanvas(systemMenu.transform, Vector3.one * 0.7f, 1f));

        //info on disease organ 
        infoPopup.transform.localScale = Vector3.one * 0f;
        infoPopup.Show(data);
        StartCoroutine(ScaleCanvas(infoPopup.transform, Vector3.one, 1f));

    }

    public void ShowDiseaseMenu(OrganData[] organs)
    {
        StartCoroutine(ScaleCanvas(diseaseMenu.transform, Vector3.one, 1f));
        diseaseMenu.CreateButtons(organs);
    }


    private IEnumerator MoveCanvas(Transform canvas, Vector3 position, float duration)
    {
        Vector3 startPosition = canvas.localPosition;
        float timer = 0;
        while(timer < 1)
        {
            timer += Time.deltaTime / duration;
            canvas.localPosition = Vector3.Lerp(startPosition, position, timer);
            yield return 0;
        }
    }

    private IEnumerator ScaleCanvas(Transform canvas, Vector3 scale, float duration)
    {
        Vector3 startScale = canvas.localScale;
        float timer = 0;
        while (timer < 1)
        {
            timer += Time.deltaTime / duration;
            canvas.localScale = Vector3.Lerp(startScale, scale, timer);
            yield return 0;
        }
    }

    private IEnumerator ShowAllInstructions()
    {
        StartCoroutine(ShowGrabInstructions());
        yield return new WaitForSeconds(5f);
        StartCoroutine(ShowZoomInstructions());
        yield return new WaitForSeconds(15f);
        Debug.Log("rotate controllers back");
        rotateController.SetTrigger("rotateControllersBack");
        yield return new WaitForSeconds(5f);
        StartCoroutine(ScaleCanvas (instructionsPopup.transform, Vector3.zero, 1f));
        bothControllers.SetActive(false);
        
    }

    private void RotateControllers()
    {
        rotateController.SetTrigger("rotateControllers");
    }

    private void RotateControllerBack()
    {
        rotateController.SetTrigger("rotateControllersBack");
    }

    private IEnumerator ShowGrabInstructions()
    {
        //controller nudge
        bothControllers.SetActive(true);
        RotateControllers();
        controllerNudge.CheckControllerPart(ControllerPart.TRIGGER);
        yield return new WaitForSeconds(1f);
        // show grab instructions
        instructionsPopup.Show(UIInstructions.GRAB);
        StartCoroutine(ScaleCanvas(instructionsPopup.transform, Vector3.one * 0.5f, 1f));

        yield return new WaitForSeconds(5f);

    }

    private IEnumerator ShowZoomInstructions()
    {
        //controller nudge
        bothControllers.SetActive(true);
        RotateControllers();
        yield return new WaitForSeconds(1f);
        //show zoom in instructions
        instructionsPopup.Show(UIInstructions.ZOOM_IN);
        StartCoroutine(ScaleCanvas(instructionsPopup.transform, Vector3.one * 0.5f, 1f));
        //controller zoom in movement
        controllerNudge.CheckControllerPart(ControllerPart.BOTH_TRIGGERS);
        yield return new WaitForSeconds(1f);
        controllerNudge.ControllerZoomInMovement();

        yield return new WaitForSeconds(5f);
        StartCoroutine(ShowZoomOutInstructions());
    }

    private IEnumerator ShowZoomOutInstructions()
    {
        yield return new WaitForSeconds(1f);
        //show zoom in instructions
        instructionsPopup.Show(UIInstructions.ZOOM_OUT);
        //controller zoom in movement
        controllerNudge.CheckControllerPart(ControllerPart.BOTH_TRIGGERS);
        yield return new WaitForSeconds(1f);
        controllerNudge.ControllerZoomOutMovement();
    }

    private IEnumerator ShowSelectInstructions()
    {
        //controller nudge
        bothControllers.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        controllerNudge.CheckControllerPart(ControllerPart.A_BUTTON);
        yield return new WaitForSeconds(1f);
        // show grab instructions
        instructionsPopup.Show(UIInstructions.SELECT);
        StartCoroutine(ScaleCanvas(instructionsPopup.transform, Vector3.one, 1f));

        yield return new WaitForSeconds(5f);

    }
}
