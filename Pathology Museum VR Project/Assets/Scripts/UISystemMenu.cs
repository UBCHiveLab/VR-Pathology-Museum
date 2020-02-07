using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISystemMenu : MonoBehaviour
{
    public Transform content;
    public UISystemButton systemButtonsPrefab;

    private UISystemButton selectedButton;

    public void Create(Dictionary<BodySystem, Sprite> systemSprites)
    {
        foreach (BodySystem system in Enum.GetValues(typeof(BodySystem)))
        {
            if (system == BodySystem.NONE) continue;

            UISystemButton systemButton = Instantiate(systemButtonsPrefab, content);
            systemButton.SetSystem(this, system, systemSprites[system]);
        }
    }

    public void Select(UISystemButton button)
    {
        selectedButton?.Selected(false);
        selectedButton = button;
        selectedButton?.Selected(true);
    }

    private void Start()
    {
        transform.localScale = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
