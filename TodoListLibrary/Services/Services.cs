using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListLibrary.Models;

namespace TodoListLibrary.Services
{
    public class Services : IServices
    {
        void IServices.CreateTodoItem(string path, List<TodoListItemModel> list)
        {
            throw new NotImplementedException();
        }

        void IServices.CreateTodoList(string path, List<TodoListItemModel> list)
        {
            throw new NotImplementedException();
        }

        void IServices.DeleteTodoItem(string path, List<TodoListItemModel> list)
        {
            throw new NotImplementedException();
        }

        void IServices.DeleteTodoList(string path)
        {
            throw new NotImplementedException();
        }

        void IServices.EditTodoItem(string path, List<TodoListItemModel> list, TodoListItemModel model)
        {
            throw new NotImplementedException();
        }

        void IServices.EditTodoList(string path, string newName)
        {
            throw new NotImplementedException();
        }
    }
}
