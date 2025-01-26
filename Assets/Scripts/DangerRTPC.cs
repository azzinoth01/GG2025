using UnityEngine;

public class DangerRTPC : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    enemy = GameObject.Find("Chaser");

    //}

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, enemy.transform.position);
        AkSoundEngine.SetRTPCValue("DangerDistance", distance);

    }
}
