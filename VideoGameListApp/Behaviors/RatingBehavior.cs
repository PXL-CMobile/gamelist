using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace VideoGameListApp.Behaviors
{
    class RatingBehavior: Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            int result;
            bool isValid = int.TryParse(args.NewTextValue, out result);
            if (isValid)
            {
                if (result < 0 ||result > 100)
                {
                    isValid = false;
                }
            }
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}
