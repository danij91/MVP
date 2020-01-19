using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatController : IController {
    IBeatModel model;
    DJView view;
	public BeatController(IBeatModel model,DJView view) {
        this.model = model;
        this.view = view;
        view.DisableStopMenuItem();
        view.EnableStartMenuItem();
        //model.Initialize();

    }

    public void Start() {
        model.On();
        view.DisableStartMenuItem();
        view.EnableStopMenuItem();
        view.HideDropDownList();
    }

    public void Stop() {
        model.Off();
        view.DisableStopMenuItem();
        view.EnableStartMenuItem();
        view.HideDropDownList();
    }
    public void Quit() {
        Stop();
        view.HideAll();
    }

    public void PushDJControl() {
        view.ShowDropDownList();
    }
    public void IncreaseBPM() {
        int bpm = model.GetBPM();
        model.SetBPM(bpm+1);
    }
    public void DecreaseBPM() {
        int bpm = model.GetBPM();
        model.SetBPM(bpm - 1);
    }
    public void SetBPM(int bpm) {
        model.SetBPM(bpm);
    }

}
