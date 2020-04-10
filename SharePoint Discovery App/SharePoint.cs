﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using Microsoft.SharePoint.Client;

namespace SharePoint_Discovery_App
{
    class SharePoint
    {
        public static ListCollection GetLists(string siteUrl, string userName, string password, ref string errorMessage)
        {
            // Initialise empty object
            ClientContext clientContext = null;

            // Set the Client Context
            clientContext = GetClient(siteUrl, userName, password, ref errorMessage);

            if(clientContext == null)
            {
                return null;
            }

            // Define website object
            Web oWebsite = clientContext.Web;

            // Store lists in a collection
            ListCollection collList = oWebsite.Lists;

            // Retreive lists
            clientContext.Load(collList);
            clientContext.ExecuteQuery();

            return collList;
        }

        public static ClientContext GetClient(string siteUrl, string userName, string password, ref string errorMessage)
        {
            // Create a Secure String for password
            SecureString secPassword = new SecureString();

            // Append characters of password to Secure String
            foreach (char c in password.ToCharArray())
            {
                secPassword.AppendChar(c);
            }

            // Initialise an empty object
            ClientContext clientContext = null;

            // Set the Client Context
            try
            {
                clientContext = new ClientContext(siteUrl);

                // Enter credentials
                clientContext.Credentials = new SharePointOnlineCredentials(userName, secPassword);
            }
            catch(Exception e)
            {
                errorMessage = e.Message;
            }            

            // Return the object
            return clientContext;
        }
    }
}