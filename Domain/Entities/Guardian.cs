using Domain.Entities;
using Domain.ValueObjects;
using System;
using Domain.Enums;

public class Guardian : User
{
    private readonly List<ChildGuardian> _childRelations = new();

    public IReadOnlyCollection<ChildGuardian> ChildRelations
        => _childRelations.AsReadOnly();

    protected Guardian()
    {
    }

    public Guardian(
        string firstName,
        string lastName,
        Email email,
        Address address,
        PhoneNumber phoneNumber)
        : base(firstName, lastName, email, phoneNumber, address)
    {
    }

    public void AddChildRelation(ChildGuardian relation)
    {
        if (relation is null)
            throw new ArgumentNullException(nameof(relation));

        if (_childRelations.Any(x =>
                x.ChildId == relation.ChildId))
        {
            throw new InvalidOperationException(
                "Guardian is already connected to this child.");
        }

        _childRelations.Add(relation);
    }

    public void RemoveChildRelation(Guid childId)
    {
        var relation = _childRelations
            .FirstOrDefault(x => x.ChildId == childId);

        if (relation is null)
            throw new InvalidOperationException(
                "Relation not found.");

        _childRelations.Remove(relation);
    }
}