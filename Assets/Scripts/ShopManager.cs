using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    public GameObject[] hats;
    public GameObject currentHat;
    public GameObject purchaseHat;
    public GameObject shopUI;

    public int currentHatInArray;
    public int purchaseCost;

    public bool isPurchase;
    public bool hasHat;
    
    
    public static ShopManager inst;
    

    void Awake()
    {
        inst = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        //Makes sure everything in sync
        hats[0].gameObject.SetActive(false);
        currentHat = hats[0];
        currentHatInArray = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Gets current hat on screen
        currentHat = hats[currentHatInArray];
        if (isPurchase == true)
        {
            purchaseHat.SetActive(true);
        }
    }


    public void PurchaseButton()
    {
        //Makes sure that player can afford it
        if (GameManager.inst.diamondCount >= purchaseCost)
        {
            GameManager.inst.diamondCount -= purchaseCost;
            isPurchase = true;
            purchaseHat = currentHat;
            RemoveAt(ref hats, currentHatInArray);
            Debug.Log("Purchase Success");
        }
    }

    public void OpenShop()
    {
        shopUI.SetActive(true);
        GameManager.inst.StartScreen.SetActive(false);
        GameManager.inst.playerState = GameManager.PlayerState.Shopping;
    }

    public void CloseShop()
    {
        shopUI.SetActive(false);
        GameManager.inst.StartScreen.SetActive(true);
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
        hats[currentHatInArray].gameObject.SetActive(false);
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
        hats[currentHatInArray].gameObject.SetActive(false);
    }

    public static void RemoveAt<T>(ref T[] arr, int index)
    {
        // replace the element at index with the last element
        arr[index] = arr[arr.Length - 1];
        // finally, let's decrement Array's size by one
        Array.Resize(ref arr, arr.Length - 1);
    }
}
