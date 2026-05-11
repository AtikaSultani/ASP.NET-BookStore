using System;
using System.Collections.Generic;

namespace BookStoreDbFirst.Models;

public partial class Publisher
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
