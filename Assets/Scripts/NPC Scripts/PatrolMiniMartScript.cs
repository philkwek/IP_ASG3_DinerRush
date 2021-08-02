using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMiniMartScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Merchant_AI" && gameObject.name == "Target_0")
        {
            other.gameObject.GetComponent<MerchantNPCScript>().patrol_2();

        } else if (other.gameObject.tag == "Merchant_AI" && gameObject.name == "Target_1")
        {
            other.gameObject.GetComponent<MerchantNPCScript>().patrol_3();

        } else if (other.gameObject.tag == "Merchant_AI" && gameObject.name == "Target_2")
        {
            other.gameObject.GetComponent<MerchantNPCScript>().patrol_4();

        } else if (other.gameObject.tag == "Merchant_AI" && gameObject.name == "Target_3")
        {
            other.gameObject.GetComponent<MerchantNPCScript>().patrol_1();
        }
    }
}
