using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public string nameInput;

    public TextMeshProUGUI userEntry;

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ReadInputString(string s)
    {   
        nameInput = userEntry.text;
        Debug.Log(nameInput);
    }
}
