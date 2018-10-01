using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class Coins : MonoBehaviour {

    [SerializeField] private float waitingTime;

    
    [SerializeField] GameObject coin;
   // Transform startpos;
    public float Timer=5f;

    void Awake()
    {
        Assert.IsNotNull(coin);
    } 

   void Update()
    {
        if (GameManeger.instance.PlayerActive&& !GameManeger.instance.GameOver)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                Instantiate(coin);
                Timer = 4f;
            }
        }
    }
}
