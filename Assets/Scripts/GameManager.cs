using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _playerName;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        PlayerPrefs.SetString("PlayerName", "jeonghyeok");
        _playerName.text = PlayerPrefs.GetString("PlayerName");
    }
}
