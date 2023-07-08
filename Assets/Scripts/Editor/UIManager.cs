using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPopup;
    [SerializeField] private GameObject _aboutGamePopup;

    [SerializeField] private GamePreviewHolder[] _games;

    [Header ("About Game Popup")]
    [SerializeField] private TMP_Text _tittleOfGame; 
    [SerializeField] private Image _iconOfGame;
    [SerializeField] private TMP_Text _descriptionOfGame;

    private int _indexOfNextScene;

    private void Start()
    {
        foreach (GamePreviewHolder game in _games) 
        {
            game.ClickOnPreviewGameEvent.AddListener(OpenAndFillAboutGamePopup);
        
        }
    }
    public void OnMainMenuButtonClick()
    {
        _mainMenuPopup.SetActive(true);
    }
    public void OpenAndFillAboutGamePopup(Image imageOfGame, string tittleOfGame, string discriptionOfGame)
    {
        _tittleOfGame.text = tittleOfGame;
        _iconOfGame.sprite = imageOfGame.sprite;
        _descriptionOfGame.text = discriptionOfGame;

        _mainMenuPopup.SetActive(false);
        _aboutGamePopup.SetActive(true);

        
        switch (tittleOfGame)
        {
            case "Скачки":
                _indexOfNextScene = 1;
                break;
            case "Пинг-Понг":
                _indexOfNextScene = 2;
                break;
            case "Рисование":
                _indexOfNextScene = 3;
                break;
        }
    }

    public void OnPvPButtonClick()
    {
        SceneManager.LoadScene(_indexOfNextScene);
    }
}
