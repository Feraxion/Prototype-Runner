using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Diamond Stats")]
    [SerializeField] public int diamondCount;
    [SerializeField] public Text diamondText;

    public static GameManager inst;

    private void Awake()
    {
        inst = this;
    }

    void Update()
    {
        
    }
    public void IncerementDiamond()
    {
        diamondCount++;
        diamondText.text = "Score: " + diamondCount; // change with image later
    }
}
