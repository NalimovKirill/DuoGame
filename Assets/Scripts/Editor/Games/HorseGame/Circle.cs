using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Circle : MonoBehaviour
{
    public OnWinGameEvent OnWinGamePanel = new OnWinGameEvent();
    [SerializeField] private TypeOfPlayer _typeOfPlayer;

    private string _nameOfPlayer;
    private void Start()
    {
        if (_typeOfPlayer == TypeOfPlayer.Red)
        {
            _nameOfPlayer = "�������";
        }
        else
        {
            _nameOfPlayer = "�����";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Finish>() != null)
        {
            OnWinGamePanel?.Invoke(_typeOfPlayer);
            Debug.Log("������� " + _nameOfPlayer);
        }
    }
}
public class OnWinGameEvent : UnityEvent<TypeOfPlayer> { }
