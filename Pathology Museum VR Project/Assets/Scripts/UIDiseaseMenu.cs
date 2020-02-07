using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDiseaseMenu : MonoBehaviour
{
    public UIDiseaseButton diseaseButtonPrefab;
    public Transform content;

    private UIDiseaseButton[] buttons;
    private UIDiseaseButton selectedButton;

    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    public void CreateButtons(OrganData[] data)
    {
        ClearButtons();
        buttons = new UIDiseaseButton[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            buttons[i] = Instantiate(diseaseButtonPrefab, content);
            buttons[i].SetOrgan(this, data[i]);
        }
    }

    public void Select(UIDiseaseButton button)
    {
        selectedButton?.Selected(false);
        selectedButton = button;
        selectedButton?.Selected(true);
    }

    private void ClearButtons()
    {
        if (buttons == null) return;
        for (int i = 0; i < buttons.Length; i++)
        {
            Destroy(buttons[i].gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
