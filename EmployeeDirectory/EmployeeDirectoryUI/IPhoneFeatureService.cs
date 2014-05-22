using System;

namespace EmployeeDirectoryUI
{
	public interface IPhoneFeatureService
	{
		bool Email (string emailAddress);

		bool Browse (string websiteUrl);

		bool Tweet (string twitterName);

		bool Call (string phoneNumber);

		bool Map (string address);
	}
}

