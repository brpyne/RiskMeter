using System;
using System.Collections.Generic;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using RiskMeter.Core.Models;

namespace RiskMeter.UI.Touch.ViewControllers
{
    public class LocationsViewController : MvxViewController
    {
        readonly Action<Location> LocationSelected;
        public IReadOnlyList<Location> Locations;

        public UITableView LocationsTableView { get; set; }

        public override void ViewDidLoad()
        {
            LocationsTableView = new UITableView(View.Bounds);

            Add(LocationsTableView);
        }

        class LocationListViewSource : UITableViewSource
        {
            readonly Action<Location> _locationSelected;
            public IReadOnlyList<Location> Locations;

            public LocationListViewSource(Action<Location> locationSelected)
            {
                _locationSelected = locationSelected;
            }

            public override int RowsInSection(UITableView tableview, int section)
            {
                return Locations == null ? 1 : Locations.Count;
            }

            public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
            {
                if (Locations == null)
                    return;
                _locationSelected(Locations[indexPath.Row]);
            }

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                if (Locations == null)
                {
                    //return new SpinnerCell();
                }

                //var cell = tableView.DequeueReusableCell(ProductListCell.CellId) as ProductListCell ?? new ProductListCell();
                //cell.Location = Locations[indexPath.Row];
                //return cell;

                return new UITableViewCell();
            }

            //class ProductListCell : UITableViewCell
            //{
            //    public const string CellId = "ProductListCell";
            //    static readonly SizeF PriceLabelPadding = new SizeF(16, 6);
            //    LocationModel product;
            //    TopAlignedImageView imageView;
            //    UILabel nameLabel, priceLabel;

            //    public LocationModel Product
            //    {
            //        get { return product; }
            //        set
            //        {
            //            product = value;

            //            nameLabel.Text = product.Name;
            //            priceLabel.Text = product.PriceDescription.ToLower();
            //            updateImage();
            //        }
            //    }

            //    public ProductListCell()
            //    {
            //        SelectionStyle = UITableViewCellSelectionStyle.None;
            //        ContentView.BackgroundColor = UIColor.LightGray;

            //        imageView = new TopAlignedImageView
            //        {
            //            ClipsToBounds = true,
            //        };

            //        nameLabel = new UILabel
            //        {
            //            TextColor = UIColor.White,
            //            TextAlignment = UITextAlignment.Left,
            //            Font = UIFont.FromName("HelveticaNeue-Light", 22),
            //            //ShadowColor = UIColor.DarkGray,
            //            //ShadowOffset = new System.Drawing.SizeF(.5f,.5f),
            //            Layer =
            //            {
            //                ShadowRadius = 3,
            //                ShadowColor = UIColor.Black.CGColor,
            //                ShadowOffset = new System.Drawing.SizeF(0, 1f),
            //                ShadowOpacity = .5f,
            //            }
            //        };

            //        priceLabel = new UILabel
            //        {
            //            Alpha = 0.95f,
            //            TextColor = UIColor.White,
            //            BackgroundColor = Color.Green,
            //            TextAlignment = UITextAlignment.Center,
            //            Font = UIFont.FromName("HelveticaNeue", 16),
            //            ShadowColor = UIColor.LightGray,
            //            ShadowOffset = new SizeF(.5f, .5f),
            //        };

            //        var layer = priceLabel.Layer;
            //        layer.CornerRadius = 3;

            //        ContentView.AddSubviews(imageView, nameLabel, priceLabel);
            //    }

            //    public override void LayoutSubviews()
            //    {
            //        base.LayoutSubviews();
            //        var bounds = ContentView.Bounds;

            //        imageView.Frame = bounds;
            //        nameLabel.Frame = new RectangleF(
            //            bounds.X + 12,
            //            bounds.Bottom - 58,
            //            bounds.Width,
            //            55
            //        );

            //        var priceSize = ((NSString)Product.PriceDescription).StringSize(priceLabel.Font);
            //        priceLabel.Frame = new RectangleF(
            //            bounds.Width - priceSize.Width - 2 * PriceLabelPadding.Width - 12,
            //            bounds.Bottom - priceSize.Height - 2 * PriceLabelPadding.Height - 14,
            //            priceSize.Width + 2 * PriceLabelPadding.Width,
            //            priceSize.Height + 2 * PriceLabelPadding.Height
            //        );
            //    }
            //}
        }
    }


}