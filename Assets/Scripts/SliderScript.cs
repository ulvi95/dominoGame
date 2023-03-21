using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderScript : MonoBehaviour
{
    private TextMeshProUGUI numberOfPlayers;
    public Slider mainSlider;
    float value;

    void Start()
    {
        numberOfPlayers = GetComponent<TextMeshProUGUI>();
        value = mainSlider.value;
		PlayerPrefs.SetInt("numberOfPlayers", Mathf.RoundToInt(value));
		mainSlider.onValueChanged.AddListener(delegate {Change(); });
    }

    void Change()
    {
        value = mainSlider.value;
        numberOfPlayers.text = Mathf.RoundToInt(value).ToString();
		PlayerPrefs.SetInt("numberOfPlayers", Mathf.RoundToInt(value));
    }
	
	
}
