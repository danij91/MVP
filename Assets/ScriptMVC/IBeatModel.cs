using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBeatModel{
    void Initialize();
    void On();
    void Off();
    void SetBPM(int bpm);
    int GetBPM();
    void RegisterBeatObserver(IBeatObserver o);
    void RemoveBeatObserver(IBeatObserver o);
    void RegisterBPMObserver(IBPMObserver o);
    void RemoveBPMObserver(IBPMObserver o);

}
