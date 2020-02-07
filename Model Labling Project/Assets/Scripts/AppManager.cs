using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    private static AppManager _instance;

    public static AppManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public AudioClip wrongButtonSound;
    public AudioClip pressButtonSound;
    private UIManager uiManager;
    private OrganSpawner organSpawner;
    private OrganData[] organsData;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        uiManager = FindObjectOfType<UIManager>();
        organSpawner = FindObjectOfType<OrganSpawner>();

        organsData = Resources.LoadAll<OrganData>("Organs/");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectSystem(BodySystem system)
    {
        if (system != BodySystem.CARDIOVASCULAR)
        {
            audioSource.PlayOneShot(wrongButtonSound);
            return;
        }

        audioSource.PlayOneShot(pressButtonSound);
        uiManager.OnSystemSelected(system, FindOrgansFromSystem(system));
    }

    public void SelectOrgan(OrganData data, bool updateDiseaseList = false)
    {
        uiManager.OnOrganSelected(data);
        organSpawner.SpawnOrgan(data, updateDiseaseList);

        audioSource.PlayOneShot(pressButtonSound);

        if (updateDiseaseList)
        {
            uiManager.ShowDiseaseMenu(FindDiseaseFromOrgan(data.organ));
        }
    }

    private OrganData[] FindDiseaseFromOrgan(Organ organ)
    {
        List<OrganData> datas = new List<OrganData>();
        foreach (var organData in organsData)
        {
            if (organData.organ == organ)
                datas.Add(organData);
        }
        return datas.ToArray();
    }

    private OrganData[] FindOrgansFromSystem(BodySystem system)
    {
        List<OrganData> datas = new List<OrganData>();
        foreach (var organData in organsData)
        {
            if (organData.system == system && string.Compare(organData.disease, "Healthy", true) == 0)
                datas.Add(organData);
        }
        return datas.ToArray();
    }
}
