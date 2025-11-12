using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListLibrary.Models;

namespace TodoListLibrary.DataAccess
{
    public interface IStorage 
    {
        void Create(string path, List<TodoListItemModel> list);
        void Delete(string path);
        List<TodoListItemModel> Load(string path);
        void Edit(string path, TodoListItemModel model);
    }
}
