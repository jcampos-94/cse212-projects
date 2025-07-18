// Root object of the JSON
public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

// Each earthquake entry
public class Feature
{
    public Property Properties { get; set; }
}

// Details (properties) of an earthquake
public class Property
{
    public double? Mag { get; set; }
    public string Place { get; set; }
}