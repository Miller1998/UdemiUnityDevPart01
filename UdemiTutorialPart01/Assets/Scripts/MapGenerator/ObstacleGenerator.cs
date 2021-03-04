using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Obstacles;

public class ObstacleGenerator : MonoBehaviour
{
    #region PUBLIC_VARIABLE
    public ObstacleDatas[] obstacle;
    #endregion

    #region PRIVATE_VARIABLE
    private float rnd;

    [Header("Obstacle or Item abilities")]
    int additionalHP;
    float movementSpeed;
    #endregion

    void Awake()
    {
        obstacle = Resources.LoadAll("Datas/ObstacleAndItem", typeof(ObstacleDatas)).Cast<ObstacleDatas>().ToArray();
    }

    void Start()
    {
        ObstacleGeneration();
    }

    void ObstacleGeneration()
    {
        rnd = Random.Range(10, 30);

        for (int i = 0; i < rnd; i++)
        {

            int rndObj = Random.Range(0, obstacle.Length);
            GameObject loadModel = obstacle[rndObj].itemModel;

            Vector3 tempCoord = new Vector3(Random.Range(-45, 45), 4, Random.Range(transform.position.z - 100, transform.position.z + 100));

            GameObject temp = Instantiate(loadModel, tempCoord, Quaternion.identity, this.transform.parent);

        }
    }

}
