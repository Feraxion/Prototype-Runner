﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataSaver : MonoBehaviour
{

    //OYUN BASINDA VARIABLELAR BURADAN ALINIYOR KAYIT EDILDI ISE, EDILMEDIYSE DEFAULT VALUE 0
    public static void GetData()
    {
        coinAmount = PlayerPrefs.GetInt("coinAmount", 500);
        


    }
    
    //Creates the game object if there is none and makes sure that there is only 1 
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void RuntimeInit()
    {
        if (GameObject.FindWithTag("DataSaver") != null)
            return;

        var go = new GameObject { name = "[DataSaver]" };
        go.AddComponent<GameDataSaver>();
        DontDestroyOnLoad(go);
    }

    //YENI VARIABLELAR
    
    public static int coinAmount;
    




    private void Awake()
    {
        GetData();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void SaveData()
    {
        //Yeni variablelar burada kaydediliyor
        PlayerPrefs.SetInt("coinAmount",coinAmount);
        


        PlayerPrefs.Save();
        
    }

    

    private void OnApplicationPause(bool pauseStatus)
    {
        SaveData();
    }


    // Update is called once per frame
    void Update()
    {
       
        
    }
}
