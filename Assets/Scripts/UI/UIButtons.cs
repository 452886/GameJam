﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public void QuitApplication() {
        Application.Quit();
    }

    public void OpenScene(string scene) {
        SceneManager.LoadScene(scene);
    }
}