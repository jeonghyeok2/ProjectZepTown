using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NameInput : MonoBehaviour
{
    public InputField _inputPlayerName;
    public GameObject _strBtn;

    private string _playerName = null;

    private void Awake()
    {
        Button startBtn = _strBtn.transform.GetComponent<Button>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) //Enter키를 눌러도 바로 작동가능하게 
        {
            InputNameBtn();
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
