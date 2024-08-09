using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class End : MonoBehaviour
{
    public string sceneName;
    private void Update()
    {
        if(BossFin.instance.hp <= 0)
        {
            SceneManager.LoadScene("Map13 1");
        }
    }

}
