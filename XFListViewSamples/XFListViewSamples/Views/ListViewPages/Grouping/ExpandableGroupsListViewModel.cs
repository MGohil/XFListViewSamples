using MvvmHelpers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFListViewSamples.Models;
using XFListViewSamples.Services;

namespace XFListViewSamples.Views.ListViewPages.Grouping
{
    public class ExpandableGroupsListViewModel : BaseViewModel
    {
        public ObservableCollection<GroupViewModel> groupedItems = new ObservableCollection<GroupViewModel>();
        public ObservableCollection<GroupViewModel> GroupedItems
        {
            get { return groupedItems; }
            set { SetProperty(ref groupedItems, value); }
        }

        public ExpandableGroupsListViewModel()
        {
            Task.Run(async() =>
            {
                var livingItemsDataServicce = new LifeDataService();
                var livingItems = (await livingItemsDataServicce.GetItemsAsync()).ToList();

                var G = livingItems.GroupBy(x => x.Category).Select(x => new ObservableGroupCollection<string, LifeOnPlanetModel>(x)).ToList();
                Device.BeginInvokeOnMainThread(() =>
                {
                    foreach (var item in G)
                    {
                        GroupedItems.Add(
                            new GroupViewModel
                            (
                                new GroupModel
                                (
                                    header: item.Key,
                                    items: new ObservableCollection<GroupItemModel>(item.Select(i => new GroupItemModel(i.Id, i.Name)))
                                )
                            ));
                    }
                });
                               
            });
        }       
    }

    /// <summary>
    /// Class to handle all actions for Groups.
    /// It contains 
    ///     - The collection of Groups. 
    ///     - Property to say if Group is Expanded or Collapsed
    /// </summary>
    public class GroupViewModel : ObservableRangeCollection<GroupItemModel>, INotifyPropertyChanged
    {
        #region Fields        
        // It's a backup variable for storing CountryViewModel objects
        private ObservableRangeCollection<GroupItemModel> _itemCollection = new ObservableRangeCollection<GroupItemModel>();
        public GroupModel GroupModel { get; set; }
        #endregion

        #region Constructor
        public GroupViewModel(GroupModel groupModel, bool expanded = true)
        {
            GroupModel = groupModel;
            _expanded = expanded;
            _isGroupHeaderChecked = groupModel.IsGroupHeaderChecked;

            foreach (GroupItemModel item in groupModel.Items)
            {
                item.ItemCheckChangedCommand = new Command(ItemCheckChangedCommandExecute);
                _itemCollection.Add(item);
            }
            if (expanded)
            {
                AddRange(_itemCollection);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Property to get or set wheather the Group is in Expanded state or Collapsed state
        /// </summary>
        private bool _expanded;
        public bool Expanded
        {
            get { return _expanded; }
            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Expanded"));
                    OnPropertyChanged(new PropertyChangedEventArgs("StateIcon"));
                    if (_expanded)
                    {
                        AddRange(_itemCollection);
                    }
                    else
                    {
                        Clear();
                    }
                }
            }
        }

        /// <summary>
        /// Property gets or sets if the GroupHeader is Checked or Unchecked.
        /// </summary>
        private bool _isGroupHeaderChecked;
        public bool IsGroupHeaderChecked
        {
            get { return _isGroupHeaderChecked; }
            set
            {
                if (_isGroupHeaderChecked != value)
                {
                    _isGroupHeaderChecked = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("IsGroupHeaderChecked"));
                }
            }
        }

        /// <summary>
        /// Gets the Expand / Collpase state icon of the Group, based on wheather the Group is expanded or collapsed state
        /// </summary>
        public string StateIcon { get { return Expanded ? "collapse.png" : "expand.ing"; } }

        /// <summary>
        /// Text which binds as GroupHeader's Text Label
        /// </summary>
        public string HeaderText { get { return GroupModel.HeaderText; } }
        #endregion

        #region Commands
        /// <summary>
        /// A Command which is invoked when we tap on the Group Header Section
        /// It Expands / Collapse the Group Header
        /// </summary>
        private Command _groupHeaderTapCommand;
        public Command GroupHeaderTapCommand
        {
            get
            {
                return _groupHeaderTapCommand ?? (_groupHeaderTapCommand = new Command(GroupHeaderTapCommandExecute));
            }
        }

        /// <summary>
        /// A Command which is invoked when we mark / unmark Group header Checkbox
        /// It selects or deselects all the items under the current group
        /// </summary>
        private Command _groupHeaderCheckChangeCommand;
        public Command GroupHeaderCheckChangedCommand
        {
            get
            {
                return _groupHeaderCheckChangeCommand ?? (_groupHeaderCheckChangeCommand = new Command(GroupHeaderCheckChangeCommandExecute));
            }
        }
        #endregion

        #region CommandExecutes
        /// <summary>
        /// This command is invoked when we tap on any child item of the group.
        /// If all checkbox under the one group is marked then that group header checkbox is marked or else it is unmarked
        /// </summary>
        private void ItemCheckChangedCommandExecute()
        {
            IsGroupHeaderChecked = _itemCollection.All(x => x.IsSelected);
        }
        /// <summary>
        /// It expands or collpases the Group header 
        /// </summary>
        private void GroupHeaderTapCommandExecute()
        {
            Expanded = !Expanded;
        }

        /// <summary>
        /// It selects or deselects all the items under the current group
        /// </summary>
        private void GroupHeaderCheckChangeCommandExecute()
        {
            Expanded = true;
            GroupModel.Items.ToList().ForEach(x => x.IsSelected = IsGroupHeaderChecked);
            ReplaceRange(_itemCollection);
        }
        #endregion
    }

    public class GroupItemModel : ObservableObject
    {
        public int Id { get; set; }
        public string DisplayText { get; set; }

        public Command ItemCheckChangedCommand { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }

        public GroupItemModel(int id, string displayText, bool isSelected = false)
        {
            Id = id;
            IsSelected = isSelected;
            DisplayText = displayText;
        }
    }

    public class GroupModel
    {
        public string HeaderText { get; set; }
        public bool IsGroupHeaderChecked { get; set; }
        public ObservableCollection<GroupItemModel> Items { get; set; }
        public GroupModel(string header, ObservableCollection<GroupItemModel> items, bool isGroupHeaderChecked = false)
        {
            HeaderText = header;
            Items = items;
            IsGroupHeaderChecked = isGroupHeaderChecked;
        }
    }
}
