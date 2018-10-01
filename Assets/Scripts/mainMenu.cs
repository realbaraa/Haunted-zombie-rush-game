using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

//    static public AudioListener menuL;
  //  AudioSource menuMusic;

    void Start()
    {
      //  menuMusic = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        //menuL = GameObject.Find("Main Camera").GetComponent<AudioListener>();
        //menuL.enabled = true;
    }

    public void play()
    {
        SceneManager.LoadScene("Game Scene");
       // menuMusic.Stop();
       // menuL.enabled = false;
    }


}
