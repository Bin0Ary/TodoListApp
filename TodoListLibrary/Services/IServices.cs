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
        void CreateTodoList(string path, List<TodoListItemModel> list);
        void CreateTodoItem(string path, List<TodoListItemModel> list);
        void DeleteTodoList(string path);
        void DeleteTodoItem(string path, List<TodoListItemModel> list);
        void EditTodoList(string path, string newName);
        void EditTodoItem(string path, TodoListItemModel model);

    }
}
