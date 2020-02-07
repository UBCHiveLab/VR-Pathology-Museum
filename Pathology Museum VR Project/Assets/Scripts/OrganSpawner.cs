using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganSpawner : MonoBehaviour
{
    public Transform healthySpawnLocation;
    public Transform diseasedSpawnLocation;

    private GameObject healthyOrgan;
    private GameObject diseasedOrgan;

    public void SpawnOrgan(AssetBundle bundle, string prefabName, bool healthy)
    {
        GameObject prefab = (GameObject)bundle.LoadAsset(prefabName); // the model prefab
        Debug.Log(bundle);
        GameObject model = Instantiate(prefab, ((healthy) ? healthySpawnLocation.position : diseasedSpawnLocation.position), Quaternion.identity, transform);
        model.transform.localScale = Vector3.one;
        model.SetActive(true);
        model.tag = "Structure";
        Debug.Log("finished instantiating");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(healthySpawnLocation.position, 0.2f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(diseasedSpawnLocation.position, 0.2f);
    }
}
