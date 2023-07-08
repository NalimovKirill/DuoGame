using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredBlock : MonoBehaviour
{
    private SpriteRenderer _sprite;
    void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RedPlayer")
        {
            _sprite.color = Color.red;

        }
    }
}
