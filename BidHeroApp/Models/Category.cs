﻿namespace BidHeroApp.Models
{
    public partial class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
