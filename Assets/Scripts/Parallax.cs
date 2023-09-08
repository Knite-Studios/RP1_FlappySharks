using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer background;
    // Start is called before the first frame update
    [SerializeField]
    private float animationSpeed = 1f;
    private void Awake()
    {
        background = GetComponent<MeshRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        background.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0); 
    }
}
