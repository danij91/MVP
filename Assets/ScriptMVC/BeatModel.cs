using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatModel : MonoBehaviour, IBeatModel {
    private List<IBeatObserver> beatObservers = new List<IBeatObserver>();
    private List<IBPMObserver> bpmObservers = new List<IBPMObserver>();
    private int bpm = 0;
    private float time;
    private const float MINUTE_TO_SECONDS = 60.0f;
    public void Initialize() {

    }

    public void On() {
        SetBPM(90);
        time = 0;
    }

    public void Off() {
        SetBPM(0);
    }

    public void SetBPM(int bpm) {
        this.bpm = bpm;
        NotifyBPMObservers();
    }

    public int GetBPM() {
        return bpm;
    }

    private void BeatEvent() {
        NotifyBeatObservers();
    }

    private void NotifyBPMObservers() {
        for (int i = 0; i < bpmObservers.Count; i++) {
            bpmObservers[i].UpdateBPM();
        }
    }
    private void NotifyBeatObservers() {
        for (int i = 0; i < beatObservers.Count; i++) {
            beatObservers[i].UpdateBeat();
        }
    }

    public void RegisterBeatObserver(IBeatObserver o) {
        beatObservers.Add(o);
    }
    public void RemoveBeatObserver(IBeatObserver o) {
        beatObservers.Remove(o);
    }
    public void RegisterBPMObserver(IBPMObserver o) {
        bpmObservers.Add(o);
    }
    public void RemoveBPMObserver(IBPMObserver o) {
        bpmObservers.Remove(o);
    }
    // Update is called once per frame
    void Update() {
        if (bpm != 0f) {
            
            time += Time.deltaTime;
            if (time > MINUTE_TO_SECONDS / bpm) {
                BeatEvent();
                time = 0f;
            }
        }
    }
}
