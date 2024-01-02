using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTools : MonoBehaviour
{
    public List<GameObject> vcs;

    private CinemachineBrain brain;


    // Start is called before the first frame update
    void Start()
    {
        brain = GetComponent<CinemachineBrain>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(vcs.Count>0)
            {
                disableCams();
                vcs[0].SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (vcs.Count > 1)
            {
                disableCams();
                vcs[1].SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (vcs.Count > 2)
            {
                disableCams();
                vcs[2].SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (vcs.Count > 3)
            {
                disableCams();
                vcs[3].SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (vcs.Count > 4)
            {
                disableCams();
                vcs[4].SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (vcs.Count > 5)
            {
                disableCams();
                vcs[5].SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (vcs.Count > 6)
            {
                disableCams();
                vcs[6].SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (vcs.Count > 7)
            {
                disableCams();
                vcs[7].SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            if (vcs.Count > 8)
            {
                disableCams();
                vcs[8].SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (vcs.Count > 9)
            {
                disableCams();
                vcs[9].SetActive(true);
            }
        }
    }

    void disableCams()
    {
        foreach (var vc in vcs) { 
        vc.SetActive(false);}
    }
}
