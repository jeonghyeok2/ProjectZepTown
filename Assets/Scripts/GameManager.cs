using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerName; // �÷��̾��� �̸� ���
    [SerializeField] private TextMeshProUGUI _changeName; // �÷��̾��� �̸� ���� Text
    [SerializeField] private TextMeshProUGUI _nowTime;
    public static GameManager Instance; //���� �Ŵ���
    
    public GameObject _changeNameWindow; //�̸� ���� â ��ư 
    public GameObject _nameList; //������ â ��ư
    public GameObject _playerChangeWindow; //ĳ���� ���� â ��ư
    public Button _nameChangeBtn; //�÷��̾� �̸� ���� Ȯ�� ��ư
    public Button _firBtn;
    public Button _SecBtn;
    public Button _thiBtn;

    private void Awake()
    {
        if (Instance == null)
        {
             Instance = this;
        }
        Button _nameListBtn = _nameList.GetComponent<Button>(); //��ư �������ֱ�
        Button _nameChangeWindowBtn = _changeNameWindow.GetComponent<Button>(); //��ư �������ֱ�
        Button _playerChangeWindowBtn = _playerChangeWindow.GetComponent<Button>(); //��ư �������ֱ�

        _nameChangeBtn.onClick.AddListener(() => NameChange());
        _nameChangeWindowBtn.onClick.AddListener(() => NameChangeWindowOpen());
        _nameListBtn.onClick.AddListener(() => NameListWindowOpen());
        _playerChangeWindowBtn.onClick.AddListener(() => _playerChangeWindowOpen());
        _firBtn.onClick.AddListener(() => PlayerChange(0));
        _SecBtn.onClick.AddListener(() => PlayerChange(1));
        _thiBtn.onClick.AddListener(() => PlayerChange(2));
    }
    private void Start()
    {
        _playerName.text = PlayerPrefs.GetString("PlayerName"); //�÷��̾��� �̸� ����
    }
    private void Update()
    {
        _nowTime.text = DateTime.Now.ToString("HH�� mm��");
    }
    private void _playerChangeWindowOpen()
    {
        Time.timeScale = 0; //���� �ð� ����
        _playerChangeWindow.transform.GetChild(1).gameObject.SetActive(true);
    }//�÷��̾� ���� â 
    private void NameListWindowOpen() //������ â �߰��ϱ�
    {
        _nameList.transform.GetChild(1).gameObject.SetActive(true);
    }
    private void NameChangeWindowOpen() //���� �÷��̾� �̸� â �߰��ϱ�
    {
        Time.timeScale = 0; //���� �ð� ����
        _changeNameWindow.transform.GetChild(1).gameObject.SetActive(true);
    }
    private void NameChange() //���� �÷��̾� �̸� �����ϱ�
    {
        if (_changeName.text.Length <= 10 && _changeName.text.Length >= 2)
        {
            Time.timeScale = 1; //���� �ð� �۵�
            PlayerPrefs.SetString("PlayerName", _changeName.text);
            _playerName.text = PlayerPrefs.GetString("PlayerName");
            _changeNameWindow.transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            _changeName.text = null;
        }
    }
    private void PlayerChange(int index)
    {
        PlayerPrefs.SetInt("playerChoice", index);
        Time.timeScale = 1; //���� �ð� �۵�
        switch (index)
        {
            case 0:
                _playerChangeWindow.transform.GetChild(1).GameObject().SetActive(false);
                break;
            case 1:
                _playerChangeWindow.transform.GetChild(1).GameObject().SetActive(false);
                break;
            default:
                _playerChangeWindow.transform.GetChild(1).GameObject().SetActive(false);
                break;
        }
    }
}
