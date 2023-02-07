using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;

    private float minSpeed = 10;
    private float maxSpeed = 14;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;

    public int pointValue;


    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // Sets the targets position to a random position.
        targetRb.position =  RandomSpawnPos();

        // Adds a random force to the targets on y axiss.
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        // Adds a random torque to the targets to rotate.
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

    }

    // Returns a random coordinate
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    // Returns a random force on y axis
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    // Returns a random torque
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    // When the fruits are clicked with mouse this method works
    private void OnMouseDown() 
    {
        // Makes sure that game is on before we clicked on the fruits
        if(gameManager.isGameActive)
        {   
            // Destroys the fruits when clicked on them
            Destroy(gameObject);

            // Creates an particle effect for the clicked fruits
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

            // Updates the score
            gameManager.UpdateScore(pointValue);
        }
        
    }

    // Checks that fruits are touched to the sensor
    private void OnTriggerEnter(Collider other) 
    {
        // Destroys the fruits touched to the sensor
        Destroy(gameObject);

        // Checks that if the fruit touched to the sensor or the bomb
        if(!gameObject.CompareTag("Bad"))
        {
            // When a fruit touched to the sensor it will be destroyed
            gameManager.GameOver();
        }
    }
}
