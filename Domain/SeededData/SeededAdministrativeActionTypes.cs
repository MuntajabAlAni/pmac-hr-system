using Domain.Models;
using System;

namespace Domain.SeededData;

public static class AdministrativeActionTypeSeed
{
    public static readonly AdministrativeActionType Thanking = new()
    {
        Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
        Name = "شكر وتقدير",
        ImpactInDays = 30, // Usually gives 1 month bonus for promotion
        IsPenalty = false,
        RaiseAffected = true
    };

    public static readonly AdministrativeActionType Appreciation = new()
    {
        Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
        Name = "تثمين جهود",
        ImpactInDays = 0, // Often just moral support, varies by law
        IsPenalty = false,
        RaiseAffected = false
    };

    public static readonly AdministrativeActionType Notice = new()
    {
        Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
        Name = "لفت نظر",
        ImpactInDays = -30, // Delays promotion
        IsPenalty = true,
        RaiseAffected = true
    };

    public static readonly AdministrativeActionType Warning = new()
    {
        Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
        Name = "إنذار",
        ImpactInDays = -90, // Delays promotion
        IsPenalty = true,
        RaiseAffected = true
    };

    public static readonly AdministrativeActionType Punishment = new()
    {
        Id = Guid.Parse("55555555-5555-5555-5555-555555555555"),
        Name = "توبيخ",
        ImpactInDays = -180, // Delays promotion
        IsPenalty = true,
        RaiseAffected = true
    };
}
