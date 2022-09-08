using UnityEngine;

public class ScriptGameManager : MonoBehaviour
{
    public static ScriptGameManager gmInstance;

    public int money, killPunish = 850, hostagesLeft = 4, hostagesRescued, enemiesLeft, reward = 150;
    public float regenLife = 0.5f, playerLife, maxPlayerLife = 100f;
    public bool  allEnemyDead, godMode, bombDefused, hostagesDeadBool;
    public static int moneyUpDown, initialMoney = 3500;
    public static bool areYouWinning, gameOver;

    void Awake()
    {
        if (ScriptGameManager.gmInstance == null)
        {
            ScriptGameManager.gmInstance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NewGame()
    {
        ScriptC4Bomb.timeToExplode = ScriptC4Bomb.timerMaxBomb;
        //ScriptC4Bomb.explosionPS.Stop();
        hostagesRescued = 0;
        hostagesLeft = 4;
        enemiesLeft = 5;
        Time.timeScale = 1;
        playerLife = maxPlayerLife;
        ScriptFPSRB.canMove = true;
        ScriptGunSystem.canShoot = true;
        money = initialMoney;
        areYouWinning = false;
        gameOver = false;
    }

    void Update()
    {
        IsPlayerDead();
        LifeRegen();
        WinCondition();
    }

    void LifeRegen()
    {
        if (playerLife > 0 && playerLife < maxPlayerLife && !ScriptUIManager2.pauseActive)
        {
            playerLife += regenLife * Time.deltaTime;
        }
    }

    void IsPlayerDead()
    {
        if (playerLife <= 0)
        {
            playerLife = 0;
            ScriptFPSRB.canMove = false;
            ScriptGunSystem.canShoot = false;
            gameOver = true;
        }
    }

    /*
    public void PlayerTakeDamage(float damage)
    {
            playerLife -= damage;
    }
    
    
    public void PickAmmo(int ammo)
    {
        ScriptAK47.ammo += ammo;
    }
    */

    void WinCondition()
    {
        if (hostagesLeft <= 0 && hostagesRescued <= 1)
        {
            hostagesDeadBool = true;
        }

        if (ScriptC4Bomb.timeToExplode <= 0 || hostagesDeadBool)
        {
            gameOver = true;
            hostagesDeadBool = false;
        }

        if (enemiesLeft <= 0)
        {
            allEnemyDead = true;
        }
        else
        {
            allEnemyDead = false;
        }

        if (bombDefused && enemiesLeft == 0 && hostagesLeft == 0 && hostagesRescued >= 2)
        {
            areYouWinning = true;
        }
    }

    public static void MoneyUpDown(int money)
    {
        ScriptGameManager.gmInstance.money += money;
        moneyUpDown = money;
        ScriptUIManager2.moneyUpDownTimer = 5f;
        ScriptUIManager2.moneyUpDownBool = true;
    }
}
