using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IImageObserver {
    void UpdateImage();
}

public interface IFPSObserver {
    void UpdateFPS();
}
