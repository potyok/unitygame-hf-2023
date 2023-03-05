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

    public Slider healthBar;

    private int totalScore = 0;
    private float totalDistance = 0f;
    private int heart;

    private float streetSpeed = 10f;
    private float diffSpeed = 3f;
    private int maxHeart = 100;
    private int coinValue = 200;
    private int repairValue = 10;

    private bool isGone = true;

    public float SteeringSpeed {
        get; private set;
    }

    void Start() {
        SteeringSpeed = 2f;
        heart = maxHeart;
        healthBar.value = heart;
        
        headerPanel.SetActive(true);
        endingPanel.SetActive(false);
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

    private void handleHealthBar() {
        if (!isGone) return;
        healthBar.value = Mathf.Max(0, heart);
        if (healthBar.value == 0) {
            streetSpeed = 0f;
            diffSpeed = 0f;
            SteeringSpeed = 0f;
            handleEnd();
        }
    }

    public void handleCoin() {
        totalScore += coinValue;
    }

    private void handleEnd() {
        isGone = false;
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

    
    void Update()
    {
        if (!isGone)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
            else if (Input.GetKeyDown(KeyCode.Escape)) {
                Application.Quit();
            }
        }
        else {
            totalDistance += streetSpeed * Time.deltaTime * 0.01f;
            distanceText.text = $"Distance: {(int)totalDistance} km";
            streetSpeed += Time.deltaTime * 0.03f;
            SteeringSpeed += Time.deltaTime * 0.003f;
            handleHealthBar();
        }
        
    }
}
