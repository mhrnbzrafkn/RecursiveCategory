using System;
using System.Collections.Generic;
using System.Linq;

namespace Recursive
{
    public class Recursiver
    {
        public static void Main(string[] args)
        {
            List<Category> categoires = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Title = "A",
                    ParentId = null
                },
                new Category()
                {
                    Id = 2,
                    Title = "B",
                    ParentId = 1
                },
                new Category()
                {
                    Id = 3,
                    Title = "C",
                    ParentId = 2
                },
                new Category()
                {
                    Id = 4,
                    Title = "D",
                    ParentId = 3
                },
            };

            var categoriesWithParents = Prepare(categoires);

            Console.ReadLine();
        }

        private void Prepare(List<Category> categoires)
        {
            foreach (var x in categoires)
            {
                if (x.ParentId != null)
                {
                    foreach (var y in categoires
                        .Where(_ => _.ParentId == x.ParentId))
                    {
                        categoires
                            .FirstOrDefault(_ => _.ParentId == x.ParentId)
                            .Descendants.Add(y);
                    }
                }
            }

            return categoires;
        }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public List<Category> Descendants { get; set; }
    }
}
