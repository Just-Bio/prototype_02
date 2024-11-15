using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keypadButton : MonoBehaviour
{
	public string buttonValue;
	public keypadManager keypad;
	public void PressButton(){keypad.AddInput(buttonValue);}

}
