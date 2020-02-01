using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public List<GameObject> levels;

    Component[] children;

    FurthestPoint fp;
    int firstnum = 0;
    int secondnum = 1;

    float distancebetweenlevels = 200.0f;

    void Start() {
        
    //    string firstpart = "part" + firstnum.ToString();
        float totalx = 0.0f;;
      //  float furthestpoint = 0.0f;
       // float halfpoint = 0.0f;
       // float furthestpoint2 = 0.0f;

        Instantiate(levels[firstnum], new Vector3(totalx, 0.0f, 0.0f), Quaternion.identity);
        totalx += distancebetweenlevels;
        Instantiate(levels[secondnum], new Vector3(totalx , 0.0f, 0.0f), Quaternion.identity);
        totalx += distancebetweenlevels;
    

    }

}
