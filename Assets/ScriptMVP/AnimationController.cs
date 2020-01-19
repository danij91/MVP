using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : IAnimationController,IFPSObserver,IImageObserver {
    private IAnimationModel _model;
    private AnimationView _view;

    public AnimationController(IAnimationModel model,AnimationView view) {
        this._model = model;
        this._view = view;
        _model.RegisterFPSObserver(this);
        _model.RegisterImageObserver(this);
    }

    public void Faster() {
        int fps = _model.GetFPS();
        _model.SetFPS(fps + 1);
    }
    public void Slower() {
        int fps = _model.GetFPS();
        _model.SetFPS(fps - 1);
    }
    public void SetFPS(int fps) {
        _model.SetFPS(fps);
    }
    public void StartAnimation() {
        _model.On();
    }
    public void StopAnimation() {
        _model.Off();
    }
    public void SetViewFPS() {
        int fps = _model.GetFPS();
        _view.SetFPSText(fps);
    }
    public void UpdateFPS() {
        SetViewFPS();
    }
    public void UpdateImage() {
        _view.ChangeImage(_model.GetSprite());
    }
}
