using System;
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
        public static ListCollection GetLists(string siteUrl, string userName, string password)
        {
            // Set the Client Context
            ClientContext clientContext = GetClient(siteUrl, userName, password);

            // Define website object
            Web oWebsite = clientContext.Web;

            // Store lists in a collection
            ListCollection collList = oWebsite.Lists;

            // Retreive lists
            clientContext.Load(collList);
            clientContext.ExecuteQuery();

            return collList;
        }

        public static ClientContext GetClient(string siteUrl, string userName, string password)
        {
            // Create a Secure String for password
            SecureString secPassword = new SecureString();

            // Append characters of password to Secure String
            foreach (char c in password.ToCharArray())
            {
                secPassword.AppendChar(c);
            }

            // Set the Client Context
            ClientContext clientContext = new ClientContext(siteUrl);

            // Enter credentials
            clientContext.Credentials = new SharePointOnlineCredentials(userName, secPassword);

            // Return the object
            return clientContext;
        }
    }
}
