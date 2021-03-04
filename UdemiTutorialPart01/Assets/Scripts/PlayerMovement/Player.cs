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
    #endregion

    #region Private_Variables

    [Header("Game Object Caller")]
    [SerializeField]
    private GameObject spaceShipModel;

    [Header("Player Data")]
    [SerializeField]
    private string spaceShipName = "";
    [SerializeField]
    private int spaceShipHP = 0;

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
        if (spaceShipHP == 0)
        {
            //Destroy SpaceShip Model and call Game Over GUI
        }
        else
        {
            //Score Added due to the how long player survive
        }

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

        if (other.gameObject.name.Contains("Blue Scifi Rock 1"))//if strings contain some specified string
        {
            
            for (int i = 0; i < obstacleDatas.Length; i++)
            {
                if (obstacleDatas[i].itemName == "Fuel")
                {
                    spaceShipHP = spaceShipHP + obstacleDatas[i].additionalHP;
                    Debug.Log("spaceShipHP = " + spaceShipHP);
                    Destroy(other.gameObject);//3 times added??? fix it 
                }
            }

        }

    }

    void OnCollisionEnter(Collision col)
    {
        //can't be detected
        if (col.gameObject.name == "Asteroid Lava Blue")
        {

            for (int i = 0; i < obstacleDatas.Length; i++)
            {

                if (obstacleDatas[i].itemName == "Asteroid01")
                {
                    spaceShipHP = spaceShipHP + obstacleDatas[i].additionalHP;
                    Debug.Log("spaceShipHP = " + spaceShipHP + " - " + obstacleDatas[i].additionalHP);
                }

            }

        }
        else if (col.gameObject.name == "Asteroid Lava Red")
        {
            
            for (int i = 0; i < obstacleDatas.Length; i++)
            {
                
                if (obstacleDatas[i].itemName == "Asteroid02")
                {
                    spaceShipHP = spaceShipHP + obstacleDatas[i].additionalHP;
                    Debug.Log("spaceShipHP = " + spaceShipHP + " - " + obstacleDatas[i].additionalHP);
                }

            }

        }

    }


    #endregion

    void DestroySelf()
    {
        //destroying SpaceShip
    }

}
