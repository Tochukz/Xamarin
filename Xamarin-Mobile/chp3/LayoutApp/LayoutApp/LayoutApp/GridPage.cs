using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LayoutApp
{
	public class GridPage : ContentPage
	{
		public GridPage()
		{
			Grid grid1 = new Grid
			{
				ColumnSpacing = 1,
				RowSpacing = 1,
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions =
				{
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
					new RowDefinition { Height = GridLength.Auto },
				},
				ColumnDefinitions =
				{
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto },
					new ColumnDefinition { Width = GridLength.Auto }
				}
			};

			// Syntax grid.Children.Add(View, ColX, RowX); 
			grid1.Children.Add(new Label { Text = "Col 0, Row 0", BackgroundColor = Color.Red }, 0, 0);
			grid1.Children.Add(new Label { Text = "Col 1, Row 0, ", BackgroundColor = Color.Green }, 1, 0);
			grid1.Children.Add(new Label { Text = "Col 2, Row 0", BackgroundColor = Color.Gold }, 2, 0);

			grid1.Children.Add(new Label { Text = "Col 0, Row 1", BackgroundColor = Color.Red }, 0, 1);
			grid1.Children.Add(new Label { Text = "Col 1, Row 1", BackgroundColor = Color.Green }, 1, 1);
			grid1.Children.Add(new Label { Text = "Col 2, Row 1", BackgroundColor = Color.Gold }, 2, 1);

			grid1.Children.Add(new Label { Text = "Col 0, Row 2", BackgroundColor = Color.Red }, 0, 2);
			grid1.Children.Add(new Label { Text = "Col 1, Row 2", BackgroundColor = Color.Green }, 1, 2);
			grid1.Children.Add(new Label { Text = "Col 2, Row 2", BackgroundColor = Color.Gold }, 2, 2);

			/* Spanning COlumns and Rows*/
			Grid grid2 = new Grid
			{
				RowDefinitions =
				{
					new RowDefinition { Height = GridLength.Auto},
					new RowDefinition { Height = GridLength.Auto},
					new RowDefinition { Height = GridLength.Auto},
					new RowDefinition { Height = GridLength.Auto}
				},
				ColumnDefinitions =
				{
					new ColumnDefinition { Width = GridLength.Auto},
					new ColumnDefinition { Width = GridLength.Auto},
					new ColumnDefinition { Width = GridLength.Auto},
				}
			};
			// Syntax for spanning  multiple cells
			//grid.Children.Add( view, indexLeftColumn, indexRightColumn+1, indexTopRow, indexBottomRow+1) . Remeber that index is zero base
			grid2.Children.Add(new Label { Text = "Col 0, Row 0", BackgroundColor = Color.HotPink }, 0, 0);
			grid2.Children.Add(new Label { Text = "Col 1 + 2, Row 0", BackgroundColor = Color.Bisque}, 1, 3, 0, 1); // This cell will ocuppy 3-1 columns, and 1-0 rows starting at index col 1, row 0 

            grid2.Children.Add(new Label { Text = "Col 0, Row 1", BackgroundColor = Color.Pink }, 0, 1);
			grid2.Children.Add(new Label { Text = "Col 1, Row 1", BackgroundColor = Color.Red }, 1, 1);
			grid2.Children.Add(new Label { Text = "Col 2, Row 1", BackgroundColor = Color.Orange }, 2, 1);

			grid2.Children.Add(new Label { Text = "Col 0, Row 3 + 4", BackgroundColor = Color.Purple }, 0, 1, 2, 4); // This cell will occupy 1-0 columns and 4-2 rows starting at index col 0, row 2	
			grid2.Children.Add(new Label { Text = "Col 1, Row 3", BackgroundColor = Color.Maroon }, 1, 2);
			grid2.Children.Add(new Label { Text = "Col 2, Row 3", BackgroundColor = Color.Indigo }, 2, 2);

			grid2.Children.Add(new Label { Text = "Col 1, Row 3", BackgroundColor = Color.Blue }, 1, 3);
			grid2.Children.Add(new Label { Text = "Col 2, Row 3", BackgroundColor = Color.Violet }, 2, 3);
		


			/* Absolute sizes and star */
			Grid grid3 = new Grid
			{
				RowDefinitions =
				{
					new RowDefinition { Height = new GridLength(200, GridUnitType.Absolute)}, // Fixed Height
					new RowDefinition(),
					new RowDefinition(),
				},
				ColumnDefinitions =
				{
					new ColumnDefinition { Width = GridLength.Auto},
					new ColumnDefinition { Width = new GridLength(200, GridUnitType.Star)}, // This column takes the remainder of space available
					new ColumnDefinition { Width = GridLength.Auto}
				}
			};
			grid3.Children.Add(new Label { Text = "Col 0, Row 0", BackgroundColor = Color.Blue }, 0, 0);
			grid3.Children.Add(new Label { Text = "Col 1, Row 0", BackgroundColor = Color.Green }, 1, 0);
			grid3.Children.Add(new Label { Text = "Col 2, Row 0", BackgroundColor = Color.Aqua }, 2, 0);

			grid3.Children.Add(new Label { Text = "Col 0, Row 1", BackgroundColor = Color.Blue }, 0, 1);
			grid3.Children.Add(new Label { Text = "Col 1, Row 1", BackgroundColor = Color.Green }, 1, 1);
			grid3.Children.Add(new Label { Text = "Col 2, Row 1", BackgroundColor = Color.Aqua }, 2, 1);

			grid3.Children.Add(new Label { Text = "Col 0, Row 2", BackgroundColor = Color.Blue }, 0, 2);
			grid3.Children.Add(new Label { Text = "Col 1, Row 2", BackgroundColor = Color.Green }, 1, 2);
			grid3.Children.Add(new Label { Text = "Col 2, Row 2", BackgroundColor = Color.Aqua }, 2, 2);

			/* Proportionl column width*/
			Grid grid4 = new Grid
			{
				RowDefinitions =
				{
					new RowDefinition { Height = GridLength.Auto},
					new RowDefinition { Height = GridLength.Auto},
					new RowDefinition { Height = GridLength.Auto}
				},
				ColumnDefinitions =
				{
					/* Divids the column in a ratio of 1:3 */
					new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)},
					new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star)}
				},
			};
			grid4.Children.Add(new Label { Text = "1", BackgroundColor = Color.Purple }, 0, 0);
			grid4.Children.Add(new Label { Text = "John Smith", BackgroundColor = Color.IndianRed }, 1, 0);

			grid4.Children.Add(new Label { Text = "2", BackgroundColor = Color.Purple }, 0, 1);
			grid4.Children.Add(new Label { Text = "Max Planck", BackgroundColor = Color.IndianRed }, 1, 1);

			grid4.Children.Add(new Label { Text = "3", BackgroundColor = Color.Purple }, 0, 2);
			grid4.Children.Add(new Label { Text = "Frank Pens", BackgroundColor = Color.IndianRed }, 1, 2);

			Content = new StackLayout
			{
				Children =
				{
					grid1,
					grid2,
					grid3,
					grid4
				}
			};
			//Tip: The default GridLength setting for Height and Width, GridLength(1, GridUnitType.Star), expands the dimension of a row or column as much as possible

		}
	}
}