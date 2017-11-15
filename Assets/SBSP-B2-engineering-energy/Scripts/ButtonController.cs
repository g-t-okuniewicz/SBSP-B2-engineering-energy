using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



    public class ButtonController : MonoBehaviour
    {

        public void ReloadScene()
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("reactor-test-system");
        }
    }
