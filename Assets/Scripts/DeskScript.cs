using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeskScript : MonoBehaviour
{
	private bool isZoomed;
	public Image profileDisp;
	public Image archivesButtonsDisp;
	public Image medDocsDisp;
	public Image crimeDocsDisp;
	public Image moneyDocsDisp;
	public Image initiateJudgingDisp;
	public Image judgingPanelDisp;
	public Image backToMainSheetPanel;
    public CurrentFloder currentF;
	private CanvasGroup currentDocDisplayed;
	private string spriteName;
	private CharacterInfos[] daysFilesList;
	private int index;
    bool isJudging;
    public Timer t;
    bool hasCrime = false;
    bool hasFinance = false;
    bool hasMed = false;
    List<Button> btList;

    // Use this for initialization
    void Start()
	{
		isZoomed = false;
		index = 0;
        btList = new List<Button>();
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
		Debug.Log("button pressed");
		profileDisp.GetComponent<CanvasGroup>().alpha = 1;
		profileDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
		currentDocDisplayed = profileDisp.GetComponent<CanvasGroup>();
		archivesButtonsDisp.GetComponent<CanvasGroup>().alpha = 1;
		archivesButtonsDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
		initiateJudgingDisp.GetComponent<CanvasGroup>().alpha = 1;
		initiateJudgingDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
		spriteName = profileDisp.sprite.name;
	}

	public void ZoomOut()
	{
		isZoomed = false;
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
                    if(currentF.GetCurrent().medical.hospitalisation.Equals(""))
                        b.gameObject.SetActive ( false);
                    else
                        b.gameObject.SetActive(true);
               else if (b.name == "MedPage2")
                    if (currentF.GetCurrent().medical.maladie.Equals(""))
                        b.gameObject.SetActive(false);
                    else
                        b.gameObject.SetActive(true);
               else if (b.name == "MedPage3")
                    if (currentF.GetCurrent().medical.psychologique.Equals(""))
                        b.gameObject.SetActive(false);
                    else
                        b.gameObject.SetActive(true);
            }
            hasMed = true;
            t.ChangeTime(2, 27);
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
                    if (currentF.GetCurrent().crime.atteinteGouvernement.Equals(""))
                        b.gameObject.SetActive(false);
                    else
                        b.gameObject.SetActive(true);
                else if (b.name == "CrimePage2")
                    if (currentF.GetCurrent().crime.atteinteMaterielle.Equals(""))
                        b.gameObject.SetActive(false);
                    else
                        b.gameObject.SetActive(true);
                else if (b.name == "CrimePage3")
                    if (currentF.GetCurrent().crime.atteintePersonnelle.Equals(""))
                        b.gameObject.SetActive(false);
                    else
                        b.gameObject.SetActive(true);
            }
            hasCrime = true;
            t.ChangeTime(1, 42);
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
            t.ChangeTime(3, 19);
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

	public void AbortJudging()
	{
		Debug.Log("aborting");
		judgingPanelDisp.GetComponent<CanvasGroup>().alpha = 0;
		judgingPanelDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
		initiateJudgingDisp.GetComponent<CanvasGroup>().alpha = 1;
		initiateJudgingDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void Judging()
	{
		GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;

		if(buttonClicked.name == "Innocent")
		{
            cleanFiles();
            Debug.Log("Innocent");
            
        }
		else if(buttonClicked.name == "Investigate")
		{
            cleanFiles();
            Debug.Log("Investigate");
		}
		else
		{
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
		profileDisp.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/TestSprite.png");
		spriteName = profileDisp.sprite.name;
		currentDocDisplayed = profileDisp.GetComponent<CanvasGroup>();
	}

	public void informationSheet()
	{
		GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;
		currentDocDisplayed.alpha = 1;
		currentDocDisplayed.blocksRaycasts = true;
		currentDocDisplayed = buttonClicked.GetComponent<CanvasGroup>();
		currentDocDisplayed.alpha = 0;
		currentDocDisplayed.blocksRaycasts = false;
		if (spriteName == "TestSprite" || spriteName == "TestSprite3")
		{
			profileDisp.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/TestSprite2.png");
			spriteName = profileDisp.sprite.name;
		}
		else
		{
			profileDisp.sprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Sprites/TestSprite3.png");
			spriteName = profileDisp.sprite.name;
		}
		backToMainSheetPanel.GetComponent<CanvasGroup>().alpha = 1;
		backToMainSheetPanel.GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

    void cleanFiles()
    {
        hasCrime = false;
        hasFinance = false;
        hasMed = false;
        isJudging = false;
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
        initiateJudgingDisp.GetComponent<CanvasGroup>().alpha = 0;
        initiateJudgingDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;

        moneyDocsDisp.GetComponent<CanvasGroup>().alpha = 0;
        moneyDocsDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
        crimeDocsDisp.GetComponent<CanvasGroup>().alpha = 0;
        crimeDocsDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
        medDocsDisp.GetComponent<CanvasGroup>().alpha = 0;
        medDocsDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
        currentDocDisplayed.alpha = 1;
        currentDocDisplayed.blocksRaycasts = true;
        foreach (Button b in btList)
        {
            b.gameObject.SetActive(true);
        }
        
    }
}
