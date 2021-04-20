using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Accessibility
{
    public partial class TabIndexPage : ContentPage
    {
        IList<View> _views;
        bool _tabIndexOrderAscending = true;

        public TabIndexPage()
        {
            InitializeComponent();
            _views = _stackLayout.Children;
        }

        void OnTabIndexChangedClicked(object sender, EventArgs e)
        {
            int index = -100000;

            if (_tabIndexOrderAscending)
                _views.ForEach(v => v.TabIndex = index--);
            else
                _views.ForEach(v => v.TabIndex = index++);

            _tabIndexOrderAscending = !_tabIndexOrderAscending;
            _tabIndexButton.Text = _tabIndexButton.Text == "Descending TabIndex" ? "Ascending TabIndex" : "Descending TabIndex";
        }

        void OnZeroTabIndexClicked(object sender, EventArgs e)
        {
            _views.ForEach(v => v.TabIndex = 0);
        }

        void OnToggleIsTabStopClicked(object sender, EventArgs e)
        {
            _views.ForEach(v => v.IsTabStop = !v.IsTabStop);
        }

        void OnAlternatingIsTapStopClicked(object sender, EventArgs e)
        {
            for (int i = 0; i < _views.Count; i++)
            {
                _views[i].IsTabStop = i % 2 == 0;
            }
        }
    }
}
