using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using DG.Tweening;

public class BallHandler : MonoBehaviour
{
    [SerializeField]
    float _tweenTime;

    [SerializeField]
    TextAsset ballDataJson;

    [SerializeField]
    Button playButton;

    [SerializeField]
    Transform[] ballParents;

    [SerializeField]
    GameObject[] ballObjects;


    public void OnPlayPressed()
    {
        playButton.gameObject.transform.DOLocalMoveY(-400, _tweenTime);
        foreach(var b in ballObjects)
        {
            b.gameObject.transform.DOLocalMoveX(0, _tweenTime);
        }
    }

    public void OnObjectSelected()
    {
        foreach (var b in ballObjects)
        {
            BallObject ball = b.gameObject.GetComponent<BallObject>();
            b.gameObject.transform.DOLocalMoveX(ball.InitialPosition.x, _tweenTime).OnComplete(
                () => 
                {
                    b.gameObject.transform.DOLocalMoveX(0, _tweenTime / 2);
                    
                });

        }
    }

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
