using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private AsyncOperation _loading;

    public void Init(AsyncOperation loading) => _loading = loading;
    
    void Update()
    {
        if (_loading == null) return;
        
        slider.value = _loading.progress;
        if (_loading.progress >= 0.9f)
            slider.value = 1;
    }
}
