using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimationController{
    //view에서 참조할 함수들
    void Faster();
    void Slower();
    void SetFPS(int fps);
    void StartAnimation();
    void StopAnimation();

    //model에서 참조할 함수들
    void SetViewFPS();
}
