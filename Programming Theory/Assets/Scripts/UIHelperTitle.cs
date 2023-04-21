using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHelperTitle : MonoBehaviour
{
    public TextMeshProUGUI displayPlayerName_Text;
    public string playerName;
    public TMP_InputField nameInputField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SavePlayerName()
    {
        playerName = nameInputField.text;
        MainManager.Instance.playerName = playerName;
        displayPlayerName_Text.text = playerName;
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }

    public void StartButtonClick()
    {
        SceneManager.LoadScene(1);
    }
}
