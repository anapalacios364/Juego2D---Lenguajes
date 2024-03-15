using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float playerJumpForce=20f;
    public float playerSpeed=5f;
    public Sprite[] mySprites;
    private int index=0;
    public GameManager myGameManager;

    private Rigidbody2D myRigidBody2D; 
    private SpriteRenderer mySpriteRenderer;
    

    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRoutine());
        myGameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x, playerJumpForce);
        }
        myRigidBody2D.velocity = new Vector2(playerSpeed, myRigidBody2D.velocity.y);
        
    }

    IEnumerator WalkCoRoutine()
    {
        yield return new WaitForSeconds(0.05f);
        mySpriteRenderer.sprite = mySprites[index];
        index++;
        if (index == 10)
        {
            index=0;
        }
        StartCoroutine(WalkCoRoutine());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coin")){
            
            Destroy(collision.gameObject);
            myGameManager.AddScore();
        }
        else if (collision.CompareTag("Dog"))
        {
            Destroy(collision.gameObject);
            PlayerDeath();
        }
        else if (collision.CompareTag("DeathZone"))
        {
            PlayerDeath();
        }
    }

    public void PlayerDeath()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

