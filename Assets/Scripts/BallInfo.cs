using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class BallInfo
{
    [JsonProperty("Word")]
    public string Word { get; set; }
    
    [JsonProperty("Time")] 
    public SoundTimeSpan Time { get; set; }

    public Sprite Image { get; set; }

    public override string ToString()
    {
        return $"Word: {this.Word}\n" +
            $"Time: {this.Time}\n";
    }
}
