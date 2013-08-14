using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

using LinkGame1.Common;
using LinkGame1.Controls;
using LinkGame1.Entities;

namespace LinkGame1.Views
{
    /// <summary>
    /// Interaction logic for PlayView.xaml.
    /// </summary>
    public partial class PlayView : UserControl
    {
        private readonly Mode mode;

        private bool isSelected;

        private LinkImage selectedChecker;

        public PlayView(Mode mode)
        {
            this.mode = mode;

            this.InitializeComponent();

            this.InitializeMap();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public LinkItem[][] Map
        {
            get
            {
                return this.mode.Map;
            }
        }

        protected virtual void SetProperty<T>(ref T field, T value, Expression<Func<T>> expr)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return;
            }

            field = value;
            var lambda = (LambdaExpression)expr;
            MemberExpression memberExpr;
            var body = lambda.Body as UnaryExpression;
            if (body != null)
            {
                var unaryExpr = body;
                memberExpr = (MemberExpression)unaryExpr.Operand;
            }
            else
            {
                memberExpr = (MemberExpression)lambda.Body;
            }

            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(memberExpr.Member.Name));
            }
        }

        private void InitializeMap()
        {
            MapHelper.InitializeMap(this.mode.Map, this.mode.RowCount, this.mode.ColumnCount, this.mode.ItemTypeCount);
        }

        private void SelectChecker(object sender, MouseButtonEventArgs e)
        {
            var checker = (LinkImage)sender;

            if (this.isSelected)
            {
                LinkItem cornerOne, cornerTwo;
                if (this.selectedChecker != checker && this.selectedChecker.Value.Value == checker.Value.Value && CanConnect(this.selectedChecker.Value, checker.Value, out cornerOne, out cornerTwo))
                {
                    var startY = (this.selectedChecker.Value.Row * 42) + 020;
                    var startX = (this.selectedChecker.Value.Column * 42) + 020;
                    var startPoint = new Point(startX, startY);
                    var line = LinkLineHelper.CreatePolyline(startPoint);

                    if (cornerOne != null)
                    {
                        var cornerOneY = (cornerOne.Row * 42) + 020;
                        var cornerOneX = (cornerOne.Column * 42) + 020;
                        var cornerOnePoint = new Point(cornerOneX, cornerOneY);
                        line.Points.Add(cornerOnePoint);
                    }

                    if (cornerTwo != null)
                    {
                        var cornerTwoY = (cornerTwo.Row * 42) + 20;
                        var cornerTwoX = (cornerTwo.Column * 42) + 20;
                        var cornerTwoPoint = new Point(cornerTwoX, cornerTwoY);
                        line.Points.Add(cornerTwoPoint);
                    }

                    var endY = (checker.Value.Row * 42) + 020;
                    var endX = (checker.Value.Column * 42) + 020;
                    var endPoint = new Point(endX, endY);
                    line.Points.Add(endPoint);

                    LinkLineHelper.DrawingPolyline(this.Container, line);
                    this.isSelected = false;
                    this.selectedChecker.IsEnabled = false;
                    checker.IsEnabled = false;
                    var timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 200) };
                    timer.Tick += (_, __) =>
                    {
                        LinkLineHelper.RemovePolyline(this.Container, line);

                        this.selectedChecker.Value.IsDead = true;
                        this.selectedChecker.IsDead = true;
                        checker.Value.IsDead = true;
                        checker.IsDead = true;
                        timer.Stop();
                    };
                    timer.Start();
                }
                else
                {
                    this.isSelected = true;
                    this.selectedChecker.IsSelected = false;
                    checker.IsSelected = true;
                    this.selectedChecker = checker;
                }
            }
            else
            {
                this.isSelected = true;
                this.selectedChecker = checker;

                checker.IsSelected = true;
            }
        }

        private void DrawConnectLine()
        {
            
        }

        /// <summary>
        /// Check if two item can connect within two corners.
        /// </summary>
        /// <param name="startItem">The start LinkImage item.</param>
        /// <param name="endItem">The end LinkImage item.</param>
        /// <param name="cornerOne">Corner One.</param>
        /// <param name="cornerTwo">Corner Two.</param>
        private bool CanConnect(LinkItem startItem, LinkItem endItem, out LinkItem cornerOne, out LinkItem cornerTwo)
        {
            if (startItem == null)
            {
                throw new ArgumentNullException("startItem");
            }

            if (endItem == null)
            {
                throw new ArgumentNullException("endItem");
            }

            if (this.IsDirectlyConnect(startItem, endItem))
            {
                cornerOne = null;
                cornerTwo = null;
                return true;
            }

            if (this.IsConnectWithInOneCorner(startItem, endItem, out cornerOne))
            {
                cornerTwo = null;
                return true;
            }

            if (this.IsConnectWithinTwoCorner(startItem, endItem, out cornerOne, out cornerTwo))
            {
                return true;
            }

            cornerOne = null;
            cornerTwo = null;
            return false;
        }

        private bool IsDirectlyConnect(LinkItem startItem, LinkItem endItem)
        {
            if (this.IsAdjacent(startItem, endItem))
            {
                return true;
            }

            var startRow = startItem.Row;
            var startColumn = startItem.Column;

            var endRow = endItem.Row;
            var endColumn = endItem.Column;

            // vertical connect
            var verticalConnected = false;
            if (startColumn.Equals(endColumn))
            {
                verticalConnected = true;
                for (int row = Math.Min(startRow, endRow) + 1; row <= Math.Max(startRow, endRow) - 1; row++)
                {
                    if (!this.Map[row][startColumn].IsDead)
                    {
                        verticalConnected = false;
                        break;
                    }
                }
            }

            if (verticalConnected)
            {
                return true;
            }
            
            // horizontal connect
            var horizontalConnected = false;
            if (startRow.Equals(endRow))
            {
                horizontalConnected = true;
                for (int column = Math.Min(startColumn, endColumn) + 1; column <= Math.Max(startColumn, endColumn) - 1; column++)
                {
                    if (!this.Map[startRow][column].IsDead)
                    {
                        horizontalConnected = false;
                        break;
                    }
                }
            }

            return horizontalConnected;
        }

        private bool IsAdjacent(LinkItem startItem, LinkItem endItem)
        {
            // horizontal adjacent
            if (Math.Abs(startItem.Row - endItem.Row) == 1 && startItem.Column.Equals(endItem.Column))
            {
                return true;
            }

            // vertical adjacent
            if (startItem.Row == endItem.Row && Math.Abs(startItem.Column - endItem.Column) == 1)
            {
                return true;
            }

            return false;
        }

        private bool IsConnectWithInOneCorner(LinkItem startItem, LinkItem endItem, out LinkItem cornerOne)
        {
            var startRow = startItem.Row;
            var startColumn = startItem.Column;

            var endRow = endItem.Row;
            var endColumn = endItem.Column;

            // right top corner
            var cornerItem = this.Map[startRow][endColumn];
            if (cornerItem.IsDead)
            {
                if (this.IsDirectlyConnect(startItem, cornerItem) && IsDirectlyConnect(cornerItem, endItem))
                {
                    cornerOne = cornerItem;
                    return true;
                }
            }

            // left bottom corner
            cornerItem = this.Map[endRow][startColumn];
            if (cornerItem.IsDead && this.IsDirectlyConnect(startItem, cornerItem) && this.IsDirectlyConnect(cornerItem, endItem))
            {
                cornerOne = cornerItem;
                return true;
            }

            cornerOne = null;
            return false;
        }

        private bool IsConnectWithinTwoCorner(LinkItem startItem, LinkItem endItem, out LinkItem cornerOne, out LinkItem cornerTwo)
        {
            var startRow = startItem.Row;
            var startColumn = startItem.Column;

            var endRow = endItem.Row;
            var endColumn = endItem.Column;

            LinkItem cornerOneItem, cornerTwoItem;

            // vertical line
            for (var column = 0; column < this.mode.ColumnCount; column++)
            {
                if (column == startColumn || column == endColumn)
                {
                    continue;
                }

                cornerOneItem = this.Map[startRow][column];
                cornerTwoItem = this.Map[endRow][column];

                if (cornerOneItem.IsDead && cornerTwoItem.IsDead)
                {
                    if (this.IsDirectlyConnect(startItem, cornerOneItem) && this.IsDirectlyConnect(cornerOneItem, cornerTwoItem) &&
                        this.IsDirectlyConnect(cornerTwoItem, endItem))
                    {
                        cornerOne = cornerOneItem;
                        cornerTwo = cornerTwoItem;
                        return true;
                    }
                }
            }

            // horizontal line
            for (int row = 0; row < this.mode.RowCount; row++)
            {
                if (row == startRow || row == endRow)
                {
                    continue;
                }

                cornerOneItem = this.Map[row][startColumn];
                cornerTwoItem = this.Map[row][endColumn];

                if (cornerOneItem.IsDead && cornerTwoItem.IsDead)
                {
                    if (this.IsDirectlyConnect(startItem, cornerOneItem) && this.IsDirectlyConnect(cornerOneItem, cornerTwoItem) &&
                        this.IsDirectlyConnect(cornerTwoItem, endItem))
                    {
                        cornerOne = cornerOneItem;
                        cornerTwo = cornerTwoItem;
                        return true;
                    }
                }
            }

            cornerOne = null;
            cornerTwo = null;
            return false;
        }
    }
}
