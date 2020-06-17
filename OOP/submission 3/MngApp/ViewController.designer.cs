// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MngApp
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSTextField AllEmployeesLabel { get; set; }

		[Outlet]
		AppKit.NSTextField BudgetLabel { get; set; }

		[Outlet]
		AppKit.NSTextField BudgetTextField { get; set; }

		[Outlet]
		AppKit.NSPopUpButton EmployeePosition { get; set; }

		[Outlet]
		AppKit.NSTextField FilteredManagersLabel { get; set; }

		[Outlet]
		AppKit.NSTextField IDRemoveTextField { get; set; }

		[Outlet]
		AppKit.NSTextField isAddingSuccessfulLabel { get; set; }

		[Outlet]
		AppKit.NSTextField LevelTextField { get; set; }

		[Outlet]
		AppKit.NSTextField LevelToFilterTextField { get; set; }

		[Outlet]
		AppKit.NSTextFieldCell NameTextField { get; set; }

		[Outlet]
		AppKit.NSTextField SalaryTextField { get; set; }

		[Action ("AddEmployeeButton:")]
		partial void AddEmployeeButton (Foundation.NSObject sender);

		[Action ("BudgetButton:")]
		partial void BudgetButton (Foundation.NSObject sender);

		[Action ("ChangePositionDropDown:")]
		partial void ChangePositionDropDown (Foundation.NSObject sender);

		[Action ("CloseCompanyButton:")]
		partial void CloseCompanyButton (Foundation.NSObject sender);

		[Action ("ExportXMLButton:")]
		partial void ExportXMLButton (Foundation.NSObject sender);

		[Action ("FilterByLevelButton:")]
		partial void FilterByLevelButton (Foundation.NSObject sender);

		[Action ("ImportXMLButton:")]
		partial void ImportXMLButton (Foundation.NSObject sender);

		[Action ("ListEmployeesButton:")]
		partial void ListEmployeesButton (Foundation.NSObject sender);

		[Action ("RemoveByIDButton:")]
		partial void RemoveByIDButton (Foundation.NSObject sender);

		void ReleaseDesignerOutlets ()
		{
			if (AllEmployeesLabel != null) {
				AllEmployeesLabel.Dispose ();
				AllEmployeesLabel = null;
			}

			if (BudgetLabel != null) {
				BudgetLabel.Dispose ();
				BudgetLabel = null;
			}

			if (BudgetTextField != null) {
				BudgetTextField.Dispose ();
				BudgetTextField = null;
			}

			if (EmployeePosition != null) {
				EmployeePosition.Dispose ();
				EmployeePosition = null;
			}

			if (FilteredManagersLabel != null) {
				FilteredManagersLabel.Dispose ();
				FilteredManagersLabel = null;
			}

			if (IDRemoveTextField != null) {
				IDRemoveTextField.Dispose ();
				IDRemoveTextField = null;
			}

			if (isAddingSuccessfulLabel != null) {
				isAddingSuccessfulLabel.Dispose ();
				isAddingSuccessfulLabel = null;
			}

			if (LevelTextField != null) {
				LevelTextField.Dispose ();
				LevelTextField = null;
			}

			if (LevelToFilterTextField != null) {
				LevelToFilterTextField.Dispose ();
				LevelToFilterTextField = null;
			}

			if (NameTextField != null) {
				NameTextField.Dispose ();
				NameTextField = null;
			}

			if (SalaryTextField != null) {
				SalaryTextField.Dispose ();
				SalaryTextField = null;
			}
		}
	}
}
