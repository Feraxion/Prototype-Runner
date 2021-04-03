using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    public GameObject[] hats;
    public GameObject currentHat;
    public GameObject shopUI;

    public int currentHatInArray;
    public int purchaseCost;
    
    
    public static ShopManager inst;
    public GameObject startScreen;

    void Awake()
    {
        inst = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        //Makes sure everything in sync
        hats[0].gameObject.SetActive(true);
        currentHat = hats[0];
        currentHatInArray = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Gets current hat on screen
        currentHat = hats[currentHatInArray];
    }


    public void PurchaseButton()
    {
        //Makes sure that player can afford it
        if (GameManager.inst.diamondCount >= purchaseCost)
        {
            GameManager.inst.diamondCount -= purchaseCost;
            Debug.Log("Purchase Success");
        }
        
    }

    public void OpenShop()
    {
        shopUI.SetActive(true);
        startScreen.SetActive(false);
        GameManager.inst.playerState = GameManager.PlayerState.Shopping;
    }

    public void CloseShop()
    {
        shopUI.SetActive(false);
        startScreen.SetActive(true);
        GameManager.inst.playerState = GameManager.PlayerState.Prepare;

    }

    public void NextButton()
    {
        
        hats[currentHatInArray].gameObject.SetActive(false);
        if (currentHatInArray + 1 >= hats.Length)
        {
            currentHatInArray = 0;
        }
        else
        {
            currentHatInArray++;

        }
        hats[currentHatInArray].gameObject.SetActive(true);
    }
    
    public void PreviousButton()
    {
        hats[currentHatInArray].gameObject.SetActive(false);
        if (currentHatInArray - 1 < 0)
        {
            currentHatInArray = hats.Length - 1;
        }
        else
        {
            currentHatInArray--;

        }
        hats[currentHatInArray].gameObject.SetActive(true);
    }
}
