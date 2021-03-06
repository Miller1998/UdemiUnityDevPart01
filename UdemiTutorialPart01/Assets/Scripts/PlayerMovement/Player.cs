using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using SpaceShipDatas;
using Obstacles;

public class Player : MonoBehaviour
{
    #region Public_Variables

    [Header("Player Data")]
    public PlayerDatas[] playerDatas;
    public ObstacleDatas[] obstacleDatas;

    [Header("Player")]
    public int scoreTotal = 0;
    public int spaceShipHP = 0;

    #endregion

    #region Private_Variables

    [Header("Game Object Caller")]
    [SerializeField]
    private GameObject spaceShipModel;

    [Header("Player Data")]
    [SerializeField]
    private string spaceShipName = "";


    [Header("Space Ship Movement")]
    [SerializeField]
    private float movementSpeed = 0;
    #endregion

    void Awake()
    {
        playerDatas = Resources.LoadAll("Datas/SpaceShipMovement", typeof(PlayerDatas)).Cast<PlayerDatas>().ToArray();
        obstacleDatas = Resources.LoadAll("Datas/ObstacleAndItem", typeof(ObstacleDatas)).Cast<ObstacleDatas>().ToArray();
    }

    // Start is called before the first frame update
    void Start()
    {

        SpaceShipCaller();

    }

    // Update is called once per frame
    void Update()
    {

        PlayerControl("MovingLeft", "MovingRight", movementSpeed);

        //collider system
        //HP System
        if (spaceShipHP <= 0)
        {
            //Destroy SpaceShip Model and call Game Over GUI
            Destroy(spaceShipModel.gameObject);
        }
        /*else
        {
            //Score Added due to the how long player survive
            scoreTotal = scoreTotal + 2;
            //Debug.Log("Total Score : " + scoreTotal);
        }*/

    }

    void SpaceShipCaller()
    {
        string choosenSpaceShip = PlayerPrefs.GetString("TheChoosenOne");


        for (int i = 0; i < playerDatas.Length; i++)
        {
            if (playerDatas[i].spaceShipName == choosenSpaceShip)
            {
                //set this gameobject as parent and generate prefabs inside it
                spaceShipModel = (GameObject)Instantiate(playerDatas[i].ssModel, this.transform.position, Quaternion.identity, this.transform);

                //Get this spaceship datas
                spaceShipName = playerDatas[i].spaceShipName;
                spaceShipHP = playerDatas[i].hp;
                movementSpeed = playerDatas[i].movementSpeed;
            }
        }
    }

    #region PlayerAction

    void PlayerControl(string moveLeftKey, string moveRightKey, float movementSpeed/*, float booster*/)
    {
        //Controlling GameObject
        if (Input.GetButton(moveLeftKey))
        {
            this.gameObject.transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
            //execute animation DodgeRight
        }
        else if (Input.GetButton(moveRightKey))
        {
            this.gameObject.transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
            //execute animation move DodgeRight
        }

    }

    #endregion

    #region Collider_Unity

    void OnTriggerEnter(Collider other)
    {

        for (int i = 0; i < obstacleDatas.Length; i++)
        {
            
            if (other.gameObject.tag.Contains(obstacleDatas[i].itemName) && obstacleDatas[i].itemName.Contains("Fuel"))
            {
                
                Destroy(other.gameObject);
                spaceShipHP = spaceShipHP + obstacleDatas[i].additionalHP;
                //Debug.Log("SpaceShip HP : " + spaceShipHP);
                
                //added score based on how many Fuel that we get
                scoreTotal = scoreTotal + 5;
                //save in the game data
                PlayerPrefs.SetInt("TotalScore", scoreTotal);
            
            }
            else if (other.gameObject.tag.Contains(obstacleDatas[i].itemName) && obstacleDatas[i].itemName.Contains("Asteroid01"))
            {
                Destroy(other.gameObject);
                spaceShipHP = spaceShipHP + obstacleDatas[i].additionalHP;
                //Debug.Log("SpaceShip HP : " + spaceShipHP);
            }
            else if (other.gameObject.tag.Contains(obstacleDatas[i].itemName) && obstacleDatas[i].itemName.Contains("Asteroid02"))
            {
                Destroy(other.gameObject);
                spaceShipHP = spaceShipHP + obstacleDatas[i].additionalHP;
                //Debug.Log("SpaceShip HP : " + spaceShipHP);
            }
        
        }

    }

    #endregion

}
