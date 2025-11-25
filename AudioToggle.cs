using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioToggle : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isMuted = false;
    
    void Start() //functions
    {
        
    }

    public void ToggleAudio()
    {
        isMuted = !isMuted;
        if (isMuted)
        {
            AudioListener.pause = true;
        }
        else { 
            AudioListener.pause = false; 
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
