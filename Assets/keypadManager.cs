using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class keypadManager : MonoBehaviour
{
    public int keypadCode; 
    public TMP_Text keypadDisplay;
    private string currentInput;
    public UnityEvent triggerOnSuccess;
    private string accessGrantedText = "Granted";
    private string accessDeniedText = "Denied";

    private void Awake(){clearInput();}
    public void AddInput(string userInput)
    {
        switch (userInput)
        {
            case "enter":
             
                checkInputtedCode();
                Debug.Log("been pressed");
                break;
            default:
                if (currentInput != null && currentInput.Length >= 4)
                {
                    return;
                }
                currentInput += userInput;
                keypadDisplay.text = currentInput;
                break;
        }
    }
    public void checkInputtedCode()
    {
        if (int.TryParse(currentInput, out var currentEntry))
        {
            bool accessgranted = currentEntry == keypadCode;
            if (accessgranted) { accessGranted(); }
            else { accessDenied(); }
            clearInput();
        }
    }

    private void accessDenied(){keypadDisplay.text = accessDeniedText;}

    private void clearInput(){ currentInput = "";  keypadDisplay.text = currentInput; }

    private void accessGranted()
    {
        keypadDisplay.text = accessGrantedText;
        triggerOnSuccess?.Invoke();
    }

}
