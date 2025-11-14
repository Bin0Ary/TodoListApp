using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;
using System;
using TodoListLibrary.Models;
using TodoListProgram.Views;

namespace TodoListProgram.Controls;

public partial class TodoItemControl : UserControl
{
    
    public static readonly Avalonia.StyledProperty<TodoListItemModel> TodoItemProperty =
    Avalonia.AvaloniaProperty.Register<TodoItemControl, TodoListItemModel>(nameof(TodoItem),
    defaultBindingMode: Avalonia.Data.BindingMode.TwoWay);

    public TodoListItemModel TodoItem
    {
        get => GetValue(TodoItemProperty);
        set => SetValue(TodoItemProperty, value);
    }

    protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
    {
        base.OnPropertyChanged(change);

        if (change.Property == TodoItemProperty)
        {
            DataContext = TodoItem;
        }
    }

    public TodoItemControl()
    {
        InitializeComponent();
    }


    private void CheckBox_IsCheckedChanged(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (sender is not CheckBox checkBox || TodoItem == null)
            return;

        TodoItem.IsChecked = checkBox.IsChecked ?? false;

        
        var parent = this.FindAncestorOfType<ListView>();
        parent?.UpdateItem(TodoItem);
    }
}