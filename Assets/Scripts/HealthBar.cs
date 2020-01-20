using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {

    public Health health;
    public Timer timer;
    public int startingHealth;
    public float damageOverTimeThisLevel;
    private Image barImage;
    private int food = 0;
    private int bomb = 0;
    private int cannonBall = 0;
    private static float foodCount;
    private static float bombCount;
    private static float cannonBallCount;

    private void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();
        health = new Health(startingHealth, damageOverTimeThisLevel);
    }

    private void Update()
    {
        health.Update();

        foodCount = Monster.food;
        bombCount = Monster.bomb;
        cannonBallCount = Monster.cannonBall;
        if (foodCount > food)
        {
            food += 1;
            health.GainHealth(15);
        }

        if (bombCount > bomb)
        {
            bomb += 1;
            health.LooseHealth(10);
        }

        if (cannonBallCount > cannonBall)
        {
            cannonBall += 1;
            health.LooseHealth(5);
        }

        if (health.healthAmount >= 100)
        {
            timer.GameWon();
            SceneManager.LoadScene("Scenes/GameWon");
        }

        if (health.healthAmount <= 0)
        {
            SceneManager.LoadScene("Scenes/GameLost");
        }

        barImage.fillAmount = health.GetHealthNormalized();
    }

}


public class Health
{

    public const int HEALTH_MAX = 100;

    private Monster monster;

    public float healthAmount;
    public float damageOverTime;

    public Health(int startingHealth, float damageOverTimeThisLevel)
    {
            healthAmount = startingHealth;
            damageOverTime = damageOverTimeThisLevel;
        /*    healthAmount = 50;
            damageOverTime = -2f;*/
    }

    public void Update()
    {
        healthAmount += damageOverTime * Time.deltaTime;
        
    }

    public void GainHealth(int amount)
    {

        healthAmount += amount;

    }

    public void LooseHealth(int amount)
    {

        healthAmount -= amount;

    }

    public float GetHealthNormalized()
    {
        return healthAmount / HEALTH_MAX;
    }

}
