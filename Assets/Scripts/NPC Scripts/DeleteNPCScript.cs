using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteNPCScript : MonoBehaviour
{
    //public GameObject SpawnObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CustomerNPC")
        {
            Destroy(other.gameObject);
            //SpawnObject.GetComponent<SpawnNPCScript>().decreaseNPC();
        }
    }
}
