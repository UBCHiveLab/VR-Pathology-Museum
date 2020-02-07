using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStructure : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Structure"))
        {
            Debug.Log("Destroy");
            Destroy(other.gameObject);
        }
    }
}
