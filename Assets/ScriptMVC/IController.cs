using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController{

    void Start();
    void Stop();
    void Quit();
    void PushDJControl();
    void IncreaseBPM();
    void DecreaseBPM();
    void SetBPM(int bpm);
}
