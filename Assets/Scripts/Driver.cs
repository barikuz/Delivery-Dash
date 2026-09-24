using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Driver : MonoBehaviour
{
    [SerializeField] float currentSpeed = 10f;
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float regularSpeed = 10f;
    [SerializeField] float fuel = 100f;
    [SerializeField] float fuelConsumptionRate = 2f;

    [SerializeField] TMP_Text boostText;
    [SerializeField] TMP_Text fuelText;

    [SerializeField] GameEnd gameEnd;

    bool hasBoost = false;
    bool isRefueling = false;
    bool isFuelConsuming = false;

    void decreaseFuel(float amount)
    {
        fuel -= Time.deltaTime * amount;
        fuelText.text = "Fuel: " + fuel.ToString("0");
        if (fuel <= 0f)
        {
            fuelText.text = "Ran out of fuel!";
            gameEnd.isGameOver = true;
            gameEnd.endGame("Game OVER!");
        }
        

    }

    void Start()
    {
        boostText.gameObject.SetActive(false);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Boost") && !hasBoost)
        {
            currentSpeed = boostSpeed;
            hasBoost = true;
            boostText.gameObject.SetActive(true);
            Destroy(collision.gameObject);

            isFuelConsuming = true;
        }

        if(collision.CompareTag("Gas Station"))
        {
            isRefueling = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Gas Station"))
        {
            isRefueling = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        currentSpeed = regularSpeed;
        hasBoost = false;
        boostText.gameObject.SetActive(false);

        isFuelConsuming = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameEnd.isGameOver)
        {
            return;
        }

        if (isRefueling)
        {
            if (fuel < 100f)
            {
                fuel += Time.deltaTime * 5f; // Refuel at a rate of 5 units per second
                fuelText.text = "Fuel: " + fuel.ToString("0");
            }
        }

        if (isFuelConsuming)
        {
            decreaseFuel(fuelConsumptionRate); // Consume fuel at a rate of 2 units per second
        }

        float move = 0f;
        float steer = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
            decreaseFuel(1f);
        }
        if (Keyboard.current.sKey.isPressed)
        {
            move = -1f;
            decreaseFuel(1f);
        }
        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
            decreaseFuel(1f);
        }
        if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
            decreaseFuel(1f);
        }

        float moveAmount = move * currentSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;
        
        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, steerAmount);
    }
}
