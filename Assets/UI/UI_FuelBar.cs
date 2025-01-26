using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Fuel : MonoBehaviour
{
    Slider _fuelUI;
    [SerializeField]
    private float _lerpColorTime = 1.0f;
    [SerializeField]
    GameObject _overheatIndicator;
    // Start is called before the first frame update
    void Start()
    {
        _overheatIndicator.SetActive(false);
        _fuelUI = GetComponent<Slider>();
    }
    public void SetFuelBar(float actualFuelTime)
    {
        _fuelUI.value = actualFuelTime;
    }
    public void Overheated(bool a)
    {
        //Debug.Log("b");
        _overheatIndicator.SetActive(a);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
