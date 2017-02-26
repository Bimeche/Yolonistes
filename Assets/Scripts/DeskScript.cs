using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DeskScript : MonoBehaviour
{
	private bool isZoomed;
	public Image profileDisp;
	public Image archivesButtonsDisp;
	public Image unlockArchives;
	public Image medDocsDisp;
	public Image crimeDocsDisp;
	public Image moneyDocsDisp;
	public Image initiateJudgingDisp;
	public Image judgingPanelDisp;
	public Image backToMainSheetPanel;
	public Image reportPanel;
	public Image archivesClosed;
	private CurrentFloder currentF;
	private CanvasGroup currentDocDisplayed;
	private int index;
	private bool isJudging;
    public Timer t;
	private bool hasCrime = false;
	private bool hasFinance = false;
	private bool hasMed = false;
	private bool hasAFolder = false;
	private List<Button> btList;
    public Text nbFolderText;
    public double successRate;
	public FillSheet fillSheet;
	public AudioSource stampUp;
	public AudioSource stampDown;
	public AudioSource folderOpening;
	public AudioSource medicalSheet;
	public AudioSource criminalSheet;
	public AudioSource financialSheet;
	public AudioSource profileSheet;
	public AudioSource phoneButtons;
	public AudioSource phonePickUp;
	public AudioSource phonePutDown;
	public AudioSource endOfFolder;
	private SoundManager sm;
	float timeArchive = -1;
    // Use this for initialization
    void Start()
	{
        
        currentF = GameObject.Find("CurrentFolder").GetComponent<CurrentFloder>();
        currentF.numberFolder=3;
        nbFolderText.text = currentF.numberFolder.ToString();
		sm = GameObject.Find("SoundManager").GetComponent<SoundManager>();
		if (currentF.day > 1)
        {
            successRate = System.Math.Round((1.00 - (double)currentF.badDecisions / currentF.numberFolder) *100,2);
			currentF.badDecisions = 0;
			reportPanel.GetComponentInChildren<Text>().text = reportPanel.GetComponentInChildren<Text>().text.Replace("x", successRate.ToString());
			reportPanel.GetComponent<CanvasGroup>().alpha = 1;
			reportPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

        
        isZoomed = false;
		index = 0;
        btList = new List<Button>();
		isJudging = false;
        foreach (Button b in medDocsDisp.GetComponentsInChildren<Button>())
        {
            btList.Add(b);
        }
        foreach (Button b in crimeDocsDisp.GetComponentsInChildren<Button>())
        {
            btList.Add(b);
        }
        foreach (Button b in moneyDocsDisp.GetComponentsInChildren<Button>())
        {
            btList.Add(b);
        }

    }
	// Update is called once per frame
	void Update()
	{
		if((1 - (Time.time - timeArchive)/2)>0 && timeArchive + 2 > Time.time)
		{
			archivesClosed.GetComponent<CanvasGroup>().alpha = 1-(Time.time - timeArchive)/2;
				
		}

	}

	public void ClickOnReport()
	{
		reportPanel.GetComponent<CanvasGroup>().alpha = 0;
		reportPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
		reportPanel.GetComponentInChildren<Text>().text = "Yesterday, your judging was x % accurate";
	}

	public void ZoomIn()
	{
        if (!hasAFolder)
        {
            currentF.numberFolder--;
            nbFolderText.text = currentF.numberFolder.ToString();
		    profileDisp.GetComponent<CanvasGroup>().alpha = 1;
		    profileDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
		    currentDocDisplayed = profileDisp.GetComponent<CanvasGroup>();
			unlockArchives.GetComponent<CanvasGroup>().blocksRaycasts = true;
		    initiateJudgingDisp.GetComponent<CanvasGroup>().alpha = 1;
		    initiateJudgingDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
            hasAFolder = true;
			fillSheet.FillMainSheet(currentF.GetCurrent().number, currentF.GetCurrent().age.ToString(), currentF.GetCurrent().genre, currentF.GetCurrent().emploi, currentF.GetCurrent().marital, currentF.GetCurrent().hobbies, currentF.GetCurrent().notable, currentF.GetCurrent().politique.religion, currentF.GetCurrent().politique.engagement, currentF.GetCurrent().outcome);
			GameObject.Find("Photo").GetComponent<Image>().CrossFadeAlpha(255, 0, true);
			fillSheet.FillInfoSheets("MedicalArchives", "");
			fillSheet.FillInfoSheets("CriminalArchives", "");
			fillSheet.FillInfoSheets("FinancialArchives", "");
			profileDisp.sprite = Resources.Load<Sprite>("Sprites/Fiche_Base");
			sm.PlaySingle(folderOpening.clip);
		}



	}

	public void ZoomOut()
	{
		isZoomed = false;
	}
	
	public void UnlockArchivesButtons()
	{
		if (t.GetHeure() >= 16)
		{
			archivesClosed.GetComponent<CanvasGroup>().alpha = 1;
			timeArchive = Time.time;
		}
		else
		{
			unlockArchives.GetComponent<CanvasGroup>().alpha = 0;
			unlockArchives.GetComponent<CanvasGroup>().blocksRaycasts = false;
			archivesButtonsDisp.GetComponent<CanvasGroup>().alpha = 1;
			archivesButtonsDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
			sm.PlaySingle(phonePickUp.clip);
		}
	}

	public void MedDocs()
	{

        if (!hasMed)
        {
		    medDocsDisp.GetComponent<CanvasGroup>().alpha = 1;
		    medDocsDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
            foreach (Button b in medDocsDisp.GetComponentsInChildren<Button>())
            {
                if (b.name=="MedPage1")
                    if(currentF.GetCurrent().medical.psychologique.Equals(""))
                        b.gameObject.SetActive ( false);
                    else
                        b.gameObject.SetActive(true);
               else if (b.name == "MedPage2")
                    if (currentF.GetCurrent().medical.maladie.Equals(""))
                        b.gameObject.SetActive(false);
                    else
                        b.gameObject.SetActive(true);
               else if (b.name == "MedPage3")
                    if (currentF.GetCurrent().medical.hospitalisation.Equals(""))
                        b.gameObject.SetActive(false);
                    else
                        b.gameObject.SetActive(true);
            }
            hasMed = true;
			if(medDocsDisp.GetComponentsInChildren<Button>().Length !=0)
				t.ChangeTime(1, Random.Range(0, 59));
			unlockArchives.GetComponent<CanvasGroup>().alpha = 1;
			unlockArchives.GetComponent<CanvasGroup>().blocksRaycasts = true;
			archivesButtonsDisp.GetComponent<CanvasGroup>().alpha = 0;
			archivesButtonsDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
		sm.PlaySingle(phoneButtons.clip);
		sm.PlaySingleDelayed(phonePutDown.clip,0.3f);
	}

	public void CrimeDocs()
	{
        if (!hasCrime)
        {
		    crimeDocsDisp.GetComponent<CanvasGroup>().alpha = 1;
		    crimeDocsDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;

            foreach (Button b in crimeDocsDisp.GetComponentsInChildren<Button>())
            {
                if (b.name == "CrimePage1")
                    if (currentF.GetCurrent().crime.atteintePersonnelle.Equals(""))
                        b.gameObject.SetActive(false);
                    else
                        b.gameObject.SetActive(true);
                else if (b.name == "CrimePage2")
                    if (currentF.GetCurrent().crime.atteinteGouvernement.Equals(""))
                        b.gameObject.SetActive(false);
                    else
                        b.gameObject.SetActive(true);
                else if (b.name == "CrimePage3")
                    if (currentF.GetCurrent().crime.atteinteMaterielle.Equals(""))
                        b.gameObject.SetActive(false);
                    else
                        b.gameObject.SetActive(true);
            }
            hasCrime = true;
			if (crimeDocsDisp.GetComponentsInChildren<Button>().Length != 0)
				t.ChangeTime(1, Random.Range(0, 59));
			unlockArchives.GetComponent<CanvasGroup>().alpha = 1;
			unlockArchives.GetComponent<CanvasGroup>().blocksRaycasts = true;
			archivesButtonsDisp.GetComponent<CanvasGroup>().alpha = 0;
			archivesButtonsDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
		sm.PlaySingle(phoneButtons.clip);
		sm.PlaySingleDelayed(phonePutDown.clip, 0.3f);

	}

	public void MoneyDocs()
	{
        if (!hasFinance)
        {
		    moneyDocsDisp.GetComponent<CanvasGroup>().alpha = 1;
		    moneyDocsDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
            foreach (Button b in moneyDocsDisp.GetComponentsInChildren<Button>())
            {
                if (b.name == "MoneyPage1")
                    if (currentF.GetCurrent().finance.dette.Equals(""))
                        b.gameObject.SetActive(false);
                    else
                        b.gameObject.SetActive(true);
                else if (b.name == "MoneyPage2")
                    if (currentF.GetCurrent().finance.impots.Equals(""))
                        b.gameObject.SetActive(false);
                    else
                        b.gameObject.SetActive(true);

                else if (b.name == "MoneyPage3")
                    if (currentF.GetCurrent().finance.solde.Equals(""))
                        b.gameObject.SetActive(false);
                    else
                        b.gameObject.SetActive(true);
            }
            hasFinance = true;
			if (moneyDocsDisp.GetComponentsInChildren<Button>().Length != 0)
				t.ChangeTime(1, Random.Range(0, 59));
			unlockArchives.GetComponent<CanvasGroup>().alpha = 1;
			unlockArchives.GetComponent<CanvasGroup>().blocksRaycasts = true;
			archivesButtonsDisp.GetComponent<CanvasGroup>().alpha = 0;
			archivesButtonsDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
		sm.PlaySingle(phoneButtons.clip);
		sm.PlaySingleDelayed(phonePutDown.clip, 0.3f);

	}

	public void InitiateJudging()
	{
        if (isJudging)
        {
            judgingPanelDisp.GetComponent<CanvasGroup>().alpha = 0;
            judgingPanelDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
            isJudging = false;
			sm.PlaySingle(stampUp.clip);
		}
        else
        {
		    judgingPanelDisp.GetComponent<CanvasGroup>().alpha = 1;
		    judgingPanelDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
            isJudging = true;
			sm.PlaySingle(stampUp.clip);
        }
		
	}

	public void Judging()
	{
		GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;

		if(buttonClicked.name == "Innocent")
		{
            currentF.GetCurrent().outcome = 2;
			cleanFiles();
            
        }
		else if(buttonClicked.name == "Investigate")
		{
            currentF.GetCurrent().outcome = 3;
            cleanFiles();
		}
		else
		{
            currentF.GetCurrent().outcome = 1;
            cleanFiles();
		}
		sm.PlaySingle(stampDown.clip);
	}

	public void mainSheet()
	{
		currentDocDisplayed.alpha = 1;
		currentDocDisplayed.blocksRaycasts = true;
		backToMainSheetPanel.GetComponent<CanvasGroup>().alpha = 0;
		backToMainSheetPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
		currentDocDisplayed = profileDisp.GetComponent<CanvasGroup>();
		profileDisp.sprite = Resources.Load<Sprite>("Sprites/Fiche_Base");
		fillSheet.FillMainSheet(currentF.GetCurrent().number, currentF.GetCurrent().age.ToString(), currentF.GetCurrent().genre, currentF.GetCurrent().emploi, currentF.GetCurrent().marital, currentF.GetCurrent().hobbies, currentF.GetCurrent().notable, currentF.GetCurrent().politique.religion, currentF.GetCurrent().politique.engagement, currentF.GetCurrent().statut);
		GameObject.Find("Photo").GetComponent<Image>().CrossFadeAlpha(255, 0, true);
		fillSheet.FillInfoSheets("MedicalArchives", "");
		fillSheet.FillInfoSheets("CriminalArchives", "");
		fillSheet.FillInfoSheets("FinancialArchives", "");
		sm.PlaySingle(profileSheet.clip);
	}

	public void informationSheet()
	{
		GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;
		currentDocDisplayed.alpha = 1;
		currentDocDisplayed.blocksRaycasts = true;
		currentDocDisplayed = buttonClicked.GetComponent<CanvasGroup>();
		currentDocDisplayed.alpha = 0;
		currentDocDisplayed.blocksRaycasts = false;
		backToMainSheetPanel.GetComponent<CanvasGroup>().alpha = 1;
		backToMainSheetPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
		GameObject.Find("Photo").GetComponent<Image>().CrossFadeAlpha(0, 0, true);

		if (buttonClicked.name == "MedPage1")
		{
			fillSheet.FillInfoSheets("MedicalArchives", currentF.GetCurrent().medical.psychologique);
			fillSheet.FillMainSheet("","","","","","","","","",10);
			fillSheet.FillInfoSheets("CriminalArchives", "");
			fillSheet.FillInfoSheets("FinancialArchives", "");
			profileDisp.sprite = Resources.Load<Sprite>("Sprites/Fiche_Medicale");
			sm.PlaySingle(medicalSheet.clip);
		}
		else if (buttonClicked.name == "MedPage2")
		{
			fillSheet.FillInfoSheets("MedicalArchives", currentF.GetCurrent().medical.maladie);
			fillSheet.FillMainSheet("", "", "", "", "", "", "", "", "", 10);
			fillSheet.FillInfoSheets("CriminalArchives", "");
			fillSheet.FillInfoSheets("FinancialArchives", "");
			profileDisp.sprite = Resources.Load<Sprite>("Sprites/Fiche_Medicale");
			sm.PlaySingle(medicalSheet.clip);
		}
		else if (buttonClicked.name == "MedPage3")
		{
			fillSheet.FillInfoSheets("MedicalArchives", currentF.GetCurrent().medical.hospitalisation);
			fillSheet.FillMainSheet("", "", "", "", "", "", "", "", "", 10);
			fillSheet.FillInfoSheets("CriminalArchives", "");
			fillSheet.FillInfoSheets("FinancialArchives", "");
			profileDisp.sprite = Resources.Load<Sprite>("Sprites/Fiche_Medicale");
			sm.PlaySingle(medicalSheet.clip);
		}
		else if (buttonClicked.name == "CrimePage1")
		{
			fillSheet.FillInfoSheets("CriminalArchives", currentF.GetCurrent().crime.atteintePersonnelle);
			fillSheet.FillMainSheet("", "", "", "", "", "", "", "", "", 10);
			fillSheet.FillInfoSheets("MedicalArchives", "");
			fillSheet.FillInfoSheets("FinancialArchives", "");
			profileDisp.sprite = Resources.Load<Sprite>("Sprites/Fiche_Criminelle");
			sm.PlaySingle(criminalSheet.clip);
		}
		else if (buttonClicked.name == "CrimePage2")
		{
			fillSheet.FillInfoSheets("CriminalArchives", currentF.GetCurrent().crime.atteinteGouvernement);
			fillSheet.FillMainSheet("", "", "", "", "", "", "", "", "", 10);
			fillSheet.FillInfoSheets("MedicalArchives", "");
			fillSheet.FillInfoSheets("FinancialArchives", "");
			profileDisp.sprite = Resources.Load<Sprite>("Sprites/Fiche_Criminelle");
			sm.PlaySingle(criminalSheet.clip);
		}
		else if (buttonClicked.name == "CrimePage3")
		{
			fillSheet.FillInfoSheets("CriminalArchives", currentF.GetCurrent().crime.atteinteMaterielle);
			fillSheet.FillMainSheet("", "", "", "", "", "", "", "", "", 10);
			fillSheet.FillInfoSheets("MedicalArchives", "");
			fillSheet.FillInfoSheets("FinancialArchives", "");
			profileDisp.sprite = Resources.Load<Sprite>("Sprites/Fiche_Criminelle");
			sm.PlaySingle(criminalSheet.clip);
		}
		else if (buttonClicked.name == "MoneyPage1")
		{
			fillSheet.FillInfoSheets("FinancialArchives1", currentF.GetCurrent().finance.dette);
			fillSheet.FillMainSheet("", "", "", "", "", "", "", "", "", 10);
			fillSheet.FillInfoSheets("MedicalArchives", "");
			fillSheet.FillInfoSheets("CriminalArchives", "");
			profileDisp.sprite = Resources.Load<Sprite>("Sprites/Fiche_Financesv2");
			sm.PlaySingle(financialSheet.clip);
		}
		else if (buttonClicked.name == "MoneyPage2")
		{
			fillSheet.FillInfoSheets("FinancialArchives2", currentF.GetCurrent().finance.impots);
			fillSheet.FillMainSheet("", "", "", "", "", "", "", "", "", 10);
			fillSheet.FillInfoSheets("MedicalArchives", "");
			fillSheet.FillInfoSheets("CriminalArchives", "");
			profileDisp.sprite = Resources.Load<Sprite>("Sprites/Fiche_Financesv2");
			sm.PlaySingle(financialSheet.clip);
		}
		else if (buttonClicked.name == "MoneyPage3")
		{
			fillSheet.FillInfoSheets("FinancialArchives3", currentF.GetCurrent().finance.solde);
			fillSheet.FillMainSheet("", "", "", "", "", "", "", "", "", 10);
			fillSheet.FillInfoSheets("MedicalArchives", "");
			fillSheet.FillInfoSheets("CriminalArchives", "");
			profileDisp.sprite = Resources.Load<Sprite>("Sprites/Fiche_Financesv2");
			sm.PlaySingle(financialSheet.clip);
		}
	}

    void cleanFiles()
    {
        hasCrime = false;
        hasFinance = false;
        hasMed = false;
        isJudging = false;
        hasAFolder = false;
        judgingPanelDisp.GetComponent<CanvasGroup>().alpha = 0;
        judgingPanelDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
        backToMainSheetPanel.GetComponent<CanvasGroup>().alpha = 0;
        backToMainSheetPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
        currentDocDisplayed.alpha = 0;
        currentDocDisplayed.blocksRaycasts = false;
        profileDisp.GetComponent<CanvasGroup>().alpha = 0;
        profileDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
        isZoomed = false;
        index = 0;
        archivesButtonsDisp.GetComponent<CanvasGroup>().alpha = 0;
        archivesButtonsDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
		unlockArchives.GetComponent<CanvasGroup>().blocksRaycasts = false;
        initiateJudgingDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;

        moneyDocsDisp.GetComponent<CanvasGroup>().alpha = 0;
        moneyDocsDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
        crimeDocsDisp.GetComponent<CanvasGroup>().alpha = 0;
        crimeDocsDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
        medDocsDisp.GetComponent<CanvasGroup>().alpha = 0;
        medDocsDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;

		sm.PlaySingle(endOfFolder.clip);

		foreach (Button b in btList)
        {
            b.gameObject.SetActive(true);
        }

        if (currentF.index != 0)
        {
            currentF.NextFile();

        }
        Debug.Log(currentF.badDecisions);
        t.ChangeTime(0, Random.Range(0, 59));
       

        if (currentF.numberFolder == 0)
        {
            currentF.day++;
            if(currentF.index == 0)
            {
                //fin 1: juge coupable et coupable ou innocent (lol tu meurs)
                if(currentF.Files.listCharacters[currentF.index].outcome == 1)
                {
                    SceneManager.LoadScene("DeathEnding");
                }
                //fin 2: juge innocent et innocent ou coupable (texte change)
                if(currentF.Files.listCharacters[currentF.index].outcome == 2 && currentF.Files.listCharacters[currentF.index].guilty == false)
                {
                    SceneManager.LoadScene("GoodGuyEnding");
                }
                //fin 3: demande enquete
                if(currentF.Files.listCharacters[currentF.index].outcome == 3)
                {
                    SceneManager.LoadScene("InvestigationEnding");
                }
            }
            else
            {
                SceneManager.LoadScene("Morgane");
            }

        }
        
    }

}
