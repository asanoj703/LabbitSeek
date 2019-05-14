using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Transform sprite;
    float delta_x;

    void Awake()
    {
        sprite = GetComponent<Transform>();
    }

    private void Start()
    {
        delta_x = -0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        ScrollBG();
    }

    void ScrollBG()
    {
        sprite.position = new Vector3(sprite.position.x + delta_x, sprite.position.y, sprite.position.z);
    }
}
