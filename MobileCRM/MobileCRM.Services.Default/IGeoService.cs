using System;
using MobileCRM.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MobileCRM.Services
{
	public interface IGeoService
	{
        IEnumerable<Address> ValidateAddress(string address);
	}

}

