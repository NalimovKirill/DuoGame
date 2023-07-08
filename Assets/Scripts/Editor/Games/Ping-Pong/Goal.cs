using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private bool _isRedPlayerGoal;
    [SerializeField] private PingPongHandler _pingPongHandler;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (!_isRedPlayerGoal)
            {
                _pingPongHandler.BluePlayerScored();
            }
            else
            {
                _pingPongHandler.RedPlayerScored();
            }
        }
        
    }
}
