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
        if (Input.GetKeyDown(KeyCode.Return)) //EnterŰ�� ������ �ٷ� �۵������ϰ� 
        {
            InputNameBtn();
        }
    }

    public void InputNameBtn()
    {
        _playerName = _inputPlayerName.text; //�Է��� �� �޾��ֱ�

        //�̸��� ũ�Ⱑ ������ ������ ũ�� ���Է�
        if (_playerName.Length <= 10 && _playerName.Length >= 2)
        {
            PlayerPrefs.SetString("PlayerName", _playerName);
            SceneManager.LoadScene("MainScene"); //�� �ҷ�����
        }
        else 
        {
            _inputPlayerName.text = null;
        }
    }
}
