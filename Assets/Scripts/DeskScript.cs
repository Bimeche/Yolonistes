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
	private CanvasGroup currentDocDisplayed;
	private string spriteName;
	private CharacterInfos[] daysFilesList;
	private int index;


	// Use this for initialization
	void Start()
	{
		isZoomed = false;
		index = 0;
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
		Debug.Log("MedDocs");
		medDocsDisp.GetComponent<CanvasGroup>().alpha = 1;
		medDocsDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;

	}

	public void CrimeDocs()
	{
		Debug.Log("CrimeDocs");
		crimeDocsDisp.GetComponent<CanvasGroup>().alpha = 1;
		crimeDocsDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void MoneyDocs()
	{
		Debug.Log("MoneyDocs");
		moneyDocsDisp.GetComponent<CanvasGroup>().alpha = 1;
		moneyDocsDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
	}

	public void InitiateJudging()
	{
		Debug.Log("Inititate Judging");

		judgingPanelDisp.GetComponent<CanvasGroup>().alpha = 1;
		judgingPanelDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
		initiateJudgingDisp.GetComponent<CanvasGroup>().alpha = 0;
		initiateJudgingDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
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
			Debug.Log("Innocent");
		}
		else if(buttonClicked.name == "Investigate")
		{
			Debug.Log("Investigate");
		}
		else
		{
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
}
