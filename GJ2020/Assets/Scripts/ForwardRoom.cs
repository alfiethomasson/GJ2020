using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardRoom : MonoBehaviour
{
    
    public GameObject lc;

    public GameObject player;

    public Camera mainCam;

    public int link = -1;
    void Start()
    {

        //player = GameObject.FindWithTag("Player");

    }

    void Update()
    {
 //       Debug.Log
        if(player.GetComponent<PlayerController>().EnterTrigger)
        {
            if(link != -1)
            {

            }

        Debug.Log("Entered forward update");
        LevelCreator levelc = lc.GetComponent<LevelCreator>();
        int next = levelc.getNextRoom();
        Debug.Log("Next room: " + next);
        GameObject nextRoom = levelc.levels[next];
 //       Debug.Log("Actual next room is: " + nextRoom.name);
        Vector3 nextSpawn = nextRoom.transform.Find("Spawn").transform.position;
        float extradistance = next * levelc.distancebetweenlevels;
        nextSpawn.x += extradistance;
        Debug.Log("Next spawn: " + nextSpawn);
        nextSpawn.z = player.transform.position.z;
        player.transform.position = nextSpawn;
        Vector3 camSpawn = levelc.levels[next].transform.position;
        camSpawn.x +=extradistance;
        camSpawn.z = -10.0f;
        mainCam.transform.position = camSpawn;
        RoomInfo roominfo = nextRoom.GetComponent<RoomInfo>();
        mainCam.orthographicSize = roominfo.CamSize;
        roominfo.roomNo = next;
        levelc.visitedLevels.Add(levelc.levels[next]);
        levelc.levels.Remove(levelc.levels[next]);
        player.GetComponent<PlayerController>().EnterTrigger = false;
        }

    }

}
