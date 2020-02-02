using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackRoom : MonoBehaviour
{

    public GameObject lc;

    public GameObject player;

    public Camera mainCam;

    // Update is called once per frame
    void Update()
    {
         if(player.GetComponent<PlayerController>().EnterTriggerBack)
        {
        Debug.Log("Entered Backward update");
        LevelCreator levelc = lc.GetComponent<LevelCreator>();
        //int next = levelc.getNextRoom();
       // Debug.Log("Next room: " + next);
        GameObject nextRoom = levelc.visitedLevels[levelc.visitedLevels.Count - 1];
        RoomInfo roomInfo = nextRoom.GetComponent<RoomInfo>();
        //Debug.Log("Actual next room is: " + nextRoom.name);
        Vector3 nextSpawn = nextRoom.transform.Find("SpawnBack").transform.position;
        float extradistance = roomInfo.roomNo * levelc.distancebetweenlevels;
        nextSpawn.x += extradistance;
       // Debug.Log("Next spawn: " + nextSpawn);
        player.transform.position = nextSpawn;
        Vector3 camSpawn = levelc.visitedLevels[levelc.visitedLevels.Count - 1].transform.position;
        camSpawn.x += extradistance;
        camSpawn.z = -10.0f;
        mainCam.transform.position = camSpawn;
       // RoomInfo roominfo = nextRoom.GetComponent<RoomInfo>();
        mainCam.orthographicSize = roomInfo.CamSize;
        //levelc.visitedLevels.Add(levelc.levels[next]);
       // levelc.levels.Remove(levelc.levels[next]);
        player.GetComponent<PlayerController>().EnterTrigger = false;
        }
    }
}
