using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    [SerializeField] float backgroundScrollSpeed = 0.2f;
    Material material;
    Vector2 offsetVector;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        offsetVector = new Vector2(0f, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += offsetVector * Time.deltaTime;
    }
}
