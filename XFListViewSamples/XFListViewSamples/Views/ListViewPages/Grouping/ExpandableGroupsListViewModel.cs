using MvvmHelpers;
using System.Collections.Generic;
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
            Task.Run(async () =>
            {
                IsBusy = true;
                var livingItemsDataServicce = new LifeDataService();
                var livingItems = (await livingItemsDataServicce.GetItemsAsync()).ToList();
                var groups = livingItems.GroupBy(x => x.Category).Select(x => new ObservableGroupCollection<string, LifeOnPlanetModel>(x)).ToList();
                IsBusy = false;

                //This is required to invoke on main thread otherwise it will throw the exception
                Device.BeginInvokeOnMainThread(() =>
                {
                    foreach (var group in groups)
                    {
                        GroupedItems.Add(
                            new GroupViewModel
                            (
                                groupTitle: group.Key,
                                groupChildItems: group.Select(i => new GroupItemModel(i.Id, i.Name, i.IsSelected)).ToList()
                            ));
                    }
                });

            });
        }
    }

    /// <summary>
    /// Class to handle all actions for Groups.
    /// </summary>
    public class GroupViewModel : ObservableRangeCollection<GroupItemModel>, INotifyPropertyChanged
    {
        #region Fields        
        private readonly ObservableRangeCollection<GroupItemModel> _groupChildItemCollection = new ObservableRangeCollection<GroupItemModel>();
        #endregion

        #region Constructor
        public GroupViewModel(string groupTitle, List<GroupItemModel> groupChildItems, bool groupExpanded = true)
        {
            _groupTitle = groupTitle;
            _expanded = groupExpanded;

            foreach (GroupItemModel childItem in groupChildItems)
            {
                childItem.ItemCheckChangedCommand = new Command(ItemCheckChangedCommandExecute);
                _groupChildItemCollection.Add(childItem);
            }
            if (groupExpanded)
            {
                AddRange(_groupChildItemCollection);
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
                        AddRange(_groupChildItemCollection);
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
        public string StateIcon { get { return Expanded ? "collapse.png" : "expand.png"; } }

        /// <summary>
        /// Text which binds as GroupTitle's Text Label
        /// </summary>
        private string _groupTitle;
        public string GroupTitle
        {
            get { return _groupTitle; }
            set
            {
                if (_groupTitle != value)
                {
                    _groupTitle = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("GroupTitle"));
                }
            }
        }
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
            IsGroupHeaderChecked = _groupChildItemCollection.All(x => x.IsSelected);
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
            _groupChildItemCollection.ToList().ForEach(x => x.IsSelected = IsGroupHeaderChecked);
            ReplaceRange(_groupChildItemCollection);
        }
        #endregion
    }

    public class GroupItemModel : ObservableObject
    {
        public GroupItemModel(int id, string displayText, bool isSelected = false)
        {
            Id = id;
            IsSelected = isSelected;
            DisplayText = displayText;
        }
        public int Id { get; set; }
        public string DisplayText { get; set; }

        public Command ItemCheckChangedCommand { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetProperty(ref _isSelected, value); }
        }        
    }
}
