using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManeger : MonoBehaviour {

    public static GameManeger instance = null;
    AudioSource mainmusic;

    //private Vector3 restPos=new Vector3(-1.94f, 3.53f, 4.71f);
    private bool playerActive = false;
    private bool gameOver = false;
    private bool isGameStarted = false;
    public int coins = 0;

    public int Coins
    {
        get { return coins; }
    }
    public bool PlayerActive {
        get { return playerActive; }
    }

    public bool GameOver {
        get { return gameOver; }
    }

    public bool IsGameStarted {
        get { return isGameStarted; }
    }

    public void setCoinsToZero()
    {
        coins = 0;
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        isGameStarted = true;
        mainmusic = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }
    public IEnumerator playerColided()
    {
        gameOver = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Death menu");
        mainmusic.Stop();
    }

    public void Replay()
    {
        gameOver = false;
       // mainMenu.menuL.enabled = false;
        mainmusic.Play();
    }

    public void playerStartedTheGame()
    {
        playerActive = true;
    }

    public void addPoints()
    {
        coins++;
    }

}
