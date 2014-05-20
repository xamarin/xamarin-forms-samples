using System;

namespace EmployeeDirectory
{
	/// <summary>
	/// Provide an interface to code platform-specific implementations
	/// for common tasks required in the shared code, such as 
	/// making a call, sending an email or tweet, etc.
	/// </summary>
	public interface IPhoneFeatureService
	{
		bool Email (string emailAddress);
		bool Browse (string websiteUrl);
		bool Tweet (string twitterName);
		bool Call (string phoneNumber);
		bool Map (string address);
	}
}

