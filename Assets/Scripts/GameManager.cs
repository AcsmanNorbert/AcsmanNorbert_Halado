using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region SETUP
    public static GameManager i;

    void Awake()
    {
        if (i != null)
            Debug.LogError("Több GameManager létezik");
        i = this;
    }
    #endregion

    [SerializeField] int startLives = 100;
    [SerializeField] int startMoney = 100;

    float gameTime;
    int currentLives;
    int currentMoney;

    private void Start()
    {
        currentLives = startLives;
        currentMoney = startMoney;
    }

    public int Money
    {
        get => currentMoney;
        set
        {
            currentMoney = Mathf.Max(0, value);
            Debug.Log($"Current Money: {currentMoney}");
        }
    }

    public void Damage(int damage)
    {
        currentLives -= damage;
        if (currentLives <= 0)
        {
            Debug.Log("GameOver");
        }
        else
            Debug.Log($"Gamer Lives: {currentLives}");
    }
}
