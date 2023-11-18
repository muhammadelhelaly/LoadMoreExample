namespace LoadMoreExample.ViewModels;

public class ItemsViewModel
{
    public IEnumerable<string> Items { get; set; } = [];
    public bool HasMoreItems { get; set; }
}