using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganSpawner : MonoBehaviour
{
    public Transform healthySpawnLocation;
    public Transform diseasedSpawnLocation;

    private GameObject healthyOrgan;
    private GameObject diseasedOrgan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnOrgan(OrganData data, bool healthy)
    {
        // GameObject model = Instantiate(data.model, ((healthy) ? healthySpawnLocation.position : diseasedSpawnLocation.position), Quaternion.identity, transform);
        // model.transform.localScale = Vector3.one;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(healthySpawnLocation.position, 0.2f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(diseasedSpawnLocation.position, 0.2f);
    }
}
