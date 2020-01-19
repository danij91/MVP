using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatBar : MonoBehaviour {
    [SerializeField]
    private GameObject _filledSlider;
    private const float BEAT_BAR_POSX_PER_PERCENT = 174.0f;
    // Use this for initialization
    public void Boom() {
        //Debug.Log(_filledSlider.GetComponent<RectTransform>().localPosition);

        StartCoroutine(BoomCoroutine());
    }

    IEnumerator BoomCoroutine() {
        float time = 0f;
        while (time<0.2f) {
            time += Time.deltaTime;
            if (time < 0.1f) {
                _filledSlider.GetComponent<RectTransform>().localPosition = new Vector2(BEAT_BAR_POSX_PER_PERCENT * time / 0.1f, 0);
            } else {
                _filledSlider.GetComponent<RectTransform>().localPosition = new Vector2(BEAT_BAR_POSX_PER_PERCENT * (0.2f-time) / 0.1f, 0);
            }
            yield return null;
        }
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
