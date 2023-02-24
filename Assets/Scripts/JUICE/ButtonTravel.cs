using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;
using Utilities.Events;

public class ButtonTravel : MonoBehaviour
{
    [SerializeField]
    Button _playButton;

    [SerializeField]
    GameEvent _playButtonPressed;

    [SerializeField]
    float _tweenTime;

    // Start is called before the first frame update
    void Start()
    {
        _playButton.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnButtonClick()
    {
        gameObject.transform.DOScaleY(0.4f, _tweenTime).OnComplete(ReturnToScale);
    }

    private void ReturnToScale()
    {
        gameObject.transform.DOScaleY(1f, _tweenTime / 2).OnComplete(() => { _playButtonPressed.Raise(); });
        
    }

}
