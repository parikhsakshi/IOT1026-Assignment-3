using Assignment;

namespace AssignmentTest
{
   // InventoryItem base class
public class InventoryItem
{
    public double Weight { get; }
    public double Volume { get; }

    public InventoryItem(double weight, double volume)
    {
        Weight = weight;
        Volume = volume;
    }
}

// Derived classes representing different items
public class Arrow : InventoryItem
{
    public Arrow() : base(weight: 0.1, volume: 0.1)
    {
    }
}

public class Bow : InventoryItem
{
    public Bow() : base(weight: 1.5, volume: 5.0)
    {
    }
}

public class Rope : InventoryItem
{
    public Rope() : base(weight: 0.8, volume: 2.0)
    {
    }
}

public class Water : InventoryItem
{
    public Water() : base(weight: 1.0, volume: 1.0)
    {
    }
}

public class Food : InventoryItem
{
    public Food() : base(weight: 0.5, volume: 0.5)
    {
    }
}

public class Sword : InventoryItem
{
    public Sword() : base(weight: 2.0, volume: 10.0)
    {
    }
}

// Pack class
public class Pack
{
    private List<InventoryItem> items;
    private int maxItemCount;
    private double maxVolume;
    private double maxWeight;

    public Pack(int maxItemCount, double maxVolume, double maxWeight)
    {
        items = new List<InventoryItem>();
        this.maxItemCount = maxItemCount;
        this.maxVolume = maxVolume;
        this.maxWeight = maxWeight;
    }

    public bool Add(InventoryItem item)
    {
        if (items.Count >= maxItemCount || GetTotalVolume() + item.Volume > maxVolume || GetTotalWeight() + item.Weight > maxWeight)
        {
            return false;
        }

        items.Add(item);
        return true;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Pack Contents:");
        foreach (InventoryItem item in items)
        {
            sb.AppendLine($"- {item.GetType().Name}");
        }
        return sb.ToString();
    }

    private double GetTotalVolume()
    {
        double totalVolume = 0.0;
        foreach (InventoryItem item in items)
        {
            totalVolume += item.Volume;
        }
        return totalVolume;
    }

    private double GetTotalWeight()
    {
        double totalWeight = 0.0;
        foreach (InventoryItem item in items)
        {
            totalWeight += item.Weight;
        }
        return totalWeight;
    }
}
}
