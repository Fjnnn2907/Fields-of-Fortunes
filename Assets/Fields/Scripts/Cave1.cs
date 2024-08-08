using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class Cave1 : MonoBehaviour
{
    [SerializeField]
    private GameObject _loadingCanvas;

    [SerializeField]
    private Slider _loadingSlider;

    [SerializeField]
    private TextMeshProUGUI _loadingText;

    private bool isTouchingPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        _loadingCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isTouchingPlayer == false)
        {
            isTouchingPlayer = true;
            //hien ra man hinh loading...
            _loadingCanvas.SetActive(true);
            StartCoroutine(Loading());
        }
    }

    IEnumerator Loading()
    {
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
        //chuyen sang scence 2
        SceneManager.LoadScene(1);
    }
}
