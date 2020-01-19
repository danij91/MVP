using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimationModel {
    void On();
    void Off();
    void SetFPS(int bpm);
    int GetFPS();
    Sprite GetSprite();
    void RegisterImageObserver(IImageObserver o);
    void RemoveImageObserver(IImageObserver o);
    void RegisterFPSObserver(IFPSObserver o);
    void RemoveFPSObserver(IFPSObserver o);
}
