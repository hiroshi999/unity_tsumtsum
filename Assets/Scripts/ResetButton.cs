using UnityEngine;
using System.Collections;

public class ResetButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	void OnMouseDown()
	{
		Debug.Log("clicked button");
		Application.LoadLevel("Stage");
	}

	void OnMouseUp()
	{
	}
}
