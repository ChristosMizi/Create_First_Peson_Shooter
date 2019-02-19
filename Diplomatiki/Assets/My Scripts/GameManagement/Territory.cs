using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Territory : MonoBehaviour

{
    public string territoryName;
    public GameObject territoryUI;
    [SerializeField]
    //private AudioClip _Audio;
    AudioSource audiosource;

    // Use this for initialization
    void Start ()
    {
        territoryUI.SetActive(false);
         audiosource = GetComponent<AudioSource>();
    }
	
	void OnTriggerEnter(Collider Player)
    {
        if(Player.gameObject.tag == "Player")
        {
            audiosource.Play();
            territoryUI.SetActive(true);
            territoryUI.GetComponent<Text>().text = territoryName;
           // AudioSource.PlayClipAtPoint(_Audio, transform.position, 1f);
            
        }
    }

    void OnTriggerExit(Collider Player)
    {
        if(Player.gameObject.tag == "Player")
        {
            territoryUI.SetActive(false);
        }
    }
}
