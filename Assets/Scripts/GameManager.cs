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
    [SerializeField] private TextMeshProUGUI _playerName; // 플레이어의 이름 출력
    [SerializeField] private TextMeshProUGUI _changeName; // 플레이어의 이름 변경 Text
    [SerializeField] private TextMeshProUGUI _nowTime;
    public static GameManager Instance; //게임 매니져
    
    public GameObject _changeNameWindow; //이름 변경 창 버튼 
    public GameObject _nameList; //참석자 창 버튼
    public GameObject _playerChangeWindow; //캐릭터 변경 창 버튼
    public Button _nameChangeBtn; //플레이어 이름 변경 확정 버튼
    public Button _firBtn;
    public Button _SecBtn;
    public Button _thiBtn;

    private void Awake()
    {
        if (Instance == null)
        {
             Instance = this;
        }
        Button _nameListBtn = _nameList.GetComponent<Button>(); //버튼 지정해주기
        Button _nameChangeWindowBtn = _changeNameWindow.GetComponent<Button>(); //버튼 지정해주기
        Button _playerChangeWindowBtn = _playerChangeWindow.GetComponent<Button>(); //버튼 지정해주기

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
        _playerName.text = PlayerPrefs.GetString("PlayerName"); //플레이어의 이름 변경
    }
    private void Update()
    {
        _nowTime.text = DateTime.Now.ToString("HH시 mm분");
    }
    private void _playerChangeWindowOpen()
    {
        Time.timeScale = 0; //게임 시간 정지
        _playerChangeWindow.transform.GetChild(1).gameObject.SetActive(true);
    }//플레이어 변경 창 
    private void NameListWindowOpen() //참석자 창 뜨게하기
    {
        _nameList.transform.GetChild(1).gameObject.SetActive(true);
    }
    private void NameChangeWindowOpen() //현재 플레이어 이름 창 뜨게하기
    {
        Time.timeScale = 0; //게임 시간 정지
        _changeNameWindow.transform.GetChild(1).gameObject.SetActive(true);
    }
    private void NameChange() //현재 플레이어 이름 변경하기
    {
        if (_changeName.text.Length <= 10 && _changeName.text.Length >= 2)
        {
            Time.timeScale = 1; //게임 시간 작동
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
        Time.timeScale = 1; //게임 시간 작동
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
