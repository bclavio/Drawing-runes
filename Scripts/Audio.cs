using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Audio : MonoBehaviour {

    public static int audiostate = 0;
    private AudioSource audio;
    public AudioClip hand, blob, metal, swing, next, wand1, wand2, wand3; 


    void Start() {
        audio = GetComponent<AudioSource>();
    }
	public void audioManager(int audiostate) {
        if (audiostate == 0) { // left and right hand button
            audio.clip = hand;
            audio.Play();
        }
        if (audiostate == 1) { // CanvasStart: textanimation button
            audio.clip = blob;
            audio.Play();
        }
        if (audiostate == 2) { // Intro: Next button
            audio.clip = swing;
            audio.Play();
        }
        if (audiostate == 3) { //tutorial: show path button
            audio.clip = next;
            audio.Play();
        }
        if (audiostate == 4) { //tutorial: show path button
            audio.clip = metal;
            audio.Play();
        }
      
    }
    void Update() {
        if (audiostate == 5) { // widget animation1
            audio.clip = wand1;
            audio.Play();
            audiostate++;
        }
        if (audiostate == 7) { // widget animation2
            audio.clip = wand2;
            audio.Play();
            audiostate++;
        }
        if (audiostate == 9) { // widget animation3
            audio.clip = wand3;
            audio.Play();
            audiostate++;
        }
    }
}
