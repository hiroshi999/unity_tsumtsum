using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

	private AudioSource se00;
	private AudioSource se01;
	private AudioSource se02;
	private AudioSource se03;
	private AudioSource se04;
	private AudioSource se05;

	// Use this for initialization
	void Start () {
		AudioSource[] audioSources = GetComponents<AudioSource>();
		se00 = audioSources[0];
		se01 = audioSources[1];
		se02 = audioSources[2];
		se03 = audioSources[3];
		se04 = audioSources[4];
		se05 = audioSources[5];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySe00(){
		se00.PlayOneShot(se00.clip);
	}

	public void PlaySe01(){
		se01.PlayOneShot(se01.clip);
	}

	public void PlaySe02(){
		se02.PlayOneShot(se02.clip);
	}

	public void PlaySe03(){
		se03.PlayOneShot(se03.clip);
	}

	public void PlaySe04(){
		se04.PlayOneShot(se04.clip);
	}

	public void PlaySe05(){
		se05.PlayOneShot(se05.clip);
	}
}
