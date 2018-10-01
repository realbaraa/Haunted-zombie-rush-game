using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {

    private Text score;
  //  AudioSource death;

    void Start()
    {
   //     death = GameObject.Find("GameObject").GetComponent<AudioSource>();
        score = GameObject.Find("score").GetComponent<Text>();
    }

    void Update()
    {
        score.text = "Score : " + GameManeger.instance.Coins.ToString();
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("main menu");
        GameManeger.instance.Replay();
    }

    public void Replay()
    {
        SceneManager.LoadScene("Game Scene");
        GameManeger.instance.Replay();
    }
}
