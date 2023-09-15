using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float deadZone = -15;

    public float Speed
    {
        get { return speed; }
    }
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
    public void BoostSpeed(float Boost, float Duration)
    {
        speed += Boost;

        Invoke("ResetSpeed", Duration);
    }

    public void DropSpeed(float Drop, float Duration)
    {
        speed -= Drop;

        Invoke("ResetSpeed", Duration);
    }
}
