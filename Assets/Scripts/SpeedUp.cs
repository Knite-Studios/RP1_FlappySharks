using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedUp : Collectables 
{ 
    [SerializeField]
    private Obstacles obstacles;
    [SerializeField]
    private float speedBoost = 5f;
    [SerializeField]
    private float boostDuration = 5f;
    [SerializeField]
   /* private TextMeshProUGUI boostText;*/
    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.gameObject.CompareTag("player"))
        {

        }
    }

    private void speedUp()
    {
        obstacles.BoostSpeed(speedBoost, boostDuration);
    }

    /*private void DisplayBoostMessage()
    {
        boostText.text = "Boost : <color=orange>Active</color>";
        boostText.gameObject.SetActive(true);

        Invoke("HideBoostMessage", boostDuration);
    }

    private void HideBoostMessage()
    {
        boostText.gameObject.SetActive(false);
    }*/
}