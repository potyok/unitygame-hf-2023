using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI totalDistanceText;

    public GameObject headerPanel;
    public GameObject endingPanel;
    public GameObject pasuePanel;

    public Slider healthBar;
    public Transform pointer;

    private int totalScore = 0;
    private float totalDistance = 0f;
    private int heart;

    private float streetSpeed = 10f;
    private float diffSpeed = 3f;
    private int maxHeart = 100;
    private int coinValue = 200;
    private int repairValue = 5;

    private float tankLevel = 100f;
    private float maxTankLevel = 100f;
    private float rotationRadius = 140f;
    private float baseRotationRadius = -135f;

    public List<AudioSource> inGameSounds;

    private bool isGone = true;
    private bool endTurn = false;

    public float SteeringSpeed {
        get; private set;
    }

    void Start() {
        SteeringSpeed = 2f;
        heart = maxHeart;
        healthBar.value = heart;
        
        headerPanel.SetActive(true);
        endingPanel.SetActive(false);
        pasuePanel.SetActive(false);
        handleSounds();
    }

    public float getSpeed(bool isVehicle, bool isFrontDirection) {
        if (isVehicle && isFrontDirection) return streetSpeed - diffSpeed;
        else if (isVehicle && !isFrontDirection) return streetSpeed + diffSpeed;
        return streetSpeed;
    }

    public void handleDamage(int dmg) {
        heart -= dmg;
        handleHealthBar();
    }

    private void stopMoving() {
        streetSpeed = 0f;
        diffSpeed = 0f;
        SteeringSpeed = 0f;
    }

    private void handleHealthBar() {
        if (!isGone) return;
        healthBar.value = Mathf.Max(0, heart);
        if (healthBar.value == 0) {
            stopMoving();
            handleEnd();
        }
    }

    private void handleTankLevel() {
        if (!isGone) return;
        pointer.transform.rotation = Quaternion.Euler(0f, 0f, baseRotationRadius + rotationRadius * (1f - tankLevel / maxTankLevel));
        if (tankLevel <= 0) {
            stopMoving();
            handleEnd();
        }
    }

    public void handleCoin() {
        totalScore += coinValue;
    }

    private void handleEnd() {
        isGone = false;
        endTurn = true;
        handleSounds();
        totalScore += (int)(totalDistance * 1000f);
        scoreText.text = $"{totalScore} points";
        totalDistanceText.text = $"{(int)totalDistance} km";
        headerPanel.SetActive(false);
        endingPanel.SetActive(true);
    }

    public void handleRepair() {
        heart = Mathf.Min(maxHeart, heart + repairValue);
        healthBar.value = heart;
    }

    public void handleFillTank(float amount) {
        tankLevel = Mathf.Min(maxTankLevel, tankLevel + amount);
    }


    private void handleSounds() {
        foreach (var sound in inGameSounds) {
            if (isGone) sound.Play();
            else sound.Pause();
        }
    }
    
    void Update()
    {
        if (!isGone)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            else if (Input.GetKeyDown(KeyCode.P) && !endTurn) {
                isGone = true;
                handleSounds();
                Time.timeScale = 1;
                pasuePanel.SetActive(false);
            }
        }
        else {
            if (Input.GetKeyDown(KeyCode.P)) {
                isGone = false;
                handleSounds();
                Time.timeScale = 0;
                pasuePanel.SetActive(true);
            }
            totalDistance += streetSpeed * Time.deltaTime * 0.01f;
            distanceText.text = $"Distance: {(int)totalDistance} km";
            streetSpeed += Time.deltaTime * 0.03f;
            SteeringSpeed += Time.deltaTime * 0.003f;
            tankLevel -= Time.deltaTime * 2f;
            handleHealthBar();
            handleTankLevel();
        }
        
    }
}
