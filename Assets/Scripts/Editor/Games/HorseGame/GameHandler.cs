using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private Transform _cameraMover;
    private CameraHolder _cameraHolder;
    private float _speedCamera = 0;

    [Header("Red Player")]
    [SerializeField] private Transform _redHorse;
    private float _redHorseSpeed = 0;
    [SerializeField] private Transform _redCircle;

    [Header ("Blue Player")]
    [SerializeField] private Transform _blueHorse;
    private float _blueHorseSpeed = 0;
    [SerializeField] private Transform _blueCircle;

    [Header("Win Panel")]
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private TMP_Text _winnerText;
    private bool isRedReachedCamera = false;
    private bool isBlueReachedCamera = false;

    private string _nameWinner;
    void Start()
    {
        _cameraHolder = _cameraMover.GetComponent<CameraHolder>();
        _cameraHolder.OnBlueHorseTouch.AddListener(BlueHorseRichCamera);
        _cameraHolder.OnRedHorseTouch.AddListener(RedHorseRichCamera);

        _redCircle.GetComponent<Circle>().OnWinGamePanel.AddListener(OpenWinPanel);
        _blueCircle.GetComponent<Circle>().OnWinGamePanel.AddListener(OpenWinPanel);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            RedPlayerClicked();
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            BluePlayerClicked();
        }
        _redHorse.transform.Translate(Vector2.up * _redHorseSpeed * Time.deltaTime);
        _redCircle.transform.Translate(Vector2.right * _redHorseSpeed * 0.1f * Time.deltaTime);

        _blueHorse.transform.Translate(Vector2.up * _blueHorseSpeed * Time.deltaTime);
        _blueCircle.transform.Translate(Vector2.right * _blueHorseSpeed * 0.1f * Time.deltaTime);

        _cameraMover.transform.Translate(Vector2.up * _speedCamera * Time.deltaTime);
    }

    public void RedPlayerClicked()
    {
        _redHorseSpeed += 1;
        if (_speedCamera >= _redHorseSpeed)
        {
            isRedReachedCamera = false;
        }
        if (isRedReachedCamera == true && _speedCamera < _redHorseSpeed)
        {
            _speedCamera = _redHorseSpeed;
        }
    }
    public void BluePlayerClicked()
    {
        _blueHorseSpeed += 1;
        if (_speedCamera >= _blueHorseSpeed)
        {
            isBlueReachedCamera = false;
        }
        if (isBlueReachedCamera == true && _speedCamera < _blueHorseSpeed)
        {
            _speedCamera = _blueHorseSpeed;
        }
    }

    private void RedHorseRichCamera()
    {
        _speedCamera = _redHorseSpeed;
        isRedReachedCamera = true;
    }
    private void BlueHorseRichCamera()
    {
        _speedCamera = _blueHorseSpeed;
        isBlueReachedCamera = true;
    }

    private void OpenWinPanel(TypeOfPlayer typeOfPlayer)
    {
        _winPanel.SetActive(true);
        _blueHorseSpeed = 0;
        _redHorseSpeed = 0;

        if (typeOfPlayer == TypeOfPlayer.Red)
        {
            _nameWinner = "Красный";
            _winPanel.GetComponent<Image>().color = Color.red;
        }
        else
        {
            _nameWinner = "Синий";
            _winPanel.GetComponent<Image>().color = Color.blue;
        }

        _winnerText.text = "Победил " + _nameWinner;

        Invoke("OnMainMenuButtonClick", 3);
    }

    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
public enum TypeOfPlayer { Red, Blue };
