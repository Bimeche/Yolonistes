using UnityEngine;

public class CurrentFloder : MonoBehaviour {
    public FileReader Files;
    CharacterInfos current;

    public int index = -1;
    public GameObject g;

    public int badDecisions = 0;
    public int numberFolder = 2;
    public int innocentVictims = 0;
    public int guiltScore = 0;

    public int day;
    bool fileInitialized = false;
    bool w1dead = false;
    bool w2dead = false;
    bool w3dead = false;
    bool w4dead = false;
    bool w5dead = false;
    bool w6dead = false;
    bool w7dead = false;
    bool w8dead = false;


    // Use this for initialization
    void Start () {
        day = 1;
    }
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update () {

        if(fileInitialized == false)
        {
            index = Random.Range(1, Files.listCharacters.Count);
            fileInitialized = true;
        }
    }

    public CharacterInfos GetCurrent()
    {
        current = Files.listCharacters[index];
        return current;
    }
    public void NextFile()
    {
        KillingTeam();

        if(Files.listCharacters[index].outcome == 1 && Files.listCharacters[index].guilty == false)//judged guilty && actually non guilty
        {
            badDecisions++;
            innocentVictims++;
        }
        else if(Files.listCharacters[index].outcome == 2 && Files.listCharacters[index].guilty == true)//judged innocent && actually guilty
        {
            badDecisions++;
            guiltScore++; 
        }
        Debug.Log("count before remove" + Files.listCharacters.Count);

        if (Files.listCharacters[index].outcome != 3)
        {
            Files.listCharacters.RemoveAt(index);
            Debug.Log("count after remove" + Files.listCharacters.Count);
        }

        index = Random.Range(1, Files.listCharacters.Count);

        if (day >= 5 && numberFolder == 1)//si c'est le dernier jour et qu'il ne reste qu'un dossier, je tire le mien
        {
            index = 0;
            //determine si joueur coupable
            if(innocentVictims > 0)
            {
                Files.listCharacters[index].guilty = true;
            }
            else if(guiltScore > 4)
            {
                Files.listCharacters[index].guilty = true;
            }
            else
            {
                Files.listCharacters[index].guilty = false;
            }
        }

        current = Files.listCharacters[index];
    }

    public bool isDead(int number)
    {
        if(number==1)
             return w1dead;
        else if (number == 2)
             return w2dead;
        else if (number == 3)
            return w3dead;
        else if (number == 4)
            return w4dead;
        else if (number == 5)
            return w5dead;
        else if (number == 6)
            return w6dead;
        else if (number == 7)
            return w7dead;
        else 
            return w8dead;
    }
    private void KillingTeam()
    {
        if (Files.listCharacters[index].number == "67HU12A0T3" && Files.listCharacters[index].outcome == 1)
            w1dead = true;
        if (Files.listCharacters[index].number == "22AS12C1R1" && Files.listCharacters[index].outcome == 1)
            w2dead = true;
        if (Files.listCharacters[index].number == "54LQ07N4V1" && Files.listCharacters[index].outcome == 1)
            w3dead = true;
        if (Files.listCharacters[index].number == "98LS34B2Q2" && Files.listCharacters[index].outcome == 1)
            w4dead = true;
        if (Files.listCharacters[index].number == "98LS24R2Y7" && Files.listCharacters[index].outcome == 1)
            w5dead = true;
        if (Files.listCharacters[index].number == "81SA40T1F7" && Files.listCharacters[index].outcome == 1)
            w6dead = true;
        if (Files.listCharacters[index].number == "75SS00A4G4" && Files.listCharacters[index].outcome == 1)
            w7dead = true;
        if (Files.listCharacters[index].number == "61BN21C3P0" && Files.listCharacters[index].outcome == 1)
            w8dead = true;
    }
}
