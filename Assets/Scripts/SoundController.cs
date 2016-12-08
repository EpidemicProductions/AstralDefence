using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour {

    public AudioClip tap;
    public AudioClip shoot;
    public AudioClip buttonPress;
    public AudioClip error;
    public AudioClip explosion;
    public AudioClip laser;
    public AudioClip pickup;
    public AudioClip countDown;
    public AudioClip powerUp;
    public AudioClip healthDrop;
    public AudioClip selectTower;
    AudioSource sound;

    // Use this for initialization
    void Start () {
        sound = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {


	
	}

    public void tapPlay()
    {
        sound.PlayOneShot(tap, 0.7F);
    }

    public void shootPlay()
    {
        sound.PlayOneShot(shoot, 0.5F);
    }

    public void buttonPressPlay()
    {
        sound.PlayOneShot(buttonPress, 0.7F);
    }

    public void errorPlay()
    {
        sound.PlayOneShot(error, 0.7F);
    }

    public void explosionPlay()
    {
        sound.PlayOneShot(explosion, 0.7F);
    }

    public void laserPlay()
    {
        sound.PlayOneShot(laser, 0.7F);
    }

    public void pickupPlay()
    {
        sound.PlayOneShot(pickup, 0.7F);
    }

    public void countDownPlay()
    {
        sound.PlayOneShot(countDown, 0.7F);
    }

    public void powerUpPlay()
    {
        sound.PlayOneShot(powerUp, 0.7F);
    }

    public void healthDropPlay()
    {
        sound.PlayOneShot(healthDrop, 0.7F);
    }

    public void selectTowerPlay()
    {
        sound.PlayOneShot(selectTower, 0.7F);
    }
}
