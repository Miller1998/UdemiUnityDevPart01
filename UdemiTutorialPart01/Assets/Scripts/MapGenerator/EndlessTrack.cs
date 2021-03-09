using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTrack : MonoBehaviour
{   
    #region Public_Variables
    [Header("Game Object Caller")]
    public GameObject invisibleTrack;
    public GameObject parentTrack;
    public int challengePlayerEvery = 20;
    #endregion
    #region Private_Variables
    [SerializeField]
    float generatedSpeed;
    [SerializeField]
    float deletionDistance = -200;//similiar with field of view
    [SerializeField]
    float addSpeed = 20;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int totalScore = PlayerPrefs.GetInt("TotalScore");

        if (totalScore == challengePlayerEvery)
        {
            GeneratedInvisibleTrackField(generatedSpeed + addSpeed);
            challengePlayerEvery += 20;
        }
    
    }

    public void GeneratedInvisibleTrackField(float moveSpeed)
    {

        parentTrack.transform.Translate(-Vector3.forward * Time.deltaTime * moveSpeed);


        if (parentTrack.gameObject.transform.position.z <= deletionDistance)
        {

            Destroy(parentTrack.gameObject.transform.GetChild(0).gameObject);
            deletionDistance = deletionDistance + (-200);

            GameObject temp = Instantiate(invisibleTrack, Vector3.zero, Quaternion.identity);
            temp.transform.position = new Vector3(0, 0, parentTrack.gameObject.transform.GetChild(parentTrack.gameObject.transform.childCount - 1).transform.position.z + 200f);
            temp.transform.parent = parentTrack.transform;
        }

    }

}
