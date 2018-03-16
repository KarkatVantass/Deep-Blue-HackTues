using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownScript : MonoBehaviour {
    private Resolution[] resolutions;
    public Dropdown resMenu; 
	// Use this for initialization
	void Start () {
        this.resolutions = Screen.resolutions;
        for (int i = 0; i < resolutions.Length - 1; i++)
        {
            resMenu.options.Add(new Dropdown.OptionData(resToText(resolutions[i])));

            resMenu.value = i;

            resMenu.onValueChanged.AddListener(delegate { Screen.SetResolution(resolutions[resMenu.value].width, resolutions[resMenu.value].height, Screen.fullScreen);  } );
        }
    }
    

    private string resToText(Resolution res)
    {
        return res.width + "x" + res.height;
    }
    public void onValueChanged() {
        Screen.SetResolution(resolutions[resMenu.value].width, resolutions[resMenu.value].height, Screen.fullScreen);
    }
}
