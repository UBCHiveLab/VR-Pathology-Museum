using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOrganButton : MonoBehaviour
{
    public Button button;
    public Image image;
    public TMPro.TextMeshProUGUI text;

    private OrganData organData;

    public void SetOrgan(UIOrganMenu diseaseMenu, OrganData organData, Sprite sprite)
    {
        this.organData = organData;

        image.sprite = sprite; 
        text.text = organData.organ.Name();
        button.onClick.AddListener(() => { diseaseMenu.Select(this); });
        button.onClick.AddListener(() => { AppManager.Instance.SelectOrgan(organData, true); });
    }

    public void Selected(bool state)
    {
        button.image.color = state ? new Color(0.5f, 0.9f, 0.9f) : Color.white;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
     {
        
    }
}
