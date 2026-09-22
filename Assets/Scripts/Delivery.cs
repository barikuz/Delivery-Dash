using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasGarbage;

    [SerializeField] float delay;

    void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Garbage") && !hasGarbage)
       {
        Debug.Log("We collected garbage");
        hasGarbage = true;
        Destroy(collision.gameObject, delay);
        
       }

        if (collision.CompareTag("Trash Bin") && hasGarbage)
        {
            Debug.Log("We delivered garbage");
            hasGarbage = false;
        }
    }
}
