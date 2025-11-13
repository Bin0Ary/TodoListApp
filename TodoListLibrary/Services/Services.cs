using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListLibrary.DataAccess;
using TodoListLibrary.Helpers;
using TodoListLibrary.Models;

namespace TodoListLibrary.Services
{
    public class Services : IServices
    {
        private IStorage _storage;
        public Services(IStorage storage)
        {
            _storage = storage;
        }
        void IServices.CreateTodoItem(List<TodoListItemModel> list, TodoListItemModel model ,string fileName, string categoryName = "")
        {
            list.Add(model);
            _storage.Create(PathHelper.GetFilePath(fileName, categoryName), list);
        }

        void IServices.CreateTodoList(List<TodoListItemModel> list, string fileName, string categoryName = "")
        {
            _storage.Create(PathHelper.GetFilePath(fileName, categoryName), list);
        }

        void IServices.DeleteTodoItem(List<TodoListItemModel> list, TodoListItemModel model, string fileName, string categoryName = "")
        {
            list.Remove(model);
            _storage.Create(PathHelper.GetFilePath(fileName, categoryName), list);
        }

        void IServices.DeleteTodoList(string fileName, string categoryName = "")
        {
            _storage.Delete(PathHelper.GetFilePath(fileName,categoryName));
        }

        void IServices.EditTodoItem(TodoListItemModel model, string fileName, string categoryName = "")
        {
            _storage.Edit(PathHelper.GetFilePath(fileName, categoryName), model);
        }

        void IServices.EditTodoList(string newName, string fileName, string categoryName = "")
        {
            var path = PathHelper.GetFilePath(fileName, categoryName);
            var list = _storage.Load(path);
            _storage.Delete(path);
            _storage.Create(PathHelper.GetFilePath(newName, categoryName), list);
        }
        List<TodoListItemModel> IServices.GetTodoList(string fileName, string categoryName = "")
        {
            return _storage.Load(PathHelper.GetFilePath(fileName, categoryName));
        }
    }
}
