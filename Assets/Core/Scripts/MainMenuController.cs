using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.MainMenuCanvasCheck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
