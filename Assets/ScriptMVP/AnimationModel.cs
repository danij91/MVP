using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnimationModel : MonoBehaviour, IAnimationModel {
    private int _fps=0;
    private float _time=0;
    private Sprite[] _sprites;
    private int _currentSpriteIndex=0;
    private const float ONE_SECOND_AS_FLOAT = 1.0f;
    private List<IImageObserver> _imageObservers = new List<IImageObserver>();
    private List<IFPSObserver> _FPSObservers = new List<IFPSObserver>();
    private IAnimationController _controller;

    void Start() {
        Initalize();
    }
    public void Initalize() {
        _sprites = Resources.LoadAll<Sprite>("sprites");
    }
    public void On() {
        SetFPS(30);

    }
    public void Off() {
        SetFPS(0);
    }
    public void SetFPS(int fps) {
        this._fps = fps;
        NotifyFPSObservers();
    }
    public int GetFPS() {
        return _fps;
    }
    public Sprite GetSprite() {
        return _sprites[_currentSpriteIndex];
    }
    public void ImageChangeEvent() {
        if (_currentSpriteIndex >= _sprites.Length - 1) {
            _currentSpriteIndex = 0;
        } else {
            _currentSpriteIndex += 1;
        }
        NotifyImageObservers();
    }
    public void RegisterImageObserver(IImageObserver o) {
        _imageObservers.Add(o);
    }
    public void RemoveImageObserver(IImageObserver o) {
        _imageObservers.Remove(o);
    }
    public void RegisterFPSObserver(IFPSObserver o) {
        _FPSObservers.Add(o);
    }
    public void RemoveFPSObserver(IFPSObserver o) {
        _FPSObservers.Remove(o);
    }
    public void NotifyImageObservers() {
        for(int i = 0; i < _imageObservers.Count; i++) {
            _imageObservers[i].UpdateImage();
        }
    }
    public void NotifyFPSObservers() {
        for (int i = 0; i < _FPSObservers.Count; i++) {
            _FPSObservers[i].UpdateFPS();
        }
    }

    void Update() {
        if (_fps != 0) {
            _time += Time.deltaTime;
            if (_time > ONE_SECOND_AS_FLOAT / _fps) {
                ImageChangeEvent();
                _time = 0f;
            }
        }
    }
}
