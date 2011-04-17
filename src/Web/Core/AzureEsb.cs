#region Copyright (c) 2010 Lokad. New BSD License

// Copyright (c) Lokad 2010 SAS 
// Company: http://www.lokad.com
// This code is released as Open Source under the terms of the New BSD licence

#endregion

using Lokad.Cqrs.Feature.DefaultInterfaces;

namespace Web.Core
{
	public static class AzureEsb
	{
		public static void SendCommand(IMessage command)
		{
			GlobalSetup.Client.SendMessage(command);
		}
	}
}