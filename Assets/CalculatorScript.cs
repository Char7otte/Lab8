using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CalculatorScript : MonoBehaviour
{
    private float usdConversion = 0.74f;
    private float jpyConversion = 82.78f;
    [SerializeField]private Toggle usdToggle = default;
    [SerializeField]private Toggle jpyToggle = default;

    private float sgdValue = default;
    [SerializeField]private TMP_InputField sgdInputField = default;

    private float convertedValue = default;
    [SerializeField]private TMP_InputField convertedInputField = default;

    public void OnInputFieldEnter() {
        sgdValue = float.Parse(sgdInputField.text);
        print(sgdValue);
    }

    public void SelectToggle(Toggle toggleToOff) {
        toggleToOff.isOn = false;
    }

    public void ConvertButtonPressed() {
        if (usdToggle.isOn) {
            convertedValue = ConvertCurrency(sgdValue, usdConversion);
        }
        else if (jpyToggle.isOn) {
            convertedValue = ConvertCurrency(sgdValue, jpyConversion);
        }
    }

    public void ClearButtonPressed() {
        usdToggle.isOn = false;
        jpyToggle.isOn = false;
        sgdInputField.text = "";
        sgdValue = 0;
        convertedInputField.text = "";
        convertedValue = 0;
    }

    private float ConvertCurrency(float _sgdValue, float _conversionRate) {
        var _convertedValue = _sgdValue *= _conversionRate;
        convertedInputField.text = _convertedValue.ToString();
        return _convertedValue;
    }

}
