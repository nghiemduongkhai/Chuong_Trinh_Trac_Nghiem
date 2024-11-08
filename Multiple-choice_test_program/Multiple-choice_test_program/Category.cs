using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiple_choice_test_program
{
    public class Category
    {
        private int categoryId;
        private string categoryName;
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public Category(int categoryId, string categoryName)
        {
            this.categoryId = categoryId;
            this.categoryName = categoryName;
        }
        public override string ToString()
        {
            return $"{CategoryName}";
        }
    }
}
