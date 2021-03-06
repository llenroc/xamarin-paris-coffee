﻿using System;
using ParisCoffee.Core;

namespace ParisCoffee.Droid
{
	public class ApiClientFactory :IApiClientFactory
	{
		public System.Net.Http.HttpMessageHandler CreateApiClient ()
		{
			return new ModernHttpClient.NativeMessageHandler ();
		}

		public Uri ApiUrl {get {return new Uri ("http://opendata.paris.fr/api/records/1.0/search/?dataset=liste-des-cafes-a-un-euro");}}

	}
}

