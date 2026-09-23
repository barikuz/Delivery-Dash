using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasGarbage;
    [SerializeField] float delay;

    ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Garbage") && !hasGarbage)
       {
        Debug.Log("We collected garbage");
        hasGarbage = true;
        particleSystem.Play();
        Destroy(collision.gameObject, delay);
        
       }

        if (collision.CompareTag("Trash Bin") && hasGarbage)
        {
            Debug.Log("We delivered garbage");
            hasGarbage = false;
            particleSystem.Stop();
        }
    }
}
