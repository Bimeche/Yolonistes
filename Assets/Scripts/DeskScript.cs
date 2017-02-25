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

	// Use this for initialization
	void Start()
	{
		isZoomed = false;
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
		// VERSION 1 : appuyer sur le bouton pour juger est DEFINITIF, il doit juger et on passe au dossier suivant
		profileDisp.GetComponent<CanvasGroup>().alpha = 0;
		profileDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
		archivesButtonsDisp.GetComponent<CanvasGroup>().alpha = 0;
		archivesButtonsDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
		medDocsDisp.GetComponent<CanvasGroup>().alpha = 0;
		medDocsDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
		crimeDocsDisp.GetComponent<CanvasGroup>().alpha = 0;
		crimeDocsDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
		moneyDocsDisp.GetComponent<CanvasGroup>().alpha = 0;
		moneyDocsDisp.GetComponent<CanvasGroup>().blocksRaycasts = false;
		judgingPanelDisp.GetComponent<CanvasGroup>().alpha = 1;
		judgingPanelDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
		backToMainSheetPanel.GetComponent<CanvasGroup>().alpha = 0;
		backToMainSheetPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;

		// VERSION 2 : En appuyant à nouveau sur le bouton pour juger, on revient sur les feuilles d'informations
		//judgingPanelDisp.GetComponent<CanvasGroup>().alpha = 1;
		//judgingPanelDisp.GetComponent<CanvasGroup>().blocksRaycasts = true;
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
