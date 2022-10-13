using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public partial class MenuNode
{
    [JsonProperty("TREE_ID")]
    public long TREE_ID { get; set; }

    [JsonProperty("TREE_NAME")]
    public string TREE_NAME { get; set; }

    [JsonProperty("IMAGE_FILE")]
    public string IMAGE_FILE { get; set; }

    [JsonProperty("NAVIGATE_URL")]
    public object NAVIGATE_URL { get; set; }

    [JsonProperty("PARENT_ID")]
    public long PARENT_ID { get; set; }

    [JsonProperty("LEVEL_ID")]
    public long LEVEL_ID { get; set; }

    [JsonProperty("SORT_ID")]
    public long SORT_ID { get; set; }

    [JsonProperty("IS_OPEN")]
    public string IS_OPEN { get; set; }
}

public partial class MenuNode
{
    public static MenuNode FromJson(string json)
    {
        return JsonConvert.DeserializeObject<MenuNode>(json, Converter.Settings);
    }
}

public static class Serialize
{
    public static string ToJson(this MenuNode self)
    {
        return JsonConvert.SerializeObject(self, Converter.Settings);
    }
}

internal static class Converter
{
    public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
    {
        MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
        DateParseHandling = DateParseHandling.None,
        Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
    };
}