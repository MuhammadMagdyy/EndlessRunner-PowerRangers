using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    public float SpawnPosition = 0;
    public float gndLength = 25;
    public int numberOfGrounds = 5;

    public Transform playerTransform;

    private List<GameObject> activeGnds = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< numberOfGrounds; i++)
        {
            if(i==0)
            {
                SpawnGnd(0);
            }
            else
            {
                SpawnGnd(Random.Range(0, groundPrefabs.Length));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null && playerTransform.position.z - 25 > SpawnPosition - (numberOfGrounds * gndLength))
        {
            SpawnGnd(Random.Range(0, groundPrefabs.Length));
            DeleteGround();
        }
    }


    public void SpawnGnd(int groundIndex)
    {

        if (groundIndex < groundPrefabs.Length)
        {
            GameObject go = Instantiate(groundPrefabs[groundIndex], new Vector3(0, 0, SpawnPosition), transform.rotation);
            activeGnds.Add(go);
            SpawnPosition += gndLength;
        }
        else
        {
            Debug.LogError("Invalid groundIndex: " + groundIndex);
        }
    }
    private void DeleteGround()
    {
        Destroy(activeGnds[0]);
        activeGnds.RemoveAt(0);
    }
}
