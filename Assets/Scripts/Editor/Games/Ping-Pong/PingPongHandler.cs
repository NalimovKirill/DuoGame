using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PingPongHandler : MonoBehaviour
{
    [Header("Red Player")]
    [SerializeField] private Transform _redPlayer;
    [SerializeField] private GameObject _redPlayerGoal;

    [Header("Blue Player")]
    [SerializeField] private Transform _bluePlayer;
    [SerializeField] private GameObject _bluePlayerGoal;

    [Header("Ball")]
    [SerializeField] private GameObject _ball;

    [Header("ScoreUI")]
    [SerializeField] private TMP_Text _redPlayerScoreText;
    [SerializeField] private TMP_Text _bluePlayerScoreText;

    private int _redPlayerScore;
    private int _bluePlayerScore;

    private bool _red;
    private bool _blue;
    void Start()
    {
        
    }
    void Update()
    {
        MovePlayers();
    }
    private void MovePlayers()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider.CompareTag("RedZone"))
            {
                _red = true;
                _blue = false;

            }
            else if (hit.collider.CompareTag("BlueZone"))
            {
                _red = false;
                _blue = true;
            }
        }
        if (Input.GetMouseButton(0) && _red == true)
        {
            if (_redPlayer.transform.position.y < 2.6f)
            {
                _redPlayer.Translate(Vector2.up * 6 * Time.deltaTime);
            }
        }
        else if (_redPlayer.transform.position.y >= -3f)
        {
            _redPlayer.transform.Translate(Vector2.down * 5 * Time.deltaTime);
        }

        if (Input.GetMouseButton(0) && _blue == true)
        {
            if (_bluePlayer.transform.position.y < 2.6f)
            {
                _bluePlayer.Translate(Vector2.up * 6 * Time.deltaTime);
            }
        }
        else if (_bluePlayer.transform.position.y >= -3f)
        {
            _bluePlayer.transform.Translate(Vector2.down * 5 * Time.deltaTime);
        }
    }

    public void OnMainMenuButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void RedPlayerScored()
    {
        _redPlayerScore++;
        _redPlayerScoreText.text = _redPlayerScore.ToString();
        ResetPosition();
    }
    public void BluePlayerScored()
    {
        _bluePlayerScore++;
        _bluePlayerScoreText.text = _bluePlayerScore.ToString();
        ResetPosition();
    }

    private void ResetPosition()
    {
        _ball.GetComponent<BallMover>().Reset();
        _redPlayer.GetComponent<Paddle>().Reset();
        _bluePlayer.GetComponent<Paddle>().Reset();

    }
}
