using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOrganMenu : MonoBehaviour
{
    public UIOrganButton organButtonPrefab;
    public Transform content;

    private UIOrganButton[] buttons;
    private UIOrganButton selectedButton;

    // Start is called before the first frame update

    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    public void CreateButtons(OrganData[] data, Dictionary<Organ, Sprite> organSprites)
    {
        ClearButtons();
        Debug.Log(organSprites);
        buttons = new UIOrganButton[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            buttons[i] = Instantiate(organButtonPrefab, content);
            buttons[i].SetOrgan(this, data[i], organSprites[data[i].organ]);
        }
    }

    public void Select(UIOrganButton button)
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
}
