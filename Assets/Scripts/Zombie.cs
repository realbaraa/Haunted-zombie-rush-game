using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Zombie : MonoBehaviour {

    private Animator anim;
    private Rigidbody rb;

    private bool isJumping;
    private float jumpSpeed=100f;
    private AudioSource audioSource;

    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private AudioClip sfxDeath;
    [SerializeField] private AudioClip sfxCollect;


    void Awake()
    {
        Assert.IsNotNull(sfxDeath);
        Assert.IsNotNull(sfxJump);
      
    }

	void Start () {
        GameManeger.instance.setCoinsToZero();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	void Update () {

        if (!GameManeger.instance.GameOver&&GameManeger.instance.IsGameStarted)
        {
            if (isJumping = Input.GetKeyDown("space"))
            {
                GameManeger.instance.playerStartedTheGame();
                anim.SetTrigger("Jump");
                audioSource.PlayOneShot(sfxJump);
                rb.useGravity = true;
            }
        }
	}

    void FixedUpdate()
    {
        if (isJumping)
        {
            isJumping = false;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "obstacle")
        {
            rb.AddForce(new Vector2(-50, 20), ForceMode.Impulse);
            rb.detectCollisions = false;
            audioSource.PlayOneShot(sfxDeath);
            StartCoroutine(GameManeger.instance.playerColided()); 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            GameManeger.instance.addPoints();
            audioSource.PlayOneShot(sfxCollect);
            Destroy(other.gameObject);
        }
    }

}
