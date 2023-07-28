using Ispit.Models;
using System.Runtime.Intrinsics.X86;

namespace Ispit.Interfaces
{
    public interface IRepository
    {
       

        List<TodoList> GetAllTodoLists();
        TodoList GetTodoListById(int id);
        void AddTodoList(TodoList todoList);
        void UpdateTodoList(TodoList todoList);
        void DeleteTodoList(int id);
        object? GetTodoLists();
    }
}
