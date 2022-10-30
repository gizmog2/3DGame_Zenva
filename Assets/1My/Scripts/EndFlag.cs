using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    [SerializeField] string nextSceneName;
    [SerializeField] bool lastLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (lastLevel == true)
            {
                Debug.Log("You win!");
            }
            else
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
