using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    public InputField _inputPlayerName;
    public Button _strBtn;
    public Button _choBtn;
    public GameObject _firBtn;
    public GameObject _SecBtn;
    public GameObject _thiBtn;
    public Image _image;

    private string _playerName = null;

    private void Awake()
    {
        _image = _choBtn.GetComponent<Image>();

        Button _firstBtn = _firBtn.transform.GetComponent<Button>();
        Button _secondBtn = _SecBtn.transform.GetComponent<Button>();
        Button _thridBtn = _thiBtn.transform.GetComponent<Button>();

        _strBtn.onClick.AddListener(() => InputNameBtn());
        _choBtn.onClick.AddListener(() => ChoiceWindow());
        _firstBtn.onClick.AddListener(() => PlayerChoice(0));
        _secondBtn.onClick.AddListener(() => PlayerChoice(1));
        _thridBtn.onClick.AddListener(() => PlayerChoice(2));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) //Enter키를 눌러도 바로 작동가능하게 
        {
            InputNameBtn();
        }
    }

    public void ChoiceWindow()
    {
        _choBtn.transform.GetChild(0).GameObject().SetActive(true);
    }

    public void PlayerChoice(int index)
    {
        PlayerPrefs.SetInt("playerChoice", index);
        switch (index) 
        {
            case 0:
                _image.sprite = _firBtn.transform.GetChild(0).GetComponent<Image>().sprite;
                _choBtn.transform.GetChild(0).GameObject().SetActive(false);
                break; 
            case 1:
                _image.sprite = _SecBtn.transform.GetChild(0).GetComponent<Image>().sprite;
                _choBtn.transform.GetChild(0).GameObject().SetActive(false);
                break;
            default:
                _image.sprite = _thiBtn.transform.GetChild(0).GetComponent<Image>().sprite;
                _choBtn.transform.GetChild(0).GameObject().SetActive(false);
                break;
        }
    }

    public void InputNameBtn()
    {
        _playerName = _inputPlayerName.text; //입력한 값 받아주기

        //이름의 크기가 지정한 값보다 크면 재입력
        if (_playerName.Length <= 10 && _playerName.Length >= 2)
        {
            PlayerPrefs.SetString("PlayerName", _playerName);
            SceneManager.LoadScene("MainScene"); //신 불러오기
        }
        else 
        {
            _inputPlayerName.text = null;
        }
    }
}
