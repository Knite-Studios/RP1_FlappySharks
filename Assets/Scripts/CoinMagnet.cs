using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMagnet : MonoBehaviour
{
    public List<GameObject> coins = new List<GameObject>();
    public float magnetForce;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var coin in GameojObect.FindGameObjectsWithTag("Coins"))
        {
            coins.Add(coin);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var coin in coins)
        {
            float.distance = Vector2.Distance(transform.position, coin.transform.position);

            if(distance < magnetForce)
            {
                coin.transform.position = Vector2.Lerp(coin.transform.position, transform.position, speed);
            }
        }
    }
}
