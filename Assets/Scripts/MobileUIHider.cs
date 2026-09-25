using UnityEngine;

public class MobileUIHider : MonoBehaviour
{
    void Awake()
    {
        #if UNITY_ANDROID
            gameObject.SetActive(true);
            
        #else
            gameObject.SetActive(false);
        #endif
    }
}
