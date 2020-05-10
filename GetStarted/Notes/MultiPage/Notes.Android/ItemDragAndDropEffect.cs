using System;
using Android.Content;
using Notes.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AView = Android.Widget.AdapterView;
using LView = Android.Widget.ListView;
using ADragFlags = Android.Views.DragFlags;

[assembly: ResolutionGroupName("Notes")]
[assembly: ExportEffect(typeof(ItemDragAndDropEffect), "ItemDragAndDropEffect")]
namespace Notes.Droid.Effects
{
    public class ItemDragAndDropEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            // configure the ListView
            (Control as LView).OnItemLongClickListener = new ItemLongClickListen(this);
            (Control as LView).LongClickable = true;
            //Control.SetBackgroundColor(Android.Graphics.Color.LightGreen); // HACK: show it's bound
        }

        protected override void OnDetached()
        {
            if (Control != null && Control.Handle != IntPtr.Zero)
                (Control as AView).OnItemLongClickListener = null;
        }

        public class ItemLongClickListen : Java.Lang.Object, AView.IOnItemLongClickListener
        {
            ItemDragAndDropEffect _dragAndDropEffect;

            public ItemLongClickListen(ItemDragAndDropEffect dragAndDropEffect)
            {
                _dragAndDropEffect = dragAndDropEffect;
            }

            public bool OnItemLongClick(AView parent, Android.Views.View v, int position, long id)
            {
                if (v.Handle == IntPtr.Zero)
                    return false;

                // get the Note
                var noteString = (parent as LView).GetItemAtPosition(position).ToString();
                // clipData is the text from the note
                var data = ClipData.NewPlainText(
                    new Java.Lang.String("Note"),
                    new Java.Lang.String(noteString));
                // create a visual drag representation from the view
                var dragShadowBuilder = new AView.DragShadowBuilder(v);
                // start dragging
                v.StartDragAndDrop(data, dragShadowBuilder, v, (int)ADragFlags.Global);
                return true;
            }
        }
    }
}
