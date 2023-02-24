using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class Level
{
    [JsonProperty("Stages")]
    public List<Stage> Stages { get; set; }
}
