using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDiseaseButton : MonoBehaviour
{
    public Button button;
    public TMPro.TextMeshProUGUI text;

    private OrganData organData;

    public void SetOrgan(UIDiseaseMenu diseaseMenu ,OrganData organData)
    {
        this.organData = organData;

        text.text = organData.disease;
        button.onClick.AddListener(() => { diseaseMenu.Select(this); });
        button.onClick.AddListener(() => { AppManager.Instance.SelectOrgan(organData); });
    }

    public void Selected(bool state)
    {
        button.image.color = state ? new Color(0.5f, 0.9f, 0.9f) : Color.white;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
