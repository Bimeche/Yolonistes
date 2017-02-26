using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargeJudgingButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("test enlarge script");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseOver()
	{
		Debug.Log("jefrhgerhufzbhkruebfuhkerbfhkjuerbskuhferbjhkfbherbkuhefrberhkubhkefrzjubjhfrb");
		transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
	}


}
