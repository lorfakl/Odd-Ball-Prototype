using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using Newtonsoft.Json;
public class Stage
{
    [JsonProperty("Round")]
    public int Round { get; set; }

    [JsonProperty("Answer")]
    public string Answer { get; set; }

    [JsonProperty("BallInfo")]
    public List<BallInfo> BallInfo { get; set; }
}
