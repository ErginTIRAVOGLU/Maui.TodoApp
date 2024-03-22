using MauiTodoApp.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTodoApp.Mobile.DataServices
{
    public interface IRestDataService
    {
        Task<List<ToDo>> GetAllTodosAsync();
        Task AddTodoAsync(ToDo todo);
        Task UpdateTodoAsync(ToDo todo);
        Task DeleteTodoAsync(int id);
    }
}
