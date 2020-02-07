using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UIManager;

public class Instructions_Popup : MonoBehaviour
{
    public TMPro.TextMeshProUGUI title;
    public TMPro.TextMeshProUGUI grabOrganText;
    public TMPro.TextMeshProUGUI zoomInText;
    public TMPro.TextMeshProUGUI zoomOutText;
    public TMPro.TextMeshProUGUI selectMenuText;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;
        grabOrganText.transform.gameObject.SetActive(false);
        zoomInText.transform.gameObject.SetActive(false);
        zoomOutText.transform.gameObject.SetActive(false);
        selectMenuText.transform.gameObject.SetActive(false);
    }

    public void Show(UIInstructions instruction)
    {
        switch (instruction)
        {
            case UIInstructions.ZOOM_IN:
                grabOrganText.transform.gameObject.SetActive(false);
                zoomInText.transform.gameObject.SetActive(true);
                zoomOutText.transform.gameObject.SetActive(false);
                selectMenuText.transform.gameObject.SetActive(false);
                break;
            case UIInstructions.ZOOM_OUT:
                grabOrganText.transform.gameObject.SetActive(false);
                zoomInText.transform.gameObject.SetActive(false);
                zoomOutText.transform.gameObject.SetActive(true);
                selectMenuText.transform.gameObject.SetActive(false);
                break;
            case UIInstructions.SELECT:
                grabOrganText.transform.gameObject.SetActive(false);
                zoomInText.transform.gameObject.SetActive(false);
                zoomOutText.transform.gameObject.SetActive(false);
                selectMenuText.transform.gameObject.SetActive(true);
                break;
            case UIInstructions.GRAB:
                grabOrganText.transform.gameObject.SetActive(true);
                zoomInText.transform.gameObject.SetActive(false);
                zoomOutText.transform.gameObject.SetActive(false);
                selectMenuText.transform.gameObject.SetActive(false);
                break;
            default:
                break;

        }
    }
}
