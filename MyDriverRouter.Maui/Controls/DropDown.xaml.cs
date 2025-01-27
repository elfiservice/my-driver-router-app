using System.Windows.Input;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Console = System.Console;

namespace MyDriverRouter.Maui.Controls;

public partial class DropDown : ContentView
{
	public DropDown()
	{
		InitializeComponent();
	}
	
	public Color BorderColor { set => HeaderDropDown.BorderColor = value; }
	public event EventHandler<object>? SelectedValueChange;
	
	public static readonly BindableProperty IsDropDownEnabledProperty =
		BindableProperty.Create(
			nameof(IsDropDownEnabled),
			typeof(bool),
			typeof(DropDown),
			false,
			propertyChanged: (bindable, oldValue, newValue) => (bindable as DropDown).OnIsDropDownEnabledChanged(bindable, oldValue, newValue));

	void OnIsDropDownEnabledChanged(BindableObject bindable, object oldValue, object newValue)
	{
		if (bindable is DropDown dropDown)
		{
			dropDown.IsDropDownEnabled= (bool)newValue;
		}
	}

	public static readonly BindableProperty PlaceholderProperty =
		BindableProperty.Create(
			nameof(Placeholder),
			typeof(string),
			typeof(DropDown),
			default(string));

	public string Placeholder
	{
		get => (string)GetValue(PlaceholderProperty);
		set => SetValue(PlaceholderProperty, value);
	}

	public bool IsDropDownEnabled
	{
		get => (bool)GetValue(IsDropDownEnabledProperty);
		set => SetValue(IsDropDownEnabledProperty, value);
	}

	public static readonly BindableProperty SelectedItemProperty =
		BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(DropDown),
			defaultBindingMode: BindingMode.TwoWay,
			propertyChanged: (bindable, oldValue, newValue) => (bindable as DropDown).OnSelectedItemChanged(bindable, oldValue, newValue));

	void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
	{
		if (newValue is DropDownItemDto selectedItem)
		{
			Placeholder = selectedItem.Description;
			ExpanderBox.IsExpanded = false;
		}
		
		OnPropertyChanged(nameof(SelectedItem));
		SelectedValueChangeCommand?.Execute(SelectedItem);
		SelectedValueChange?.Invoke(this, SelectedItem);
	}

	public object SelectedItem
	{
		get => (object)GetValue(SelectedItemProperty);
		set => SetValue(SelectedItemProperty, value);
	}
	
	public static readonly BindableProperty SelectedValueChangeCommandProperty =
		BindableProperty.Create(nameof(SelectedValueChangeCommand), typeof(ICommand), typeof(DropDown));

	public ICommand SelectedValueChangeCommand
	{
		get => (ICommand)GetValue(SelectedValueChangeCommandProperty);
		set => SetValue(SelectedValueChangeCommandProperty, value);
	}
	
	public static readonly BindableProperty LabelTextProperty =
		BindableProperty.Create(nameof(LabelText), typeof(string), typeof(DropDown));

	public string LabelText
	{
		get => (string)GetValue(LabelTextProperty);
		set => SetValue(LabelTextProperty, value);
	}

	public static readonly BindableProperty ItemsSourceProperty =
		BindableProperty.Create(
			nameof(ItemsSource),
			typeof(List<DropDownItemDto>),
			typeof(DropDown),
			defaultBindingMode: BindingMode.TwoWay);

	public List<DropDownItemDto> ItemsSource
	{
		get => (List<DropDownItemDto>)GetValue(ItemsSourceProperty);
		set => SetValue(ItemsSourceProperty, value);
	}

	void Expander_ExpandedChanged(object? sender, ExpandedChangedEventArgs e)
	{
		var control = sender as Expander;
		SwitchIcon(control.IsExpanded);
	}

	void SwitchIcon(bool IsExpanded)
	{
		if (IsExpanded)
			HeaderIcon.Source = "arrow_up";
		else
			HeaderIcon.Source = "arrow_down";
	}
}

public class DropDownItemDto
{
	public string Description { get; set; }
	public string Key { get; set; }
}