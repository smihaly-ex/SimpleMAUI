﻿namespace SimpleMAUI.Core.Models;

public class Card
{
    public Guid Id { get; set; }
    public string Title { get; set; } = "";
    public string Text { get; set; } = "";
    public string Image { get; set; } = "";
}
