using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Player player;
    public CameraFollow cameraFollow;
    public ObstacleValue obsDamage;
    public ObjectMovement obsAnimSpeed;
    //public GameObject obstacles;


    public TextMeshProUGUI playerMovementSpeed;
    public TextMeshProUGUI playerControlSpeed;
    public TextMeshProUGUI playerScale;
    public TextMeshProUGUI playerPixelScaleUp;
    public TextMeshProUGUI playerSphereScaleDownSpeed;

    public TextMeshProUGUI cameraXPos;
    public TextMeshProUGUI cameraYPos;
    public TextMeshProUGUI cameraZPos;
    public TextMeshProUGUI cameraXRotation;

    public TextMeshProUGUI obstacleAnimSpeed;
    public TextMeshProUGUI obstacleDamage;


    public TextMeshProUGUI cameraFOV;



    public GameObject debugMenuUI;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerMovementSpeed.text = playerMovement.movementSpeed.ToString();
        playerControlSpeed.text = playerMovement.controlSpeed.ToString();
        playerScale.text = playerMovement.gameObject.transform.localScale.x.ToString();
        playerPixelScaleUp.text = player.diamondPickUpScaleRate.ToString();
        playerSphereScaleDownSpeed.text = player.sphereScaleDownSpeed.ToString();

        cameraXPos.text = cameraFollow.offsetX.ToString();
        cameraYPos.text = cameraFollow.offsetY.ToString();
        cameraZPos.text = cameraFollow.offsetZ.ToString();
        cameraXRotation.text = cameraFollow.cameraXrotation.ToString();
        cameraFOV.text = cameraFollow.cameraFov.ToString();

        obstacleAnimSpeed.text = obsAnimSpeed.animSpeed.ToString();
        obstacleDamage.text = obsDamage.ObstacleDamage.ToString();



    }


    public void IncreaseMovementSpeed()
    {
        playerMovement.movementSpeed += 0.2f;
    }

    public void DecreaseMovementSpeed()
    {
        playerMovement.movementSpeed -= 0.2f;
    }

    public void IncreaseControlSpeed()
    {
        playerMovement.controlSpeed += 0.2f;
    }

    public void DecreaseControlSpeed()
    {
        playerMovement.controlSpeed -= 0.2f;
    }

    public void IncreasePlayerScale()
    {
        playerMovement.gameObject.transform.localScale += Vector3.one * 0.2f;
    }

    public void DecreasePlayerScale()
    {
        playerMovement.gameObject.transform.localScale -= Vector3.one * 0.2f;
    }

    public void IncreasePlayerPixelPickUpScale()
    {
        player.diamondPickUpScaleRate += 0.05f;
    }

    public void DecreasePlayerPixelPickUpScale()
    {
        player.diamondPickUpScaleRate -= 0.05f;
    }

    public void IncreaseSphereScaleDownSpeed()
    {
        player.sphereScaleDownSpeed += 0.001f;
    }

    public void DecreaseSphereScaleDownSpeed()
    {
        player.sphereScaleDownSpeed -= 0.001f;
    }


    public void IncreaseCameraXPos()
    {
        cameraFollow.offsetX += 0.5f;
    }

    public void DecreaseCameraXPos()
    {
        cameraFollow.offsetX -= 0.5f;
    }

    public void IncreaseCameraYPos()
    {
        cameraFollow.offsetY += 0.5f;
    }

    public void DecreaseCameraYPos()
    {
        cameraFollow.offsetY -= 0.5f;
    }

    public void IncreaseCameraZPos()
    {
        cameraFollow.offsetZ += 0.5f;
    }

    public void DecreaseCameraZPos()
    {
        cameraFollow.offsetZ -= 0.5f;
    }

    public void IncreaseCameraXRotation()
    {
        cameraFollow.cameraXrotation += 2f;
    }

    public void DecreaseCameraXRotation()
    {
        cameraFollow.cameraXrotation -= 2f;

    }

    public void IncreaseCameraFOV()
    {
        cameraFollow.cameraFov += 3f;
    }

    public void DecreaseCameraFOV()
    {
        cameraFollow.cameraFov -= 3f;
    }

    public void ObsCylinderDamageIncrease()
    {
        obsDamage.ObstacleDamage += 1f;
    }

    public void ObsCylinderDamageDecrease()
    {
        obsDamage.ObstacleDamage -= 1f;
    }

    public void ObsCylinderSpeedIncrease()
    {
        obsAnimSpeed.animSpeed += 3f;

        //foreach (Transform item in obstacles.transform)
        //{
        //    item.GetComponent<ObjectMovement>().animSpeed += 3f;
        //    Debug.Log("its working");
        //}
    }

    public void ObsCylinderSpeedDecrease()
    {
        obsAnimSpeed.animSpeed -= 3f;
    }

    public void OpenDebugSettings()
    {

        debugMenuUI.SetActive(true);
        GameManager.inst.StartScreen.SetActive(false);
        GameManager.inst.playerState = GameManager.PlayerState.Shopping;
    }

    public void CloseDebugSettings()
    {
        debugMenuUI.SetActive(false);
        GameManager.inst.StartScreen.SetActive(true);
        GameManager.inst.playerState = GameManager.PlayerState.Prepare;

    }
}
