using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TEXTcontroller : MonoBehaviour
{

    public float hideDelay = 10.0f;
    public TextMeshProUGUI InstructionUI;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HideUI());

    }

    // Update is called once per frame
    private IEnumerator HideUI()
    {
        yield return new WaitForSeconds(hideDelay);

        InstructionUI.enabled = false;
    }

}
