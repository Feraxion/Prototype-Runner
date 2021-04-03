using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Diamond Stats")]
    [SerializeField] public int diamondCount;
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

        if (playerState == PlayerState.Died)
        {
            GameOverScreen.SetActive(true);
        }
    }
    public void IncerementDiamond()
    {
        diamondCount++;
        diamondText.text = "" + diamondCount;
    }
    
    IEnumerator WaitAfterSeconds(int seconds, GameObject obj)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(true);
    }

   
    
    
}
