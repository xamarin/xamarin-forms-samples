using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
[assembly: ExportCell(typeof(CustomRenderer.NativeCell), typeof(CustomRenderer.NativeCellRenderer))]
namespace CustomRenderer
{
    class NativeCellRenderer : ViewCellRenderer
    {
        private static readonly double PageHeight = App.Current.MainPage.Height;

        protected override ElmSharp.EvasObject OnGetContent(Cell cell, string part)
        {
            if (part != MainContentPart)
            {
                return null;
            }
            NativeCell viewCell = (NativeCell)cell;
            var minimumHeight = PageHeight > 800 ? 96 : 76;

            ElmSharp.Box mainBox = new ElmSharp.Box(Forms.NativeParent);
            mainBox.BackgroundColor = Color.LightYellow.ToNative();
            mainBox.MinimumHeight = minimumHeight;
            mainBox.IsHorizontal = false;
            mainBox.SetAlignment(-1, -1);
            mainBox.Show();

            ElmSharp.Box contentBox = new ElmSharp.Box(Forms.NativeParent);
            contentBox.MinimumHeight = minimumHeight;
            contentBox.IsHorizontal = true;
            contentBox.SetAlignment(-1, -1);
            contentBox.Show();

            ElmSharp.Box left = new ElmSharp.Box(Forms.NativeParent);
            left.IsHorizontal = false;
            left.Show();
            left.SetWeight(4.0, 1);
            left.SetAlignment(-1, -1);
            contentBox.PackEnd(left);

            ElmSharp.Label titleName = new ElmSharp.Label(Forms.NativeParent);
            left.PackEnd(titleName);
            titleName.Show();
            titleName.Text = $"<span font_size=34 font_style=italic color=#7F3300>   {viewCell.Name}</span>";
            titleName.MinimumWidth = 250;
            titleName.SetAlignment(-1, -1);

            ElmSharp.Label titleCategory = new ElmSharp.Label(Forms.NativeParent);
            left.PackEnd(titleCategory);
            titleCategory.Show();
            titleCategory.Text = $"<span align=center font_size=24 color=#008000>{viewCell.Category}</span>";
            titleCategory.SetAlignment(-1, -1);

            ElmSharp.Box right = new ElmSharp.Box(Forms.NativeParent);
            right.Show();
            right.MinimumWidth = 96;
            right.MinimumHeight = minimumHeight;
            right.SetWeight(1, 1);
            right.SetAlignment(-1, 0);

            ElmSharp.Image image;

            if (viewCell.ImageFilename != "")
            {
                image = new ElmSharp.Image(right);
                image.Load(global::Tizen.Applications.Application.Current.DirectoryInfo.Resource + viewCell.ImageFilename + ".jpg");
                image.SetAlignment(0.5, 0.5);
                image.MinimumHeight = minimumHeight;
                image.MinimumWidth = minimumHeight;
                image.Show();
                right.PackEnd(image);
            }

            ElmSharp.Rectangle rec = new ElmSharp.Rectangle(left);
            rec.MinimumHeight = 1;
            rec.MinimumWidth = 400;
            rec.AlignmentX = -1;
            rec.Color = ElmSharp.Color.Gray;
            rec.Show();

            contentBox.PackEnd(right);

            mainBox.PackEnd(contentBox);
            mainBox.PackEnd(rec);

            return mainBox;
        }
    }
}