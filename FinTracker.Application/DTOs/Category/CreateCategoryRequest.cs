using FinTracker.Domain.Enums;

namespace FinTracker.Application.DTOs.Category
{
    public class CreateCategoryRequest
    {
        public int UserId { get; set; }

        public string Name { get; set; } = string.Empty;

        public CategoryType Type { get; set; }
    }
}
