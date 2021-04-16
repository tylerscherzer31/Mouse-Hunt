using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTracks : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] leftTracks;
    public GameObject[] rightTracks;
    private GameObject backRightTrack;
    private GameObject backLeftTrack;
    private int indexOfFrontTrack = 0;
    public float speedOfTracks = 10f;
    private Vector3 currentPosition;
    void Start()
    {
        currentPosition = transform.position;
        backLeftTrack = leftTracks[leftTracks.Length-1];
        backRightTrack = rightTracks[rightTracks.Length-1];
    }

    // Update is called once per frame
    void Update()
    {
        if(GameState.mode == GameState.GameMode.playing)
        {
            transform.Translate(Vector3.back * speedOfTracks * Time.deltaTime);
            if (transform.position.z < currentPosition.z - 2.54)
            {
                transform.position = currentPosition;//new Vector3(currentPosition.x,currentPosition.y,currentPosition.z);
                                                     //currentPosition = transform.position;
                                                     /*
                                                     var frontRightTrack = rightTracks[indexOfFrontTrack];
                                                     var frontLeftTrack = leftTracks[indexOfFrontTrack];
                                                     Vector3 rightBackPos = backRightTrack.transform.position;
                                                     frontRightTrack.transform.position = new Vector3(rightBackPos.x, rightBackPos.y, rightBackPos.z + 2.54f);
                                                     Vector3 leftBackPos = backLeftTrack.transform.position;
                                                     frontLeftTrack.transform.position = new Vector3(leftBackPos.x, leftBackPos.y, leftBackPos.z + 2.54f);
                                                     backLeftTrack = frontLeftTrack;
                                                     backRightTrack = frontRightTrack;
                                                     indexOfFrontTrack++;
                                                     if(indexOfFrontTrack > leftTracks.Length-1)
                                                     {
                                                         indexOfFrontTrack = 0;
                                                     }
                                                     */


            }
        }

 
    }
}
