using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

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
    private OrganSpawner orgSpawn;
    private LoadAssetBundles bundleLoader; // used for spawning organs via asset bundles stored remotely
    private OrganData[] organsData;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        uiManager = FindObjectOfType<UIManager>();
        bundleLoader = FindObjectOfType<OrganSpawner>().GetComponent<LoadAssetBundles>();
        orgSpawn = FindObjectOfType<OrganSpawner>().GetComponent<OrganSpawner>();

        organsData = Resources.LoadAll<OrganData>("Organs/");
        PreloadAllAssetBundles();
    }

    private void PreloadAllAssetBundles()
    {
        foreach(OrganData organ in organsData)
        {
            string bundleName = organ.bundlePath.Name();
            bundleLoader.LoadAssetBundle(bundleName);
        }
    }

    public void SelectSystem(BodySystem system)
    {
        if (system == BodySystem.FEMALE_REPRODUCTIVE || system == BodySystem.MALE_REPRODUCTIVE)
        {
            audioSource.PlayOneShot(wrongButtonSound);
            return;
        }

        audioSource.PlayOneShot(pressButtonSound);
        uiManager.OnSystemSelected(system, FindOrgansFromSystem(system));
    }

    public void SelectOrgan(OrganData data, bool updateDiseaseList = false)
    {
        string bundleName = data.bundlePath.Name();
        string prefabName = data.model.Name();

        orgSpawn.SpawnOrgan(bundleLoader.bundleList[bundleName], prefabName, updateDiseaseList);

        uiManager.OnOrganSelected(data);
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
