using FinTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinTracker.Domain.Entities
{
    public class Category
    {
        public int Id { get; private set; }

        public int UserId { get; private set; }
        public User User { get; private set; }

        public string Name { get; private set; }

        public CategoryType Type { get; private set; }

        public ICollection<Transaction> Transactions { get; private set; } = new List<Transaction>();

        public Category(User user, string name, CategoryType type)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty.", nameof(name));
            }
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            User = user;
            UserId = user.Id;
            Name = name;
            Type = type;
        }

        public void Rename(string name)
        {
            name.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("New name cannot be empty.", nameof(name));
            }
            if (Name == name)
            {
                throw new ArgumentException("New name cannot be same as old name.", nameof(name));
            }

            Name = name;
        }
    }
}
