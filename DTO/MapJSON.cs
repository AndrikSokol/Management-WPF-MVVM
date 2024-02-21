using Newtonsoft.Json;

public class MapJSON
{
    [JsonProperty("productName")]
    public string? ProductName { get; set; }

    [JsonProperty("gtin")]
    public string? Gtin { get; set; }

    [JsonProperty("boxFormat")]
    public int BoxFormat { get; set; }

    [JsonProperty("palletFormat")]
    public int PalletFormat { get; set; }

    [JsonProperty("pallets")]
    public List<PalletInfo>? Pallets { get; set; }
}

public class PalletInfo
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("code")]
    public string? Code { get; set; }

    [JsonProperty("boxes")]
    public List<BoxInfo>? Boxes { get; set; }
}

public class BoxInfo
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("code")]
    public string? Code { get; set; }

    [JsonProperty("bottles")]
    public List<BottleInfo>? Bottles { get; set; }
}

public class BottleInfo
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("code")]
    public string? Code { get; set; }
}