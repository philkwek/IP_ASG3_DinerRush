using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundScript : MonoBehaviour
{
    public GameObject FadeScene;

    public int SceneIndex;

    public bool step1 = false; //these are used to tell the roundscript that an objective has been completed
    public bool step2 = false;
    public bool step3 = false;
    public bool step4 = false;

    public bool obj2_completion = false;
    public bool obj3_completion = false;

    public GameObject round_1_objective;
    public GameObject round_2_objective;
    public GameObject round_3_objective;
    public GameObject round_4_objective;

    public GameObject Spawner;

    public GameObject playerObject;
    public GameObject canvas;

    
    // Start is called before the first frame update
    private void Awake()
    {
        SceneIndex = SceneManager.GetActiveScene().buildIndex;
        canvas.GetComponent<PlayerUIScript>().RoundIndex = SceneIndex;
        playerObject.GetComponent<PlayerInventory>().RoundIndex = SceneIndex;

        if (SceneIndex == 1) //checks for what round the game is in according to scene index
        {
            round_1_objective.SetActive(true);
            Spawner.gameObject.GetComponent<SpawnNPCScript>().max_npc = 4;
            Spawner.gameObject.GetComponent<SpawnNPCScript>().roundNumber = SceneIndex;
            Spawner.SetActive(true);
            //Spawner.Spawn();
            //sets appropirate objective for the round and sets parameters for NPC spawning

        }
        else if (SceneIndex == 2)
        {
            round_2_objective.SetActive(true);
            Spawner.gameObject.GetComponent<SpawnNPCScript>().max_npc = 5;
            Spawner.gameObject.GetComponent<SpawnNPCScript>().roundNumber = SceneIndex;
            Spawner.SetActive(true);

        } else if (SceneIndex == 3)
        {
            round_3_objective.SetActive(true);
            Spawner.gameObject.GetComponent<SpawnNPCScript>().max_npc = 6;
            Spawner.gameObject.GetComponent<SpawnNPCScript>().roundNumber = SceneIndex;
            Spawner.SetActive(true);

        } else if (SceneIndex == 4)
        {
            round_4_objective.SetActive(true);
            Spawner.gameObject.GetComponent<SpawnNPCScript>().max_npc = 0;
            Spawner.gameObject.GetComponent<SpawnNPCScript>().roundNumber = SceneIndex;
            Spawner.SetActive(true);
            //Spawner.gameObject.GetComponent<SpawnNPCScript>().SpawnRamsey();

        }
    }

    void Start()
    {
        StartCoroutine(DoFadeOut());
        Invoke("openClipboard", 2.0f); 
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObject.GetComponent<PlayerInventory>().objective_completion == true && step1 == false)
        { //check for obj1 completion
            step1 = true;
            canvas.GetComponent<PlayerUIScript>().objectiveComplete(1);
            openClipboard();
            //add notification sound to indicate objective update
        }

        if (step2 == false && obj2_completion == true)
        { //checks for obj2 completion
            step2 = true;
            canvas.GetComponent<PlayerUIScript>().objectiveComplete(2);
            openClipboard();
            //add sound
        }

        if (step3 == false && obj3_completion == true)
        { //objective 3 completion check
            step3 = true;
            canvas.GetComponent<PlayerUIScript>().objectiveComplete(3);
            openClipboard();
            Spawner.SetActive(true);
        }
    }

    private void openClipboard() // opens objective clipboard
    {
        canvas.gameObject.GetComponent<PlayerUIScript>().clipboardToggle();   
    }

    IEnumerator DoFadeIn()
    {
        CanvasGroup canvasGroup = FadeScene.GetComponent<CanvasGroup>();
        Debug.Log(canvasGroup.alpha);
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime;
            yield return null;
        }
        yield return null;

    }

    IEnumerator DoFadeOut()
    {
        yield return new WaitForSeconds(2);
        CanvasGroup canvasGroup = FadeScene.GetComponent<CanvasGroup>();
        Debug.Log(canvasGroup.alpha);
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime;
            yield return null;
        }
        yield return null;
        FadeScene.SetActive(false);
    }
}
