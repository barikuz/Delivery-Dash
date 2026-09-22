using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasGarbage;

    void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Garbage"))
       {
            Debug.Log("We collected garbage");
            hasGarbage = true;
       }

        if (collision.CompareTag("Bin") && hasGarbage)
        {
            Debug.Log("We triggered bin");
            hasGarbage = false;
        }
    }
}
