using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISystemButton : MonoBehaviour
{
    public Button button;
    public Image image;
    public TMPro.TextMeshProUGUI text;

    private BodySystem system;

    public void SetSystem(UISystemMenu systemMenu, BodySystem system, Sprite sprite)
    {
        this.system = system;

        image.sprite = sprite;
        text.text = system.Name();
        button.onClick.AddListener(() => { systemMenu.Select(this); });
        button.onClick.AddListener(() => { AppManager.Instance.SelectSystem(system); });
    }

    public void Selected(bool state)
    {
        button.image.color = state ? new Color(0.9f, 0.9f, 0.5f) : Color.white;
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
