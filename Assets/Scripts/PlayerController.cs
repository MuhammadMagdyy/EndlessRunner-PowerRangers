
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{


    public static AudioSource MainTheme;
    Renderer playerRenderer;

    // movements
    private CharacterController controller;
    private Vector3 dir;
    public float forwardSpeed;
    private int desiredLane = 1;
    public float laneDistance = 4;

    // default color
    public Material defaultMaterial;

    // score board
    public static int score;
    public Text scoreText;


    // for blue power-up
    public Text greenPoints;
    private bool isBlueForm = false;
    public Material blueMaterial;
    public Material blueShieldMaterial;
    public int blueEnergyPoints = 0;
    private bool isShieldActive = false;
    private int shieldHitsRemaining = 1;

    // for red power-up
    public Text redPoints;
    private bool isRedForm = false;
    public Material redMaterial;
    public int redEnergyPoints = 0;
    private bool isEliminated = false;



    // for green power-up
    public Text bluePoints;
    private bool isGreenForm = false;
    public Material greenMaterial;
    public int greenEnergyPoints = 0;
    public static bool multiplier;




    

    /* public static bool gameOver;
     public GameObject gameOverPanel;
     */


    void Start()
    {
      
        multiplier = false;
        controller = GetComponent<CharacterController>();
         playerRenderer = GetComponent<Renderer>();
        Time.timeScale = 1;
        score = 0;

        
    }


    void Update()
    {
        /* if (gameOver)
         {
             Time.timeScale = 0;
             gameOverPanel.SetActive(true);
         }*/


        // red
        if (!isRedForm && Input.GetKeyDown(KeyCode.J) && redEnergyPoints == 5)
        {

            if (isBlueForm)
            {
                isBlueForm = false;

            }
            if (isGreenForm)
            {
                isGreenForm = false;
            }
            FindObjectOfType<AudioManager>().PlaySound("Switch 1");
            ActivateRedPower();
            Debug.Log("RedPowerUp is activated");

        }
        else
        {
            {
                if (Input.GetKeyDown(KeyCode.J))
                    FindObjectOfType<AudioManager>().PlaySound("error");
            }

        }
        if (isRedForm && Input.GetKeyDown(KeyCode.Space) && !isEliminated && redEnergyPoints != 0)
        {
            redEnergyPoints--;
            FindObjectOfType<AudioManager>().PlaySound("Red");
            isEliminated = true;
            ActivateRedNuke();
            Debug.Log("RedPowerUp Nuke is activated");


        }
        else {
            if (Input.GetKeyDown(KeyCode.Space))
                FindObjectOfType<AudioManager>().PlaySound("error");
        }



        // green
        if (!isGreenForm && Input.GetKeyDown(KeyCode.K) && greenEnergyPoints == 5)
        {
            if (isBlueForm)
            {
                isBlueForm = false;

            }
            if (isRedForm)
            {
                isRedForm = false;
            }
            FindObjectOfType<AudioManager>().PlaySound("Switch 2");
            ActivateGreenPower();
            Debug.Log("GreenPowerUp is activated");
        }
        else {
            if (Input.GetKeyDown(KeyCode.K))
                FindObjectOfType<AudioManager>().PlaySound("error");
        }

        if (isGreenForm && Input.GetKeyDown(KeyCode.Space) && !multiplier && greenEnergyPoints != 0)
        {
            greenEnergyPoints--;
            FindObjectOfType<AudioManager>().PlaySound("Green");
            multiplier = true;
            Debug.Log("GreenPowerUp Multiplier is activated");
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
                FindObjectOfType<AudioManager>().PlaySound("error");
        }


        // blue
        if (!isBlueForm && Input.GetKeyDown(KeyCode.L) && blueEnergyPoints == 5)
        {
            if (isRedForm)
            {
                isRedForm = false;

            }
            if (isGreenForm)
            {
                isGreenForm = false;
            }
            FindObjectOfType<AudioManager>().PlaySound("Switch 3");
            ActivateBluePower();
            Debug.Log("BluePowerUp is activated");
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.L))
                FindObjectOfType<AudioManager>().PlaySound("error");
        }

        if (isBlueForm && Input.GetKeyDown(KeyCode.Space) && !isShieldActive && blueEnergyPoints != 0)
        {
            blueEnergyPoints--;
            FindObjectOfType<AudioManager>().PlaySound("Blue");
            ActivateBlueShield();
            Debug.Log("BluePowerUp shield is activated");
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space))
                FindObjectOfType<AudioManager>().PlaySound("error");

        }



        scoreText.text = "Score : " + score;
        redPoints.text = "Red : " + redEnergyPoints;
        greenPoints.text = "Green : " + greenEnergyPoints;
        bluePoints.text = "Blue : " + blueEnergyPoints;


        
        ///////////////////////////////////////////////
            //// Movement ////
         ///////////////////////////////////////////////
        dir.z = forwardSpeed;

        if (Input.GetKeyDown(KeyCode.D))
        {
            desiredLane++;
            if (desiredLane > 2)
            {
                desiredLane = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            desiredLane--;
            if (desiredLane < 0)
            {
                desiredLane = 0;
            }
        }

        float targetX = (desiredLane - 1) * laneDistance;
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            controller.Move(moveDir);
        }
        else
            controller.Move(diff);


    }

    void FixedUpdate()
    {

        controller.Move(dir * Time.fixedDeltaTime);

    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RedOrb"))
        {
            
            /*score += 1;
            Destroy(other);*/
            Debug.Log("Collision detected with RedOrb");

            if (redEnergyPoints < 5)
            {
                if(multiplier)
                {
                    redEnergyPoints+=2;
                    if (blueEnergyPoints > 5)
                    {
                        blueEnergyPoints = 5;
                    }
                    multiplier = false;

                }
                else
                {
                    redEnergyPoints++;
                }
                
                Debug.Log("Red Energy: " + redEnergyPoints);
            }
        }

        if (other.gameObject.CompareTag("GreenOrb"))
        {
         /* score += 1;
            Destroy(other);*/
            Debug.Log("Collision detected with GreenOrb");

            if (greenEnergyPoints < 5)
            {
                if (multiplier)
                {
                    multiplier = false;

                }
                else
                {
                    greenEnergyPoints++;
                }
                Debug.Log("Green Energy: " + greenEnergyPoints);
            }
        }

        if (other.gameObject.CompareTag("BlueOrb"))
        {
           /* score += 1;
            Destroy(other);*/
            Debug.Log("Collision detected with BlueOrb");


            if (blueEnergyPoints < 5)
            {
                if (multiplier)
                {
                    blueEnergyPoints += 2;
                    if(blueEnergyPoints >5)
                    {
                        blueEnergyPoints = 5;
                    }
                    multiplier= false;  
                }
                else
                {
                    blueEnergyPoints++;
                }
                Debug.Log("Blue Energy: " + blueEnergyPoints);
            }
        }

    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            if (isShieldActive)
            {
                Destroy(hit.gameObject);
                FindObjectOfType<AudioManager>().PlaySound("BlueShield");
                // Shield is active, decrement shieldHitsRemaining and deactivate shield if hits run out
                shieldHitsRemaining--;
                if (shieldHitsRemaining <= 0)
                {
                    
                    shieldHitsRemaining++;
                    DeactivateShield();
                }
            }
            else if(isBlueForm)
            {
                FindObjectOfType<AudioManager>().PlaySound("Hit");
                Destroy(hit.gameObject);
                isBlueForm = false;
          //      Renderer playerRenderer = GetComponent<Renderer>();
                playerRenderer.material = defaultMaterial;
                greenEnergyPoints--;

            }
            else if (isRedForm)
            {
                FindObjectOfType<AudioManager>().PlaySound("Hit");
                Destroy(hit.gameObject);
                isRedForm = false;
  //              Renderer playerRenderer = GetComponent<Renderer>();
                playerRenderer.material = defaultMaterial;
                greenEnergyPoints--;

            }
            else if(isGreenForm)
            {
                FindObjectOfType<AudioManager>().PlaySound("Hit");
                Destroy(hit.gameObject);    
                isGreenForm = false;
    //            Renderer playerRenderer = GetComponent<Renderer>();
                playerRenderer.material = defaultMaterial;
                greenEnergyPoints--;
            }
            else
            {

                FindObjectOfType<AudioManager>().PlaySound("Game Over");
                scoreText.text = "Score : " + score;
                PlayerManager.gameOver = true;
                Destroy(gameObject);
            }
        }
       
    }


    // blue
    private void ActivateBluePower()
    {
        Debug.Log("Changing to Blue Form...");
   //     Renderer playerRenderer = GetComponent<Renderer>();
        if (playerRenderer != null && blueMaterial != null)
        {
            playerRenderer.material = blueMaterial;
            isBlueForm = true;
/*            blueEnergyPoints--;
*/            Debug.Log("Changed to Blue Form");
            Debug.Log("Blue Energy: " + blueEnergyPoints);
        }
    }

    private void ActivateBlueShield()
    {
        Debug.Log("Activating Blue Shield...");
   //     Renderer playerRenderer = GetComponent<Renderer>();
        playerRenderer.material = blueShieldMaterial;
        isShieldActive = true;
        shieldHitsRemaining = 1;
        Debug.Log("Blue Shield Activated");
        Debug.Log("Blue Energy: " + blueEnergyPoints);
    }

    private void DeactivateShield()
    {
  //      Renderer playerRenderer = GetComponent<Renderer>();
        playerRenderer.material = blueMaterial;
        isShieldActive = false;
        Debug.Log("Blue Shield Deactivated");
    }


    // red
    private void ActivateRedPower()
    {
        Debug.Log("Changing to Red Form...");
 //       Renderer playerRenderer = GetComponent<Renderer>();
        if (playerRenderer != null && redMaterial != null)
        {
            playerRenderer.material = redMaterial;
            isRedForm = true;
            /*            blueEnergyPoints--;
            */
            Debug.Log("Changed to Red Form");
            Debug.Log("Red Energy: " + redEnergyPoints);
        }
    }

    private void ActivateRedNuke()
    {
        Debug.Log("Eliminating existing obstacles...");

        if (isEliminated)
        {
            GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
            foreach (GameObject cube in obstacles)
            {
                Destroy(cube);
            }

            Debug.Log("Obstacles eliminated.");
        }    
        

        // Continue obstacle generation.
        isEliminated = false;
        Debug.Log("Nuke is deactivated.");
    }



    // green
    private void ActivateGreenPower()
    {
        Debug.Log("Changing to Green Form...");
   //     Renderer playerRenderer = GetComponent<Renderer>();
        if (playerRenderer != null && greenMaterial != null)
        {
            playerRenderer.material = greenMaterial;
            isGreenForm = true;
           
            Debug.Log("Changed to Green Form");
            Debug.Log("Green Energy: " + greenEnergyPoints);
        }
    }

   

}






