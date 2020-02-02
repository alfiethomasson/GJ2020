using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelCreator : MonoBehaviour
{
    public List<GameObject> levels;

    public int noLevels;

    public List<GameObject> visitedLevels;

    Component[] children;

    FurthestPoint fp;
    int firstnum = 0;
    int secondnum = 1;

    int[] randnums;

    public float distancebetweenlevels = 200.0f;

    void Start() {
        
        DirectoryInfo dir = new DirectoryInfo("Assets/Resources/Levels");
        FileInfo[] info = dir.GetFiles("*.prefab");
        int prefabSize = info.Length;
       

        for(int i = 0; i < noLevels - 1; i++)
        {         

            int rand = Random.Range(0, prefabSize - 1);
            GameObject newLevel = Resources.Load<GameObject>("Levels/Level" + rand.ToString());
            levels.Add(newLevel);
        }

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
