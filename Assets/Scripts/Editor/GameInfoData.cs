using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "GamePreviewImage", menuName = "ScriptableObjects/SpawnGamePreview", order = 1)]
public class GameInfoData : ScriptableObject
{
    private enum TypeOfGame { Horse, PingPong, Drawing }
    [SerializeField] private TypeOfGame _typeOfGame;
    public string TittleOfNextScene { get { return _typeOfGame.ToString(); } }

    [SerializeField] private string _tittleOfGame;
    public string TittleOfGame { get { return _tittleOfGame; } }

    [SerializeField] private string _descriptionOfGame;
    public string DescriptionOfGame { get { return _descriptionOfGame; } }

    [SerializeField] private Sprite _imageOfGame;
    public Sprite ImageOfGame { get { return _imageOfGame; } }

}
