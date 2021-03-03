using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShipDatas;

public class GameManager : MonoBehaviour
{

    public Player player;

    // Awake is called when the scene started
    void Awake()
    {
        PlayerPrefs.SetString("TheChoosenOne", player.playerDatas[1].spaceShipName);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
