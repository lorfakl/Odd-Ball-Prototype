using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using Newtonsoft.Json;
using Utilities;

public class Stage
{
    [JsonProperty("Round")]
    public int Round { get; set; }

    [JsonProperty("Answer")]
    public string Answer { get; set; }

    [JsonProperty("BallInfo")]
    public List<BallInfo> BallInfo { get; set; }

    public void LoadBallImages()
    {
        foreach(BallInfo ball in BallInfo)
        {
            var image = Resources.Load<Sprite>("Images/" + ball.Word.ToLower());
            ball.Image = image;
        }
    }

    public void SetStartAudioTime()
    {
        
        for(int i = 0; i < BallInfo.Count; i++)
        {
            if(i+1 < BallInfo.Count)
            {
                BallInfo[i + 1].Time.Start = BallInfo[i].Time.End;
            }
        }
    }

    public override string ToString()
    {
        return $"Round: {this.Round}\n" +
            $"Answer: {this.Answer}\n" +
            $"Options: {HelperFunctions.PrintListContent(this.BallInfo)}\n";
    }
}
