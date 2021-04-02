﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Diamond Stats")]
    [SerializeField] public int diamondCount;
    [SerializeField] public Text diamondText;
    public GameObject StartScreen;
    public GameObject FinishScreen;


    public static GameManager inst;
    
    public enum PlayerState
    {
        Prepare,
        Playing,
        Died,
        Finish
    }

    public PlayerState playerState;
    
    

    private void Awake()
    {
        inst = this;
        playerState = PlayerState.Prepare;
    }

    void Update()
    {
        if (playerState == PlayerState.Prepare)
        {
            StartScreen.SetActive(true);
        }

        if (playerState == PlayerState.Finish)
        {
            //Oyun bitisini cagiriyor
            StartCoroutine(WaitAfterSeconds(3, FinishScreen));
        }
    }
    public void IncerementDiamond()
    {
        diamondCount++;
        diamondText.text = "Diamond: " + diamondCount; // change with image later
    }
    
    IEnumerator WaitAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(true);
    }

    //OnClick Button
    public void StartGame()
    {
        playerState = PlayerState.Playing;
        StartScreen.SetActive(false);
    }
    
    
}