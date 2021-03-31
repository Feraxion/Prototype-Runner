using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressUI : MonoBehaviour
{
    [Header("UI references :")]
    [SerializeField] private Image uiFillImage;
    [SerializeField] private Text uiCurrentLevel;
    [SerializeField] private Text uiNextLevel;

    [Header("Player & Finish Line references :")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform finishLineTransform;

    private Vector3 finishLinePosition; // get finish position

    private float fullDistance; // get game progress
    
    void Start()
    {
        finishLinePosition = finishLineTransform.position;
        fullDistance = GetDistance();
    }
    
    void Update()
    {
        if (playerTransform == null)
        {
            return;
        }
        if (playerTransform.position.z <= finishLinePosition.z)
        {
            float newDistance = GetDistance();
            float progressValue = Mathf.InverseLerp(fullDistance, 0f, newDistance);
            UpdateProgressFill(progressValue);
        }
    }
    
    private void UpdateProgressFill(float value)
    {
        uiFillImage.fillAmount = value;
    }
    
    private float GetDistance()
    {
        return Vector3.Distance(playerTransform.position, finishLinePosition);  //getting full distance
        // return (finishLinePosition - playerTransform.position).sqrMagnitude; // more performance able // cuz of sqrMagnitude not true for finish progress
    }
    
    public void SetLevelTexts(int level)  // setting level text
    {
        uiCurrentLevel.text = level.ToString();
        uiNextLevel.text = (level + 1).ToString();
    }
}
