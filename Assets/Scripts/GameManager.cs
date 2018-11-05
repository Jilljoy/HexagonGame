using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static bool IsGameInProgress { get; private set; }

    public int HighScore { get; private set; }
    private int _currentScore;
    public int CurrentScore
    {
        get
        {
            return _currentScore;
        }
        private set
        {
            _currentScore = value;
            ScoreModified();
            UpdateScoreTexts();
        }
    }

    Rotator mainCameraRotator;
    public PlayerScript playerScript;
    public Text currentScoreText;
    public Text highScoreText;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        mainCameraRotator = Camera.main.GetComponent<Rotator>();

        mainCameraRotator.rotateSpeed = 30f;
        IsGameInProgress = true;
    }

    private void Update()
    {
        if (IsGameInProgress == false)
        {
            if (Input.GetKey(KeyCode.R))
            {
                IsGameInProgress = true;
            }
        }
    }

    public void GameOver()
    {
        if (CurrentScore > HighScore) HighScore = CurrentScore;

        CurrentScore = 0;

        IsGameInProgress = false;
    }

    public void IncreaseCurrentScore(int amountToIncrease)
    {
        CurrentScore += amountToIncrease;
    }

    void ScoreModified()
    {
        if (CurrentScore == 0) return;

        if (CurrentScore % 5 == 0)
        {
            //Reverse Camera rotation
            mainCameraRotator.rotateSpeed *= -1f;
        }
        if (CurrentScore % 10 == 0)
        {
            Spawner.Instance.SetNewRandomSpawnRate();
        }
        if (CurrentScore % 15 == 0)
        {
            ReverseInputDirection();
        }
    }

    public void PickupCollected(PickupType type)
    {
        switch (type)
        {
            case PickupType.IncreaseSpawnRate:
                Spawner.Instance.IncreaseSpawnRate(0.2f);
                break;
            case PickupType.DecreaseSpawnRate:
                Spawner.Instance.DecreaseSpawnRate(0.2f);
                break;
            case PickupType.ReverseInputDirection:
                ReverseInputDirection();
                break;
            case PickupType.None:
                //Do nothing so return
                break;
            default:
                throw new NotImplementedException(string.Concat("The type: '", type, "', does not exist in the Enum PickupType"));
        }
    }

    void ReverseInputDirection()
    {
        //Reverse control direction
        playerScript.inputDirection *= -1f;
    }


    void UpdateScoreTexts()
    {
        highScoreText.text = HighScore.ToString();
        currentScoreText.text = CurrentScore.ToString();
    }


    public static PickupType GetRandomPickupType()
    {
        int rand = UnityEngine.Random.Range(0, 100);
        if (rand <= (int)PickupType.IncreaseSpawnRate)
        {
            return PickupType.IncreaseSpawnRate;
        }
        else if (rand <= (int)PickupType.DecreaseSpawnRate)
        {
            return PickupType.DecreaseSpawnRate;
        }
        else if (rand <= (int)PickupType.ReverseInputDirection)
        {
            return PickupType.ReverseInputDirection;
        }
        else
        {
            return PickupType.None;
        }
    }

}

public enum PickupType
{
    IncreaseSpawnRate = 10,
    DecreaseSpawnRate = 20,
    ReverseInputDirection = 30,
    None = 100
}