using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListLibrary.Models;

namespace TodoListLibrary.DataAccess
{
    public class Storage : IStorage
    {
        void IStorage.Create(string path, List<TodoListItemModel> list)
        {
            throw new NotImplementedException();
        }

        void IStorage.Delete(string path)
        {
            throw new NotImplementedException();
        }

        void IStorage.Edit(string path, TodoListItemModel model)
        {
            throw new NotImplementedException();
        }

        List<TodoListItemModel> IStorage.Load(string path)
        {
            throw new NotImplementedException();
        }
    }
}
