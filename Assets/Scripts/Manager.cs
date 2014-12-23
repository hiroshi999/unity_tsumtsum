using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	private GameObject clear;

	// Use this for initialization
	void Start () {
		clear = GameObject.Find ("Clear GUI");
		clear.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GameClear(){
		clear.SetActive (true);
	}

}
