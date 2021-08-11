using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class indicatorScript : MonoBehaviour
{

    public Image fridge;
    public Image stove;
    public Image plates;
    public Image trashBin;
    public Image button;

    public Transform fridgeSpawn;
    public Transform stoveSpawn;
    public Transform plateSpawn;
    public Transform trashSpawn;
    public Transform buttonSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fridge.transform.position = Camera.main.WorldToScreenPoint(fridgeSpawn.position);
        stove.transform.position = Camera.main.WorldToScreenPoint(stoveSpawn.position);
        plates.transform.position = Camera.main.WorldToScreenPoint(plateSpawn.position);
        trashBin.transform.position = Camera.main.WorldToScreenPoint(trashSpawn.position);
        button.transform.position = Camera.main.WorldToScreenPoint(buttonSpawn.position);
    }
}
