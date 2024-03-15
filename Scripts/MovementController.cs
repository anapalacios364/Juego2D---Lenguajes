using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
   public float playerJumpForce=20f;
    public float playerSpeed=5f;
    public Sprite[] mySprites;
    private int index=0;

    private Rigidbody2D myRigidBody2D; 
    private SpriteRenderer mySpriteRenderer; 

    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(WalkCoRoutine());
    }

    IEnumerator WalkCoRoutine()
{
    yield return new WaitForSeconds(0.05f);
    mySpriteRenderer.sprite = mySprites[index];
    index++;
    if (index == mySprites.Length)
    {
        index = 0;
    }
    StartCoroutine(WalkCoRoutine());
}
}
