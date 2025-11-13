using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TodoListLibrary.Models;

namespace TodoListLibrary.DataAccess
{
    public class Storage : IStorage
    {
        private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        void IStorage.Create(string path, List<TodoListItemModel> list)
        {
            var json = JsonSerializer.Serialize(list, _options);
            File.WriteAllText(path, json);
        }

        void IStorage.Delete(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        void IStorage.Edit(string path, TodoListItemModel model)
        {
           
            var list = ((IStorage)this).Load(path);

            var index = list.FindIndex(m => m.Id == model.Id);
            if (index >= 0)
                list[index] = model;

            ((IStorage)this).Create(path, list);
        }

        List<TodoListItemModel> IStorage.Load(string path)
        {
            if (!File.Exists(path))
                return new List<TodoListItemModel>();

            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<TodoListItemModel>>(json) ?? new List<TodoListItemModel>();
        }
    }
}
