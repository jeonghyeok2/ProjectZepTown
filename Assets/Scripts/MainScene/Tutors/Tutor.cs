using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutor : MonoBehaviour
{
    public GameObject _tutorName;
    public GameObject _popupWindow;

    public string _name;
    public int _tutorindex;
    private string _text;

    private void Start()
    {
        _tutorName.GetComponent<TextMesh>().text = _name;
    }

    private string Text()
    {
        _text = "부르셨나요??";
        return _text;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _popupWindow.GetComponent<TextMeshProUGUI>().text = _name;
        GameManager.Instance._text = Text();
        GameManager.Instance.NpcPopUP(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameManager.Instance.NpcPopUP(false);
        GameManager.Instance.TextConsoleWindowOpen(false);
    }
}
