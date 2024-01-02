using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    Button btn;

    // Start is called before the first frame update
    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate { LoadScene(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Game");
    }
}
