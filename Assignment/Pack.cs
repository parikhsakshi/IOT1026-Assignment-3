namespace Assignment;


using System;
public class InventoryItem
{
    public string Name { get; }
    public double Weight { get; }
    public double Volume { get; }

    public InventoryItem(string name, double weight, double volume)
    {
        Name = name;
        Weight = weight;
        Volume = volume;
    }
}
public class Arrow : InventoryItem
{
    public Arrow() : base("Arrow", 0.1, 0.01)
    {
    }
}

public class Pack
{
    private List<InventoryItem> _items;

    public int MaxCount { get; }
    public double MaxVolume { get; }
    public double MaxWeight { get; }

    public Pack(int maxCount, double maxVolume, double maxWeight)
    {
        MaxCount = maxCount;
        MaxVolume = maxVolume;
        MaxWeight = maxWeight;

        _items = new List<InventoryItem>();
    }

    public bool Add(InventoryItem item)
    {
        if (_items.Count >= MaxCount || GetCurrentWeight() + item.Weight > MaxWeight ||
            GetCurrentVolume() + item.Volume > MaxVolume)
        {
            return false;
        }

        _items.Add(item);
        return true;
    }

    private double GetCurrentWeight()
    {
        double weight = 0;
        foreach (var item in _items)
        {
            weight += item.Weight;
        }
        return weight;
    }

    private double GetCurrentVolume()
    {
        double volume = 0;
        foreach (var item in _items)
        {
            volume += item.Volume;
        }
        return volume;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Pack Contents:");
        foreach (var item in _items)
        {
            sb.AppendLine($"- {item.Name}: Weight={item.Weight}, Volume={item.Volume}");
        }
        sb.AppendLine($"Current Weight: {GetCurrentWeight()} / {MaxWeight}");
        sb.AppendLine($"Current Volume: {GetCurrentVolume()} / {MaxVolume}");
        sb.AppendLine($"Remaining Capacity: {MaxCount - _items.Count} items");
        return sb.ToString();
    }
}

