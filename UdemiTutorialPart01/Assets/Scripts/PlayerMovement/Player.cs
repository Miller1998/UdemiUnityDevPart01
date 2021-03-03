using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShipDatas;

public class Player : MonoBehaviour
{
    #region Public_Variables

    [Header("Player Data")]
    public PlayerDatas[] playerDatas;
    
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


    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {

        PlayerControl("MovingLeft", "MovingRight", movementSpeed);

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

    void WallCollider()
    {

    }

    void GotHit()
    {

    }

    void ItemBooster()
    {

    }

    #endregion

    void DestroySelf()
    {
        //destroying SpaceShip
    }

}
