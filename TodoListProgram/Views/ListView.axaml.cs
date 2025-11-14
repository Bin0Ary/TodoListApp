using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using TodoListLibrary.DataAccess;
using TodoListLibrary.Models;
using TodoListLibrary.Services;

namespace TodoListProgram.Views;

public partial class ListView : UserControl
{
    private readonly IServices _services;
    private const string FileName = "bi";
    
    public ObservableCollection<TodoListItemModel> TodoItems { get; set; } = new();

    public ListView()
    {
        InitializeComponent();
        _services = new Services(new Storage());
        DataContext = this;
        
        TodoItems.CollectionChanged += TodoItems_CollectionChanged;
        
        Loaded += MainView_Loaded;
    }

    private void MainView_Loaded(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ReadDatabase();
    }

    private void TodoItems_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        WriteDatabase();
    }

    void ReadDatabase()
    {
        List<TodoListItemModel> list = _services.GetTodoList(FileName);
        if (list != null)
        {
            TodoItems.Clear();
            foreach (var item in list)
            {
                TodoItems.Add(item);
            }
        }
    }

    void WriteDatabase()
    {
        var list = new List<TodoListItemModel>(TodoItems);
        _services.CreateTodoList(list, FileName);
    }

    public void DeleteItem(TodoListItemModel item)
    {
        TodoItems.Remove(item);
    }

    public void UpdateItem(TodoListItemModel item)
    {
        _services.EditTodoItem(item, FileName);
    }
}