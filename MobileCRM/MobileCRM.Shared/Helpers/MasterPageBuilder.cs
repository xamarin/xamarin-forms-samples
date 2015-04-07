using System;
using MobileCRM.Shared.Pages;
using MobileCRM.Models;
using Xamarin.Forms;

namespace MobileCRM
{
	public class MasterPageBuilder
	{
		public MasterPage<Contact> BuildContacts(OptionItem option)
		{
			return new MasterPage<Contact>(option);
		}

		public MasterPage<Lead> BuildLeads(OptionItem option)
		{
			return new MasterPage<Lead>(option);
		}

		public MasterPage<Account> BuildAccounts(OptionItem option)
		{
			var page = new MasterPage<Account>(option);
			var cell = page.List.Cell;
			cell.SetBinding(TextCell.TextProperty, "Company");

			return page;
		}

		public MasterPage<Opportunity> BuildOpportunities(OptionItem option)
		{
			var page = new MasterPage<Opportunity>(option);
			var cell = page.List.Cell;
			cell.SetBinding(TextCell.TextProperty, "Company");
			cell.SetBinding(TextCell.DetailProperty, new Binding("EstimatedAmount", stringFormat: "{0:C}"));

			return page;
		}
	}
}