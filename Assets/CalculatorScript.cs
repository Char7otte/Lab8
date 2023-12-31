﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CalculatorScript : MonoBehaviour
{
    private float usdConversion = 0.74f;
    private float jpyConversion = 82.78f;
    private float rmConversion = 3.08f;
    private float eurConversion = 0.63f;
    private float krwConversion = 881.54f;
    private float twdConversion = 20.73f;

    [SerializeField]private Toggle usdToggle = default;
    [SerializeField]private Toggle jpyToggle = default;
    [SerializeField]private Toggle rmToggle = default;
    [SerializeField]private Toggle eurToggle = default;
    [SerializeField]private Toggle krwToggle = default;
    [SerializeField]private Toggle twdToggle = default;

    [SerializeField]private Toggle[] currencyToggles = default;


    private float sgdValue = default;
    [SerializeField]private TMP_InputField sgdInputField = default;

    private float convertedValue = default;
    [SerializeField]private TMP_InputField convertedInputField = default;

    [SerializeField]private TextMeshProUGUI errorDisplayText = default;

    public void OnInputFieldEnter() {
        try {
            sgdValue = float.Parse(sgdInputField.text);
        }
        catch (Exception e) {
            errorDisplayText.gameObject.SetActive(true);
            ClearButtonPressed();
            return;
        }

        errorDisplayText.gameObject.SetActive(false);
    }

    public void SelectToggle(Toggle thisToggle) {
        List<Toggle> list = new List<Toggle>(currencyToggles);
        list.Remove(thisToggle);
        var _currencyToggles = list.ToArray();

        foreach (var toggle in _currencyToggles) {
            toggle.isOn = false;
        }
    }

    public void ConvertButtonPressed() {
        if (usdToggle.isOn) {
            convertedValue = ConvertCurrency(sgdValue, usdConversion);
        }
        else if (jpyToggle.isOn) {
            convertedValue = ConvertCurrency(sgdValue, jpyConversion);
        }
        else if (rmToggle.isOn) {
            convertedValue = ConvertCurrency(sgdValue, rmConversion);
        }
        else if (eurToggle.isOn) {
            convertedValue = ConvertCurrency(sgdValue, eurConversion);
        }
        else if (krwToggle.isOn) {
            convertedValue = ConvertCurrency(sgdValue, krwConversion);
        }
        else if (twdToggle.isOn) {
            convertedValue = ConvertCurrency(sgdValue, twdConversion);
        }
    }

    public void ClearButtonPressed() {
        foreach (var toggle in currencyToggles) {
            toggle.isOn = false;
        }

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
