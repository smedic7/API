using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ispit.Models;
using Ispit.Interfaces;

namespace Ispit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListsController : ControllerBase
    {
        //private TodoapiContext _context;


        private IRepository _repository;

        public TodoListsController(IRepository repository)
        {
            _repository = repository;

        }
        // GET: api/TodoLists
        [HttpGet]
        public ActionResult<IEnumerable<TodoList>> GetAllTodoLists()
        {
            try
            {
                var todoLists = _repository.GetAllTodoLists();
                return Ok(todoLists);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error fetching data");
            }



        }

        // Post: api/TodoLists/5
        [HttpPost]

        public IActionResult AddTodoList(TodoList todoList)
        {
            try
            {
                _repository.AddTodoList(todoList);
                return CreatedAtAction(nameof(GetAllTodoLists), new { id = todoList.Id }, todoList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error adding data");
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutToDoList(int id, TodoList todolist)
        {
            try
            {
                if (id != todolist.Id) return BadRequest("Id Mismatch");

                var itemToUpdate = _repository.GetTodoListById(id);

                if (itemToUpdate == null) return NotFound();


                itemToUpdate.Title = todolist.Title;
                itemToUpdate.Description = todolist.Description;
                itemToUpdate.IsCompleted = todolist.IsCompleted;


                _repository.UpdateTodoList(itemToUpdate);


                return Ok(itemToUpdate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data!");


            }
        }
        
        
        [HttpDelete("{id}")]
            public IActionResult DeleteTodoList(int id)
            {
                try
                {
                    var todoList = _repository.GetTodoListById(id);
                    if (todoList == null)
                    {
                        return NotFound();
                    }

                    _repository.DeleteTodoList(id);

                    return NoContent();
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Greška prilikom brisanja podataka");
                }
            }






        









    }


    }







    
