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
    AudioSource stageNarration;

    [SerializeField]
    Button playButton;

    [SerializeField]
    Transform[] ballParents;

    [SerializeField]
    GameObject[] ballObjects;

    private static Queue<BallInfo> _ballQueue;
    private float clipStartTime = 0;
    public static BallInfo DeQueue()
    {
        return _ballQueue.Dequeue();
    }

    public void OnPlayPressed()
    {
        HelperFunctions.Log("Play Pressed");
        playButton.gameObject.transform.DOLocalMoveY(-400, _tweenTime);
        foreach(var b in ballObjects)
        {
            BallObject ball = b.transform.GetComponentInChildren<BallObject>();
            ball.GetNext();
            b.gameObject.transform.DOLocalMoveX(0, _tweenTime);
            b.gameObject.transform.DOLocalRotate(new Vector3(0, 0, 720), _tweenTime, RotateMode.FastBeyond360);
        }
    }

    public void OnObjectSelected()
    {
        if (_ballQueue.Count > 0)
        {
            foreach (var b in ballObjects)
            {
                BallObject ball = b.transform.GetComponentInChildren<BallObject>();
                b.gameObject.transform.DOLocalRotate(new Vector3(0, 0, 720), _tweenTime, RotateMode.FastBeyond360);
                b.gameObject.transform.DOLocalMoveX(ball.InitialPosition.x, _tweenTime).OnComplete(
                    () =>
                    {
                        //b.gameObject.transform.DOLocalMoveX(0, _tweenTime / 2);
                        RollOut();

                    });
                ball.GetNext();
            }
        }
        else
        {

        }
    }

    private void Awake()
    {
        string ballDataFile = ballDataJson.text;
        List<Stage> stages = JsonConvert.DeserializeObject<List<Stage>>(ballDataFile);
        List<BallInfo> ballData = new List<BallInfo>();
        foreach (Stage stage in stages)
        {
            HelperFunctions.Log(stage);
            stage.LoadBallImages();
            stage.SetStartAudioTime();
            ballData.AddRange(stage.BallInfo);
        }

        _ballQueue = new Queue<BallInfo>(ballData);
       

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(clipStartTime + 1.5f < Time.realtimeSinceStartup && stageNarration.isPlaying)
        {
            HelperFunctions.Log("is this every called?");
            stageNarration.Stop();
        }
    }

    private void RollOut()
    {
        Sequence moveSequence = DOTween.Sequence();
        Sequence rotSequence = DOTween.Sequence();
        foreach(var b in ballObjects)
        {
            BallObject ball = b.transform.GetComponentInChildren<BallObject>();
            rotSequence.Append(b.gameObject.transform.DOLocalRotate(new Vector3(0, 0, 720), _tweenTime, RotateMode.FastBeyond360));
            moveSequence.Append(b.gameObject.transform.DOLocalMoveX(0, _tweenTime).
                OnComplete(() => PlayAudio(ball)));
        }

        //moveSequence.OnComplete(() => { stageNarration.Stop(); });
    }


    private void PlayAudio(BallObject b)
    {
        stageNarration.time = b.CurrentBallInfo.Time.Start;
        clipStartTime = Time.realtimeSinceStartup;
        stageNarration.Play();
    }
}
