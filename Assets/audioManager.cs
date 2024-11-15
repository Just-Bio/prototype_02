using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class audioManager : MonoBehaviour
{
    public AudioSource playedAudio;
	public string playedDialogue;
	public Text uiReference;

	private void OnCollisionEnter(Collision collision)
	{
		//if(collision.GetType = "Player")
		{
			uiReference.text = playedDialogue;
		}
	}
}
