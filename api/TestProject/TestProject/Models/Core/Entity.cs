using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace TestProject.Models.Core;

public abstract class Entity<TId>
{
    protected Entity([DisallowNull]TId id) => Id = id ?? throw new ArgumentNullException(nameof(id));

    [Key]
    public TId Id { get; set; }
}