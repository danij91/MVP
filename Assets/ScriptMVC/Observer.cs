using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBeatObserver {
    void UpdateBeat();
}

public interface IBPMObserver {
    void UpdateBPM();
}
