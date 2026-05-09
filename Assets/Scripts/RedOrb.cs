using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedOrb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (PlayerController.multiplier)
            {
                PlayerController.score += 5;
            }
            else 
            {
                PlayerController.score += 1;
            }
            FindObjectOfType<AudioManager>().PlaySound("Collecting Orb");
            Destroy(gameObject);

        }
    }
}
