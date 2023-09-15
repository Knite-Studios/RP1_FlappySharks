using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown : Collectables
{
    [SerializeField]
    private Obstacles obstacles;
    [SerializeField]
    private float speedDrop = 2f;
    [SerializeField]
    private float dropDuration = 5f;
    [SerializeField]
    /* private TextMeshProUGUI dropText;*/
    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.gameObject.CompareTag("player"))
        {

        }
    }

    private void speedDown()
    {
        obstacles.DropSpeed(speedDrop, dropDuration);
    }

    /*private void DisplayDropMessage()
    {
        boostText.text = "DroppedSpeed : <color=orange>Active</color>";
        boostText.gameObject.SetActive(true);

        Invoke("HideDropMessage", dropDuration);
    }

    private void HideDropMessage()
    {
        dropText.gameObject.SetActive(false);
    }*/
}
