using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        transform.Rotate(0f, Mathf.Pow(gameManager.surviveTime, 2) * Time.deltaTime, 0f);
        
    }
}
