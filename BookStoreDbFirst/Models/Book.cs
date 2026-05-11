using System;
using System.Collections.Generic;

namespace BookStoreDbFirst.Models;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal Price { get; set; }

    public int AuthorId { get; set; }

    public int PublisherId { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Publisher Publisher { get; set; } = null!;
}
