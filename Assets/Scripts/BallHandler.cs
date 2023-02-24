using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using DG.Tweening;
using Utilities;

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

    private Queue<BallInfo> _ballQueue = new Queue<BallInfo>();

    public BallInfo DeQueue()
    {
        return _ballQueue.Dequeue();
    }

    public void OnPlayPressed()
    {
        HelperFunctions.Log("Play Pressed");
        playButton.gameObject.transform.DOLocalMoveY(-400, _tweenTime);
        foreach(var b in ballObjects)
        {
            b.gameObject.transform.DOLocalMoveX(0, _tweenTime);
            b.gameObject.transform.DOLocalRotate(new Vector3(0, 0, 720), _tweenTime, RotateMode.FastBeyond360);
        }
    }

    public void OnObjectSelected()
    {
        foreach (var b in ballObjects)
        {
            BallObject ball = b.transform.GetComponentInChildren<BallObject>();
            b.gameObject.transform.DOLocalRotate(new Vector3(0, 0, 720), _tweenTime, RotateMode.FastBeyond360);
            b.gameObject.transform.DOLocalMoveX(ball.InitialPosition.x, _tweenTime).OnComplete(
                () => 
                {
                    b.gameObject.transform.DOLocalMoveX(0, _tweenTime / 2);
                    RollOut(ball);
                    
                });
            ball.GetNext();

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

    private void RollOut(BallObject b)
    {

    }
}
