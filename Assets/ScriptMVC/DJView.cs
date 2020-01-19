using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DJView : MonoBehaviour,IBeatObserver,IBPMObserver{
    IBeatModel model;
    IController controller;
    [SerializeField]
    BeatBar _beatBar;
    [SerializeField]
    private Text _Text_BPMOutput;
    [SerializeField]
    private InputField _InputField_BPM;
    [SerializeField]
    private Button _Button_setBPM;
    [SerializeField]
    private Button _Button_increaseBPM;
    [SerializeField]
    private Button _Button_decreaseBPM;
    [SerializeField]
    private MenuItem _menuItem_start;
    [SerializeField]
    private MenuItem _menuItem_stop;
    [SerializeField]
    private GameObject _dropDownList;

    void Start() {
        model = gameObject.AddComponent<BeatModel>();
        model.RegisterBPMObserver(this);
        model.RegisterBeatObserver(this);
        controller = new BeatController(model,this);

    }
    public void UpdateBPM() {
        int bpm = model.GetBPM();
        if (bpm == 0) {
            _Text_BPMOutput.text = "offLine";
        } else {
            _Text_BPMOutput.text = "Current BPM : " + bpm;
        }
    }

    public void UpdateBeat() {
        _beatBar.Boom();
    }
    
    public void EnableStopMenuItem() {
        _menuItem_stop.SetEnabled(true);
    }
    public void DisableStopMenuItem() {
        _menuItem_stop.SetEnabled(false);
    }
    public void EnableStartMenuItem() {
        _menuItem_start.SetEnabled(true);
    }
    public void DisableStartMenuItem() {
        _menuItem_start.SetEnabled(false);
    }
    public void PushStart() {
        controller.Start();
    }
    public void PushStop() {
        controller.Stop();
    }
    public void PushQuit() {
        controller.Quit();
    }
    public void PushDJControl() {
        controller.PushDJControl();
    }
    public void ShowDropDownList() {
        _dropDownList.SetActive(true);
    }
    public void HideDropDownList() {
        _dropDownList.SetActive(false);
    }
    public void HideAll() {
        gameObject.SetActive(false);
    }
    //public void actionPerformed()
    public void SetBPM() {
        int bpm = int.Parse(_InputField_BPM.text);
        controller.SetBPM(bpm);
    }

    public void IncreaseBPM() {
        controller.IncreaseBPM();
    }
    public void DecreaseBPM() {
        controller.DecreaseBPM();
    }
}
