using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public List<GameObject> levels;
    public List<GameObject> visitedLevels;

    Component[] children;

    FurthestPoint fp;
    int firstnum = 0;
    int secondnum = 1;

    int[] randnums;

    public float distancebetweenlevels = 200.0f;

    void Start() {

        int first = Random.Range(0, 4);        
        
    //    string firstpart = "part" + firstnum.ToString();
        float totalx = 0.0f;;
      //  float furthestpoint = 0.0f;
       // float halfpoint = 0.0f;
       // float furthestpoint2 = 0.0f;

        Instantiate(levels[0], new Vector3(totalx, 0.0f, 0.0f), Quaternion.identity);
        totalx += distancebetweenlevels;
        Instantiate(levels[1], new Vector3(totalx , 0.0f, 0.0f), Quaternion.identity);
        totalx += distancebetweenlevels;
        Instantiate(levels[2], new Vector3(totalx, 0.0f, 0.0f), Quaternion.identity);
        totalx += distancebetweenlevels;
        Instantiate(levels[3], new Vector3(totalx , 0.0f, 0.0f), Quaternion.identity);
        totalx += distancebetweenlevels;
        Instantiate(levels[4], new Vector3(totalx , 0.0f, 0.0f), Quaternion.identity);
        Debug.Log("Spawned last level at: " + totalx);
        totalx += distancebetweenlevels;
    

    }

    public int getNextRoom()
    {
        int next = Random.Range(0, levels.Count - 1);
        return next;
    }

}
