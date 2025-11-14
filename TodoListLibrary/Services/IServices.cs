using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListLibrary.Models;

namespace TodoListLibrary.Services
{
    public interface IServices
    {
        void CreateTodoList(List<TodoListItemModel> list, string fileName ,string categoryName = "");
        void CreateTodoItem(List<TodoListItemModel> list, TodoListItemModel model, string fileName, string categoryName = "");
        void DeleteTodoList(string fileName, string categoryName="");
        void DeleteTodoItem(List<TodoListItemModel> list, TodoListItemModel model, string fileName, string categoryName = "");
        void EditTodoList(string newName ,string fileName, string categoryName = "");
        void EditTodoItem(TodoListItemModel model, string fileName, string categoryName = "");
        List<TodoListItemModel> GetTodoList(string fileName, string categoryName = "");
    }
}
