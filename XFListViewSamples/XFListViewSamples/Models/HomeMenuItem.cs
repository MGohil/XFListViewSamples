namespace XFListViewSamples.Models
{
    public struct MenuCategory
    {
        public const string BuiltInCells = "Built-In Cells";
        public const string CustomCells = "Custom Cells";
        public const string DynamicCells = "Dynamic Cells";
        public const string Grouping = "Grouping";
        public const string HeaderFooter = "Header & Footer";
        public const string Operations = "ListView Operations";
    }

    public enum MenuItemType
    {
        TextCellSample,
        ImageCellSample,
        SwitchCellSample,
        EntryCellSample,
        CustomCellOne,
        CustomCellTwo,
        AlternateRowColor,
        DynamicRowHeight,
        ExpandableRow,
        DynamicCells,
        ListViewHeader,
        ListViewFooter,
        PullToRefresh,
        LoadMoreItems,
        BasicGrouping,
        ExpandableGroupList,
        ReOrderListViewItems
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }
    }
}
