using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class KeyBindScript : MonoBehaviour
{
    public GameObject assignedKeyText;

    public Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public TextMeshProUGUI right, left, up, down, jump, pogo, fire;

    private GameObject currentKey;

    private void Start()
    {
        keys.Add("Move Right Button", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Move Right Button", "RightArrow")));
        keys.Add("Move Left Button", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Move Left Button", "LeftArrow")));
        keys.Add("Look Up Button", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Look Up Button", "UpArrow")));
        keys.Add("Look Down Button", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Look Down Button", "DownArrow")));
        keys.Add("Jump Button", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump Button", "LeftControl")));
        keys.Add("Pogo Button", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Pogo Button", "LeftAlt")));
        keys.Add("Fire Button", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Fire Button", "Space")));

        right.text = keys["Move Right Button"].ToString();
        left.text = keys["Move Left Button"].ToString();
        up.text = keys["Look Up Button"].ToString();
        down.text = keys["Look Down Button"].ToString();
        jump.text = keys["Jump Button"].ToString();
        pogo.text = keys["Pogo Button"].ToString();
        fire.text = keys["Fire Button"].ToString();
    }
    private void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey && (e.keyCode != KeyCode.Return) && (e.keyCode != KeyCode.Escape))
            {
                assignedKeyText = currentKey.gameObject.transform.GetChild(0).gameObject;
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = e.keyCode.ToString();
                assignedKeyText.SetActive(true);
                currentKey = null;
            }
        }
    }

    public void ChangeKey (GameObject clicked)
    {
        currentKey = clicked;
        assignedKeyText = currentKey.gameObject.transform.GetChild(0).gameObject;
        assignedKeyText.SetActive(false);
    }

    public void SaveKeys()
    {
        foreach(var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }

        PlayerPrefs.Save();
    }
}
