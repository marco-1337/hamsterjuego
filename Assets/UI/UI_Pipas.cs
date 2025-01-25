using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Pipas : MonoBehaviour
{
    [SerializeField] Pipas pipas;

    TMP_Text sexo;
    private void Start()
    {
        sexo = GetComponent<TMP_Text>();
    }
    void Update()
    {
        sexo.text = "" + pipas.numPipas;
    }
}
