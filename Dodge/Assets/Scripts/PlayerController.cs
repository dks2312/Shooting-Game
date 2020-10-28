using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody playerRigidbody;
    public float speed = 8f;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector3 newVecity = new Vector3(speed * xInput, 0f, speed * yInput);
        playerRigidbody.velocity = newVecity;
        
    }

    public void Die()
    {
        gameManager.playerHp -= 1;
        if(gameManager.playerHp <= 0)
        {
            gameObject.SetActive(false);

            gameManager.EndGame();
        }
    }
}
