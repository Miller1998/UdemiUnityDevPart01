using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShipDatas;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("GameObject Caller")]
    public Player player;
    public GameObject cam;

    [Header("UI Scene Management")]
    public GameObject GameOverMenu;
    public GameObject PauseMenu;
    public GameObject PlayerMenu;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI playerScoreText;
    public TextMeshProUGUI score;
    public TextMeshProUGUI spaceShipPlayerHP;

    [Header("playerSumary")]
    [SerializeField]
    private int playerScore;
    [SerializeField]
    private int highScore;
    [SerializeField]
    bool pmActive = false;

    // Awake is called when the scene started
    void Awake()
    {

        PlayerPrefs.SetString("TheChoosenOne", player.playerDatas[0].spaceShipName);
    
    }

    // Start is called before the first frame update
    void Start()
    {
        
        highScore = PlayerPrefs.GetInt("HighScore");
        PlayerPrefs.SetInt("TotalScore", 0);

    }

    // Update is called once per frame
    void Update()
    {

        RunTimeScoring(playerScore, player.spaceShipHP, score, spaceShipPlayerHP);

        if (player.spaceShipHP <= 0)
        {
            cam.transform.parent = null;
            ScoreChecking(playerScore, highScore, playerScoreText, highScoreText);
            //show UI GameOver
            GameOverMenu.gameObject.SetActive(true);
            PlayerMenu.gameObject.SetActive(false);
            
        }
        else
        {
            //hide UI Gameover
            GameOverMenu.gameObject.SetActive(false);
            PlayerMenu.gameObject.SetActive(true);
        }

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void ScoreChecking(int playerScore, int highScore, TextMeshProUGUI psText, TextMeshProUGUI hsText)
    {

        playerScore = PlayerPrefs.GetInt("TotalScore");

        if (highScore <= playerScore)
        {

            highScore = playerScore;

            PlayerPrefs.SetInt("HighScore", highScore);
            
            psText.text = "PlayerScore = " + playerScore.ToString();
            hsText.text = "HighScore = " + highScore.ToString();

        }
        else
        {

            psText.text = "PlayerScore = " + playerScore.ToString();
            hsText.text = "HighScore = " + highScore.ToString();

        }

    }

    void RunTimeScoring(int playerScore, int playerHP, TextMeshProUGUI playerScoreText, TextMeshProUGUI spaceShipPlayerHP)
    {
        playerScore = PlayerPrefs.GetInt("TotalScore");
        playerScoreText.text = "PlayerScore = " + playerScore.ToString();
        spaceShipPlayerHP.text = "PlayerHP = " + playerHP.ToString();
    }

    public void PauseMenuSetUp()
    {

        pmActive = !pmActive;
        
        if (pmActive == true)
        {
            Time.timeScale = 0;
            PauseMenu.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            PauseMenu.gameObject.SetActive(false);
        }

    }

    public void ResetHighScore()
    {
        highScoreText.text = "HighScore = --";
        PlayerPrefs.SetInt("HighScore", highScore);
    }

}
