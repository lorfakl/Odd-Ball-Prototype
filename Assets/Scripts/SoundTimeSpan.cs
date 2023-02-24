using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class SoundTimeSpan
{
    [JsonProperty("Start")]
    public float Start;

    [JsonProperty("End")]
    public float End;
}
