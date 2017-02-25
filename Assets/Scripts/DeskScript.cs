using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeskScript : MonoBehaviour
{
	private bool isZoomed;
	public Transform profilePagePrefab;
	public Image profileDisp;
	public Image archivesButtonsDisp;
	public Image medDocsDisp;
	public Image crimeDocsDisp;
	public Image moneyDocsDisp;
	public Image initiateJudgingDisp;
	public Image judgingPanelDisp;

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
		archivesButtonsDisp.GetComponent<CanvasGroup>().alpha = 1;
		initiateJudgingDisp.GetComponent<CanvasGroup>().alpha = 1;
	}

	public void ZoomOut()
	{
		isZoomed = false;
	}

	public void MedDocs()
	{
		Debug.Log("MedDocs");
		medDocsDisp.GetComponent<CanvasGroup>().alpha = 1;
	}

	public void CrimeDocs()
	{
		Debug.Log("CrimeDocs");
		crimeDocsDisp.GetComponent<CanvasGroup>().alpha = 1;
	}

	public void MoneyDocs()
	{
		Debug.Log("MoneyDocs");
		moneyDocsDisp.GetComponent<CanvasGroup>().alpha = 1;
	}

	public void InitiateJudging()
	{
		Debug.Log("Inititate Judging");
		archivesButtonsDisp.GetComponent<CanvasGroup>().alpha = 0;
		medDocsDisp.GetComponent<CanvasGroup>().alpha = 0;
		crimeDocsDisp.GetComponent<CanvasGroup>().alpha = 0;
		moneyDocsDisp.GetComponent<CanvasGroup>().alpha = 0;
		judgingPanelDisp.GetComponent<CanvasGroup>().alpha = 1;
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
}
