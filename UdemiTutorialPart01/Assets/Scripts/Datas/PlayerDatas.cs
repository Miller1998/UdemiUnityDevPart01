using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipDatas
{
    [CreateAssetMenu(fileName = "player", menuName = "ControllableSpaceShip/AddNewSpaceShip")]
    public class PlayerDatas : ScriptableObject
    {
        #region Player_Information

        [Header("Space Ship Info")]
        public string spaceShipName;
        [TextArea(2,10)]
        public string spaceShipDesc;

        #endregion

        #region Player_Abilities

        [Header("Space Ship Abilities")]
        public int hp;
        public float movementSpeed;

        #endregion

        #region GameObject_Caller

        [Header("SpaceShip Model")]
        public GameObject ssModel;

        #endregion
    }

}