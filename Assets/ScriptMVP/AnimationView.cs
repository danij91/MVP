using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationView : MonoBehaviour {
    private AnimationController _controller;
    private Image _Image_currentPic;
    [SerializeField]
    private Button _Button_faster;
    [SerializeField]
    private Button _Button_slower;
    [SerializeField]
    private Button _Button_setFPS;
    [SerializeField]
    private InputField _InfutField_targetFPS;
    [SerializeField]
    private Text _Text_currentFPS;

    public void Start() {
        Initialize();
    }

    public void Initialize() {
        
        _controller = new AnimationController(gameObject.AddComponent<AnimationModel>(),this);
        _Image_currentPic = GetComponent<Image>();
    }
    //controller가 참조할 함수들
    public void SetFPSText(int fps) {
        _Text_currentFPS.text = fps + "";
    }

    public void ChangeImage(Sprite nextSprite) {
        _Image_currentPic.sprite = nextSprite;
    }


    //ButtonClickEvent 함수들
    public void Faster() {
        _controller.Faster();
    }
    public void Slower() {
        _controller.Slower();
    }
    public void SetFPS() {
        int fps = int.Parse(_InfutField_targetFPS.text);
        _controller.SetFPS(fps);
    }
    public void StartAnimation() {
        _controller.StartAnimation();
    }
    public void StopAnimation() {
        _controller.StopAnimation();
    }
}
