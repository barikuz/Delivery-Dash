using UnityEngine;
using TMPro;

public class Delivery : MonoBehaviour
{
    bool hasGarbage;
    ParticleSystem particleSystem;

    [SerializeField] int garbageCount = 30;

    [SerializeField] TMP_Text leftGarbageText;

    [SerializeField] GameEnd gameEnd;
    
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        leftGarbageText.text = "Garbages: " + garbageCount;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Garbage") && !hasGarbage)
       {
            hasGarbage = true;
            particleSystem.Play();
            Destroy(collision.gameObject);
       }

        if (collision.CompareTag("Trash Bin") && hasGarbage)
        {
            hasGarbage = false;
            particleSystem.Stop();

            garbageCount--;
            leftGarbageText.text = "Garbage: " + garbageCount;
            
            if(garbageCount == 0)
            {
               gameEnd.endGame("You Win!");
            }
        }
    }
    
}
