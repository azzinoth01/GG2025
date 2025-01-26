using UnityEngine;

public class AltitudeRTPC : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AkSoundEngine.SetRTPCValue("Altitude",transform.position.y);
        
    }
}
