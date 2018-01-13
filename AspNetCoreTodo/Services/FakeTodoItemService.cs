using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public class FakeTodoItemService : ITodoItemService
    {
        public Task<IEnumerable<TodoItem>> GetIncompleteItemAsync()
        {
            IEnumerable<TodoItem> items = new[]
            {
                new TodoItem
                {
                    Title = "Learn ASP.NET Core",
                    DueAt = DateTimeOffset.Now.AddDays(1)
                },

                new TodoItem
                {
                    Title = "Build Awesome Apps",
                    DueAt = DateTimeOffset.Now.AddDays(2)
                },

                new TodoItem
                {
                    Title = "Learn Python the Hard Way",
                    DueAt = DateTimeOffset.Now.AddDays(5)
                }
            };

            return Task.FromResult(items);
        }
    }
}
