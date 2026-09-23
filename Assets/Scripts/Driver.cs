using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Driver : MonoBehaviour
{
    [SerializeField] float currentSpeed = 10f;
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float regularSpeed = 10f;

    [SerializeField] TMP_Text boostText;
    bool hasBoost = false;

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
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        currentSpeed = regularSpeed;
        hasBoost = false;
        boostText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float move = 0f;
        float steer = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            move = -1f;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }

        float moveAmount = move * currentSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;
        
        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, steerAmount);
    }
}
