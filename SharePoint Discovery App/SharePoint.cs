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
        public static ListCollection GetLists(ClientContext clientContext)
        {
            string errorMessage = "";
            return GetLists(clientContext, ref errorMessage);
        }

        public static ListCollection GetLists(ClientContext clientContext, ref string errorMessage)
        {
            // Define empty collection
            ListCollection collList = null;

            try
            {
                // Store lists in a collection
                collList = clientContext.Web.Lists;

                // Retreive lists
                clientContext.Load(collList);

                clientContext.ExecuteQuery();
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return null;
            }            
            
            return collList;
        }

        public static SecureString securePassword(string password)
        {
            // Create a Secure String for password
            SecureString secPassword = new SecureString();

            // Append characters of password to Secure String
            foreach (char c in password.ToCharArray())
            {
                secPassword.AppendChar(c);
            }

            return secPassword;
        }

        public static ClientContext GetClient(string siteUrl, string userName, string password)
        {
            string errorMessage = "";
            return GetClient(siteUrl, userName, password, ref errorMessage);
        }

        public static ClientContext GetClient(string siteUrl, string userName, string password, ref string errorMessage)
        {
            // Create a Secure String for password
            SecureString secPassword = securePassword(password);

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
