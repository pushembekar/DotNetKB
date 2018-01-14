using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetIncompleteItemAsync();

        Task<bool> AddItemAsync(NewTodoItem newItem);

        Task<bool> MarkDoneAsync(Guid id);
    }
}
