using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrawingTest : MonoBehaviour
{
    private float _speed = 5;
    private Rigidbody2D _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = Input.GetAxisRaw("Horizontal"); // d key changes value to 1, a key changes value to -1
        float yMove = Input.GetAxisRaw("Vertical"); // w key changes value to 1, s key changes value to -1

        _rigidbody.velocity = new Vector2(xMove, yMove) * _speed;
    }

    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
