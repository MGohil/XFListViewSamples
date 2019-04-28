﻿namespace XFListViewSamples.Models
{
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
        LoadMoreItems
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
