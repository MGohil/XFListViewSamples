namespace XFListViewSamples.Models
{
    public enum MenuItemType
    {
        TextCellSample,
        ImageCellSample,
        SwitchCellSample,
        EntryCellSample,
        CustomCellSample,
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
