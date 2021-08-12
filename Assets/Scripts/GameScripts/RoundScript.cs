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
    public bool step5 = false;

    public bool obj2_completion = false;
    public bool obj3_completion = false;

    public GameObject round_1_objective;
    public GameObject round_2_objective;
    public GameObject round_3_objective;
    public GameObject round_4_objective;

    public GameObject Spawner;
    public GameObject deleter;
    public GameObject GordonRamsey;

    public GameObject playerObject;
    public GameObject canvas;

    
    // Start is called before the first frame update
    private void Awake()
    {
        SceneIndex = SceneManager.GetActiveScene().buildIndex;
        canvas.GetComponent<PlayerUIScript>().RoundIndex = SceneIndex;
        playerObject.GetComponent<PlayerInventory>().RoundIndex = SceneIndex;

        if (SceneIndex == 1) //checks for what round the game is in according to scene index
        { //sets appropirate objective for the round and sets parameters for NPC spawning
            round_1_objective.SetActive(true);
            Spawner.gameObject.GetComponent<SpawnNPCScript>().max_npc = 4;
            Spawner.gameObject.GetComponent<SpawnNPCScript>().roundNumber = SceneIndex;

            deleter.GetComponent<DeleteNPCScript>().numberOfNPCs = 4;
            //tells deleter script how many NPCs will be spawned for objective 4
        }
        else if (SceneIndex == 2)
        {
            round_2_objective.SetActive(true);
            Spawner.gameObject.GetComponent<SpawnNPCScript>().max_npc = 5;
            Spawner.gameObject.GetComponent<SpawnNPCScript>().roundNumber = SceneIndex;

            deleter.GetComponent<DeleteNPCScript>().numberOfNPCs = 4;
            //tells deleter script how many NPCs will be spawned for objective 4

        }
        else if (SceneIndex == 3)
        {
            round_3_objective.SetActive(true);
            Spawner.gameObject.GetComponent<SpawnNPCScript>().max_npc = 6;
            Spawner.gameObject.GetComponent<SpawnNPCScript>().roundNumber = SceneIndex;

            deleter.GetComponent<DeleteNPCScript>().numberOfNPCs = 6;
            //tells deleter script how many NPCs will be spawned for objective 4

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
    
    }

    public void objUpdate(int objective) //objective completion function that updates objective clipboard
    {
        if (objective == 1)
        {
            step1 = true;
            canvas.GetComponent<PlayerUIScript>().objectiveComplete(1);
            openClipboard();

        } else if (objective == 2)
        {
            step2 = true;
            canvas.GetComponent<PlayerUIScript>().objectiveComplete(2);
            openClipboard();

        } else if (objective == 3)
        {
            step3 = true;
            canvas.GetComponent<PlayerUIScript>().objectiveComplete(3);
            openClipboard();

        } else if (objective == 4)
        {
            step4 = true;
            canvas.GetComponent<PlayerUIScript>().objectiveComplete(4);
            openClipboard();

        } else if (objective == 5)
        {
            step5 = true;
            canvas.GetComponent<PlayerUIScript>().objectiveComplete(5);
            openClipboard();

        }
    }

    private void openClipboard() // opens objective clipboard
    {
        canvas.gameObject.GetComponent<PlayerUIScript>().clipboardToggle();   
    }

    public void FadeToBlack()
    {
        StartCoroutine(DoFadeIn());
    }

    IEnumerator DoFadeIn()
    {
        FadeScene.SetActive(true);
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

    public void spawnGordonRamsey()
    {
        GordonRamsey.SetActive(true);
    }
}
