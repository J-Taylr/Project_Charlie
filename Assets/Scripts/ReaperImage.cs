using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperImage : MonoBehaviour
{
    public GameObject eyePrefab;
    public GameObject faceMask;
    public int minEyes = 0;
    public int maxEyes = 3;
    

    public float eyeRadius = 2;
    private void OnEnable()
    {
        SpawnEyes();
    }

    void SpawnEyes()
    {
        int eyeSpawn = Random.Range(minEyes, maxEyes + 1);
        for (int i = 0; i < eyeSpawn; i++)
        {            
            GameObject newEye = Instantiate(eyePrefab, faceMask.transform) as GameObject;
            Vector2 randomPlacement = new Vector2(Random.Range(-eyeRadius, eyeRadius), Random.Range(-eyeRadius, eyeRadius));
            newEye.transform.position += (Vector3)randomPlacement;
            
        }
    }

    

}

