using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFulscreen : MonoBehaviour {
    public GameObject toggle;

    public void toggleFulscreen() {
        Screen.fullScreen = !Screen.fullScreen;
        
    }
}
