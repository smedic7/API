using Ispit.Interfaces;
using Ispit.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace Ispit.Repositories
{
    public class Repository : IRepository
    {

        private TodoapiContext _dbContext;
       

        public Repository(TodoapiContext dbContext)
        {

            _dbContext = dbContext;

        }



        public void AddTodoList(TodoList todoList)
        {
            try { 



            var result = _dbContext.TodoLists.Add(todoList);
            _dbContext.SaveChanges();

            }
        
            catch (Exception ex)
            {

                throw new Exception($"Error adding TodoList: {ex.Message}");
            }
            
            
            
            
            }

        public void DeleteTodoList(int id)
        {
            var result = _dbContext.TodoLists.FirstOrDefault(s => s.Id == id);

            if (result != null)
            {
                _dbContext.TodoLists.Remove(result);
                _dbContext.SaveChanges();
            }
        }

        public List<TodoList> GetAllTodoLists()
        {
            return _dbContext.TodoLists.ToList();
        }

        public TodoList GetTodoListById(int id)
        {
            return _dbContext.TodoLists.FirstOrDefault(s => s.Id == id);
        }

        public object? GetTodoLists()
        {
            throw new NotImplementedException();
        }

        public void UpdateTodoList(TodoList updatedTodoList)
        {
            var result = _dbContext.TodoLists.FirstOrDefault(s => s.Id == updatedTodoList.Id);

            if (result != null)
            {
                result.Title = updatedTodoList.Title;
                result.Description = updatedTodoList.Description;
                result.IsCompleted = updatedTodoList.IsCompleted;

                _dbContext.SaveChanges();

                
            }

          


        }
    }
}
