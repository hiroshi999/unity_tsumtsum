using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public GUIText scoreGUIText;

	private int score;

	// Use this for initialization
	void Start () {
		Initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreGUIText.text = score.ToString ();
	}

	private void Initialize ()
	{
		score = 0;
	}

	public void AddPoint (int point)
	{
		score = score + point;
	}

	public int GetPoint ()
	{
		return score;
	}
}
