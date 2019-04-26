using System.Collections.Generic;
using XFListViewSamples.Common;

namespace XFListViewSamples.Views.ListViewPages.BuiltInCells
{
    public class TextCellSampleViewModel : BaseViewModel
    {
        public List<string> Items { get; set; } = new List<string>();

        public TextCellSampleViewModel()
        {
            for (int i = 1; i <= 100; i++)
            {
                Items.Add($"Item {i}");
            }
        }
    }
}
