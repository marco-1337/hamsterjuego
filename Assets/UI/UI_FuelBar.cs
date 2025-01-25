using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Fuel : MonoBehaviour
{
    Slider _fuelUI;
    [SerializeField] 
    private Image _fuelIndicator;
    [SerializeField]
    private float _lerpColorTime = 1.0f;
    [SerializeField]
    private Color _originalColor = Color.red, _alertColor = Color.yellow;
    // Start is called before the first frame update
    void Start()
    {
        _fuelUI = GetComponent<Slider>();
    }
    public void SetFuelBar(float actualFuelTime)
    {
        _fuelUI.value = actualFuelTime;
    }
    public void ShiftColor()
    {
        _fuelIndicator.color = Color.Lerp(_originalColor, _alertColor, _lerpColorTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
