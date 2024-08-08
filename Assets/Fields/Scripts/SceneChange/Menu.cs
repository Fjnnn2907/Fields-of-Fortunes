using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private AudioSource myAdio;
    [SerializeField]
    private AudioClip myClip;

    [SerializeField]
    private GameObject _loadingCanvas;

    [SerializeField]
    private Slider _loadingSlider;

    [SerializeField]
    private TextMeshProUGUI _loadingText;

    private void Start()
    {
        myAdio = GetComponent<AudioSource>();
        _loadingCanvas.SetActive(false);
    }
    public void LoadGame()
    {
        myAdio.PlayOneShot(myClip);
        //hien ra man hinh loading...
        _loadingCanvas.SetActive(true);
        StartCoroutine(timeLoadScene());

    }

    public void LoadExit()
    {
        myAdio.PlayOneShot(myClip);
        Application.Quit();
    }
    public void LoadMenu()
    {
        //hien ra man hinh loading...
        _loadingCanvas.SetActive(true);
        myAdio.PlayOneShot(myClip);
        StartCoroutine(timeLoadScene());
        SceneManager.LoadScene("MainMenu");

    }

    IEnumerator timeLoadScene()
    {
        //yield return new WaitForSeconds(0.18f);
        var value = 0;
        _loadingSlider.value = value;
        _loadingText.text = value + "%";
        while (true)
        {
            value++;
            _loadingSlider.value = value;
            _loadingText.text = value + "%";
            yield return new WaitForSeconds(0.03f /** Time.deltaTime*/);
            if (value >= 100)
            {
                break;
            }
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
