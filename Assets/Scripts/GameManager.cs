using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Diamond Stats")]
    [SerializeField] public int diamondCount;
    [SerializeField] public int currentLevelDiamondCount;
    [SerializeField] public int bonusMultiplier;


    [SerializeField] public TextMeshProUGUI diamondText;
    public GameObject StartScreen;
    public GameObject FinishScreen;
    public GameObject GameOverScreen;


    public static GameManager inst;
    
    public enum PlayerState
    {
        Prepare,
        Playing,
        Died,
        Shopping,
        Finish
    }

    public PlayerState playerState;
    
    

    private void Awake()
    {
        if (PlayerPrefs.HasKey("diaAmount"))
        {
            diamondCount = PlayerPrefs.GetInt("diaAmount");
        }
        else
        {
            diamondCount = 0;
            
        }

        inst = this;
        playerState = PlayerState.Prepare;
    }

    private void Start()
    {
    }

    void Update()
    {
        if (playerState == PlayerState.Prepare)
        {
            StartScreen.SetActive(true);
            diamondText.text = "" + (currentLevelDiamondCount + diamondCount) ;

        }

        if (playerState == PlayerState.Finish)
        {
                //bonusMultiplier = 1;
                
                //Calculates diamond amount to give player
                currentLevelDiamondCount *= bonusMultiplier;
                diamondCount += currentLevelDiamondCount;
            
                //Defaults them for next level
                currentLevelDiamondCount = 0;
                bonusMultiplier = 1;
                    
                //Updates the text
                diamondText.text = ""  + diamondCount ;
            
            
            PlayerPrefs.SetInt("diaAmount",diamondCount);

            FinishScreen.SetActive(true);
        }

        if (playerState == PlayerState.Died)
        {
            GameOverScreen.SetActive(true);
            currentLevelDiamondCount = 0;
        }
    }
    public void IncrementDiamond()
    {
        //Keeps it in temporary variable in case player dies before finishing
        currentLevelDiamondCount++;
        diamondText.text = "" + (currentLevelDiamondCount + diamondCount) ;
    }
    
    IEnumerator WaitAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(true);
    }

   
    
    
}
