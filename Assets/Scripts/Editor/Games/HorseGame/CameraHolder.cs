using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraHolder : MonoBehaviour
{
    public UnityEvent OnRedHorseTouch = new UnityEvent();
    public UnityEvent OnBlueHorseTouch = new UnityEvent();
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("RedHorse"))
        {
            OnRedHorseTouch?.Invoke();
        }
        else if (collision.CompareTag("BlueHorse"))
        {
            OnBlueHorseTouch?.Invoke();
        }
        
    }
}
