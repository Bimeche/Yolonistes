using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
	private int numberOfFolder;
    public Text nbFolderText;
    public double successRate;
	public FillSheet fillSheet;
    
    // Use this for initialization
    void Start()
	{
        Debug.Log("start" + gameObject.name);
        
        currentF = GameObject.Find("CurrentFolder").GetComponent<CurrentFloder>();
        numberOfFolder = currentF.numberFolder;
        nbFolderText.text = numberOfFolder.ToString();

        if(currentF.day > 1)
        {
            successRate = (1.00 - (double)currentF.badDecisions / numberOfFolder)*100;
            Debug.Log("success : " + successRate + "%");
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
	}

	public void ZoomIn()
	{
        if (!hasAFolder)
        {
            numberOfFolder--;
            nbFolderText.text = numberOfFolder.ToString();
            Debug.Log("button pressed");
		    profileDisp.GetComponent<CanvasGroup>().alpha = 1;
		    profileDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
		    currentDocDisplayed = profileDisp.GetComponent<CanvasGroup>();
			unlockArchives.GetComponent<CanvasGroup>().blocksRaycasts = true;
		    initiateJudgingDisp.GetComponent<CanvasGroup>().alpha = 1;
		    initiateJudgingDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
            hasAFolder = true;
			fillSheet.FillMainSheet(currentF.GetCurrent().number, currentF.GetCurrent().age.ToString(), currentF.GetCurrent().genre, currentF.GetCurrent().emploi, currentF.GetCurrent().marital, currentF.GetCurrent().hobbies, currentF.GetCurrent().notable, currentF.GetCurrent().politique.religion, currentF.GetCurrent().politique.engagement, currentF.GetCurrent().statut);
			GameObject.Find("Photo").GetComponent<Image>().CrossFadeAlpha(255, 0, true);
			fillSheet.FillInfoSheets("MedicalArchives", "");
			fillSheet.FillInfoSheets("CriminalArchives", "");
			fillSheet.FillInfoSheets("FinancialArchives", "");
		}



	}

	public void ZoomOut()
	{
		isZoomed = false;
	}

	public void UnlockArchivesButtons()
	{
		unlockArchives.GetComponent<CanvasGroup>().alpha = 0;
		unlockArchives.GetComponent<CanvasGroup>().blocksRaycasts = false;
		archivesButtonsDisp.GetComponent<CanvasGroup>().alpha = 1;
		archivesButtonsDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void MedDocs()
	{

        if (!hasMed)
        {
            Debug.Log("MedDocs");
		    medDocsDisp.GetComponent<CanvasGroup>().alpha = 1;
		    medDocsDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
            foreach (Button b in medDocsDisp.GetComponentsInChildren<Button>())
            {
                Debug.Log(b.name);
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
				t.ChangeTime(2, 27);
			unlockArchives.GetComponent<CanvasGroup>().alpha = 1;
			unlockArchives.GetComponent<CanvasGroup>().blocksRaycasts = true;
			archivesButtonsDisp.GetComponent<CanvasGroup>().alpha = 0;
			archivesButtonsDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
       
        
    }

	public void CrimeDocs()
	{
        if (!hasCrime)
        {
            Debug.Log("CrimeDocs");
		    crimeDocsDisp.GetComponent<CanvasGroup>().alpha = 1;
		    crimeDocsDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;

            foreach (Button b in crimeDocsDisp.GetComponentsInChildren<Button>())
            {
                Debug.Log(b.name);
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
				t.ChangeTime(1, 42);
			unlockArchives.GetComponent<CanvasGroup>().alpha = 1;
			unlockArchives.GetComponent<CanvasGroup>().blocksRaycasts = true;
			archivesButtonsDisp.GetComponent<CanvasGroup>().alpha = 0;
			archivesButtonsDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
		
    }

	public void MoneyDocs()
	{
        if (!hasFinance)
        {
            Debug.Log("MoneyDocs");
		    moneyDocsDisp.GetComponent<CanvasGroup>().alpha = 1;
		    moneyDocsDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
            Debug.Log(moneyDocsDisp.GetComponentsInChildren<Button>().Length);
            foreach (Button b in moneyDocsDisp.GetComponentsInChildren<Button>())
            {
                Debug.Log(b.name);
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
				t.ChangeTime(3, 19);
			unlockArchives.GetComponent<CanvasGroup>().alpha = 1;
			unlockArchives.GetComponent<CanvasGroup>().blocksRaycasts = true;
			archivesButtonsDisp.GetComponent<CanvasGroup>().alpha = 0;
			archivesButtonsDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
		
    }

	public void InitiateJudging()
	{
        if (isJudging)
        {
            Debug.Log("aborting");
            judgingPanelDisp.GetComponent<CanvasGroup>().alpha = 0;
            judgingPanelDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
            isJudging = false;
        }
        else
        {
            Debug.Log("Inititate Judging");
		    judgingPanelDisp.GetComponent<CanvasGroup>().alpha = 1;
		    judgingPanelDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
            isJudging = true;
        }
		
	}

	public void Judging()
	{
		GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;

		if(buttonClicked.name == "Innocent")
		{
            cleanFiles();
            currentF.GetCurrent().outcome = 2;
            Debug.Log("Innocent");
            
        }
		else if(buttonClicked.name == "Investigate")
		{
            cleanFiles();
            currentF.GetCurrent().outcome = 3;
            Debug.Log("Investigate");
		}
		else
		{
            currentF.GetCurrent().outcome = 1;
            cleanFiles();
            Debug.Log("Guilty");
		}
	}

	public void mainSheet()
	{
		Debug.Log("Main Sheet");
		currentDocDisplayed.alpha = 1;
		currentDocDisplayed.blocksRaycasts = true;
		backToMainSheetPanel.GetComponent<CanvasGroup>().alpha = 0;
		backToMainSheetPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
		currentDocDisplayed = profileDisp.GetComponent<CanvasGroup>();
		profileDisp.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Fiche_Base.png");
		fillSheet.FillMainSheet(currentF.GetCurrent().number, currentF.GetCurrent().age.ToString(), currentF.GetCurrent().genre, currentF.GetCurrent().emploi, currentF.GetCurrent().marital, currentF.GetCurrent().hobbies, currentF.GetCurrent().notable, currentF.GetCurrent().politique.religion, currentF.GetCurrent().politique.engagement, currentF.GetCurrent().statut);
		GameObject.Find("Photo").GetComponent<Image>().CrossFadeAlpha(255, 0, true);
		fillSheet.FillInfoSheets("MedicalArchives", "");
		fillSheet.FillInfoSheets("CriminalArchives", "");
		fillSheet.FillInfoSheets("FinancialArchives", "");
	}

	public void informationSheet()
	{
		GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;
		Debug.Log(buttonClicked.name);
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
			profileDisp.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Fiche_Medicale.png");
		}
		else if (buttonClicked.name == "MedPage2")
		{
			fillSheet.FillInfoSheets("MedicalArchives", currentF.GetCurrent().medical.maladie);
			fillSheet.FillMainSheet("", "", "", "", "", "", "", "", "", 10);
			fillSheet.FillInfoSheets("CriminalArchives", "");
			fillSheet.FillInfoSheets("FinancialArchives", "");
			profileDisp.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Fiche_Medicale.png");
		}
		else if (buttonClicked.name == "MedPage3")
		{
			fillSheet.FillInfoSheets("MedicalArchives", currentF.GetCurrent().medical.hospitalisation);
			fillSheet.FillMainSheet("", "", "", "", "", "", "", "", "", 10);
			fillSheet.FillInfoSheets("CriminalArchives", "");
			fillSheet.FillInfoSheets("FinancialArchives", "");
			profileDisp.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Fiche_Medicale.png");
		}
		else if (buttonClicked.name == "CrimePage1")
		{
			fillSheet.FillInfoSheets("CriminalArchives", currentF.GetCurrent().crime.atteintePersonnelle);
			fillSheet.FillMainSheet("", "", "", "", "", "", "", "", "", 10);
			fillSheet.FillInfoSheets("MedicalArchives", "");
			fillSheet.FillInfoSheets("FinancialArchives", "");
			profileDisp.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Fiche_Criminelle.png");
		}
		else if (buttonClicked.name == "CrimePage2")
		{
			fillSheet.FillInfoSheets("CriminalArchives", currentF.GetCurrent().crime.atteinteGouvernement);
			fillSheet.FillMainSheet("", "", "", "", "", "", "", "", "", 10);
			fillSheet.FillInfoSheets("MedicalArchives", "");
			fillSheet.FillInfoSheets("FinancialArchives", "");
			profileDisp.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Fiche_Criminelle.png");
		}
		else if (buttonClicked.name == "CrimePage3")
		{
			fillSheet.FillInfoSheets("CriminalArchives", currentF.GetCurrent().crime.atteinteMaterielle);
			fillSheet.FillMainSheet("", "", "", "", "", "", "", "", "", 10);
			fillSheet.FillInfoSheets("MedicalArchives", "");
			fillSheet.FillInfoSheets("FinancialArchives", "");
			profileDisp.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Fiche_Criminelle.png");
		}
		else if (buttonClicked.name == "MoneyPage1")
		{
			fillSheet.FillInfoSheets("FinancialArchives", currentF.GetCurrent().finance.dette);
			fillSheet.FillMainSheet("", "", "", "", "", "", "", "", "", 10);
			fillSheet.FillInfoSheets("MedicalArchives", "");
			fillSheet.FillInfoSheets("CriminalArchives", "");
			profileDisp.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Fiche_Investigation_2.png");
		}
		else if (buttonClicked.name == "MoneyPage2")
		{
			fillSheet.FillInfoSheets("FinancialArchives", currentF.GetCurrent().finance.impots);
			fillSheet.FillMainSheet("", "", "", "", "", "", "", "", "", 10);
			fillSheet.FillInfoSheets("MedicalArchives", "");
			fillSheet.FillInfoSheets("CriminalArchives", "");
			profileDisp.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Fiche_Investigation_2.png");
		}
		else if (buttonClicked.name == "MoneyPage3")
		{
			fillSheet.FillInfoSheets("FinancialArchives", currentF.GetCurrent().finance.solde);
			fillSheet.FillMainSheet("", "", "", "", "", "", "", "", "", 10);
			fillSheet.FillInfoSheets("MedicalArchives", "");
			fillSheet.FillInfoSheets("CriminalArchives", "");
			profileDisp.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/Fiche_Investigation_2.png");
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
        //currentDocDisplayed.alpha = 1;
        //currentDocDisplayed.blocksRaycasts = true;

        foreach (Button b in btList)
        {
            b.gameObject.SetActive(true);
        }

        currentF.NextFile();
        t.ChangeTime(0, 27);
       

        if (numberOfFolder == 0)
        {
            currentF.day++;
            currentF.badDecisions = 0;
            if(currentF.index == 0)
            {
                //fin 1: juge coupable et coupable ou innocent (lol tu meurs)
                if(currentF.Files.listCharacters[currentF.index].outcome == 1)
                {
                    SceneManager.LoadScene("DeathEnding");
                }
                //fin 2: juge innocent et innocent
                if(currentF.Files.listCharacters[currentF.index].outcome == 2 && currentF.Files.listCharacters[currentF.index].guilty == false)
                {
                    SceneManager.LoadScene("GoodGuyEnding");
                }
                //fin 3: juge innocent et coupable
                if(currentF.Files.listCharacters[currentF.index].outcome == 2 && currentF.Files.listCharacters[currentF.index].guilty == true)
                {
                    SceneManager.LoadScene("ThatWasCloseEnding");
                }
            }
            else
            {
                SceneManager.LoadScene("Morgane");
            }

        }
        
    }

}
