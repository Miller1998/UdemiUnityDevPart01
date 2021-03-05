using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShipDatas;

public class GameManager : MonoBehaviour
{
    [Header("GameObject Caller")]
    public Player player;
    public GameObject cam;

    [Header("playerSumary")]
    [SerializeField]
    private int totalScore;

    // Awake is called when the scene started
    void Awake()
    {
        PlayerPrefs.SetString("TheChoosenOne", player.playerDatas[0].spaceShipName);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (player.spaceShipHP <= 0)
        {
            cam.transform.parent = null;
            totalScore = PlayerPrefs.GetInt("HighScore");
            //show score @ UI
        }

    }
}
