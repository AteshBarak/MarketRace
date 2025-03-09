using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSpeedManager : MonoBehaviour
{
    public ConveyorBelt[] beltSpeed;

    public void ChangeSpeed(float _divideCount)
    {
        float _speed = beltSpeed[0].speed;
        beltSpeed[0].speed = _speed / _divideCount;
        beltSpeed[1].speed = _speed / _divideCount;
    }
}
