using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GamePreviewHolder : MonoBehaviour
{
    public ClickOnPreviewGameEvent ClickOnPreviewGameEvent = new ClickOnPreviewGameEvent();


    [SerializeField] private GameInfoData _gameInfo;

    private Image _iconOfGame;
    public Image IconOfGame { get { return _iconOfGame; } }

    private TMP_Text _tittleOfGame;
    public TMP_Text TittleOfGame { get { return _tittleOfGame; } }
    
    private string _descriptionOfGame;
    public string DescriptionOfGame { get { return _descriptionOfGame; } }

    private void Start()
    {
        _iconOfGame = GetComponent<Image>();
        _iconOfGame.sprite = _gameInfo.ImageOfGame;

        _tittleOfGame = GetComponentInChildren<TMP_Text>();
        _tittleOfGame.text = _gameInfo.TittleOfGame;

        _descriptionOfGame = _gameInfo.DescriptionOfGame;

    }
    public void OnMouseDown()
    {
       ClickOnPreviewGameEvent?.Invoke(_iconOfGame, _tittleOfGame.text, _descriptionOfGame);
    }
}

public class ClickOnPreviewGameEvent : UnityEvent<Image,string, string> { }
