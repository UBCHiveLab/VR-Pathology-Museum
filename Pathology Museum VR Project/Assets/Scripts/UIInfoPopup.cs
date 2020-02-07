using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInfoPopup : MonoBehaviour
{
    public TMPro.TextMeshProUGUI title;
    public TMPro.TextMeshProUGUI subtitle;
    public TMPro.TextMeshProUGUI infoText;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;

    }

    public void Show(OrganData data)
    {
        if (string.Compare(data.disease, "healthy", true) == 0)
        {
            title.text = data.organ.Name();
            subtitle.text = "";
        }
        else
        {
            title.text = data.disease;
            subtitle.text = data.organ.Name();
        }
        infoText.text = data.info;
    }
}
