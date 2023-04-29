using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIHelperTitle : MonoBehaviour
{
    public TextMeshProUGUI displayPlayerName_Text;
    public string playerName;
    public TMP_InputField nameInputField;

    // Start is called before the first frame update
    void Start()
    {
        nameInputField.characterLimit = 8;
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

    public void EasyStart()
    {
        MainManager.Instance.difficulty = 1f;
        SceneManager.LoadScene(1);
    }

    public void HardStart()
    {
        MainManager.Instance.difficulty = 1.5f;
        SceneManager.LoadScene(1);
    }

    public void StartButtonClick()
    {
        SceneManager.LoadScene(1);
    }
}
