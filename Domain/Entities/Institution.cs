using Domain.Entities;
using Domain.ValueObjects;

public class Institution : EntityBase
{
    private readonly List<Room> _rooms = new();

    public string Name { get; private set; }

    public Address Address { get; private set; }

    public IReadOnlyCollection<Room> Rooms
        => _rooms.AsReadOnly();

    protected Institution()
    {
        Name = string.Empty;
        Address = null!;
    }

    public Institution(
        string name,
        Address address)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(
                "Institution name can't be empty.",
                nameof(name));

        Name = name.Trim();
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }

    public void Update(string name, Address address)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException(
                "Institution name can't be empty.",
                nameof(name));

        Name = name.Trim();
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }

    // AddRoom og RemoveRoom fortsætter her...
}