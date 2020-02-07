using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
///  Created by Dante Cerron, 2019. Modified by Kimberly Burke
/// </summary>
public class LoadAssetBundles : MonoBehaviour
{
    public Dictionary<string, AssetBundle> bundleList;
    // Start is called before the first frame update
    void Start()
    {
        bundleList = new Dictionary<string, AssetBundle>();
    }

    public void LoadAssetBundle(string bundleName)
    {
        StartCoroutine(GetAssetBundle(bundleName));
    }

    IEnumerator GetAssetBundle(string bundleName)
    {
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(EnvironVariables.Instance.address + bundleName);
        Debug.Log("sending request");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
            Debug.Log("Loaded: " + bundle.name + " asset bundle.");
            bundleList.Add(bundleName, bundle);
        }
    }

    // For testing purposes
    void InstantiateObjectFromBundle(AssetBundle bundle)
    {
        var prefab = bundle.LoadAsset("Heart_Healthy");
        Instantiate(prefab);
        Debug.Log("Finished instantiating");
    }
}
