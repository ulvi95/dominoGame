using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglerScript : MonoBehaviour
{
    public Toggle toggle;
	private bool doubleToggler;

    private void Start()
    {
		toggle = GetComponent<Toggle>();
		doubleToggler = toggle.isOn;
		PlayerPrefs.SetInt("doubleToggleValue", doubleToggler ? 1 : 0);
		toggle.onValueChanged.AddListener(delegate {Change(); });
    }

    public void Change()
    {
		doubleToggler = toggle.isOn;
        PlayerPrefs.SetInt("doubleToggleValue", doubleToggler ? 1 : 0);
    }
}

