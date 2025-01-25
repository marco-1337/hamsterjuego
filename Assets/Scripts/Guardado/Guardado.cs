using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Guardado/SistemaGuardado")]
public class Guardado : ScriptableObject
{
    public Transform _savedPlayerTransform;
    public int _savedPipas = 0;

    public bool cinematicPlayed = false;
}
