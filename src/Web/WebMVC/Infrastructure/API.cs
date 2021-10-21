namespace WebMVC.Infrastructure
{
    public static class API
    {
        public static class Contact
        {
            public static string AddContact(string baseUri) => $"{baseUri}/contact/addcontact";
            public static string UpdateContact(string baseUri) => $"{baseUri}/contact/addcontact";
            public static string GetContactList(string baseUri) => $"{baseUri}/contact/addcontact";
            public static string GetContactRequestList(string baseUri) => $"{baseUri}/contact/addcontact";
            public static string AddContactRequest(string baseUri) => $"{baseUri}/contact/addcontact";
            public static string HandleContactRequest(string baseUri) => $"{baseUri}/contact/addcontact";
            public static string GetGroupList(string baseUri) => $"{baseUri}/contact/addcontact";
            public static string CreateGroup(string baseUri) => $"{baseUri}/contact/addcontact";
        }

        public static class Chat
        {
           
        }

        public static class File
        {

        }


        public static class Upload
        {

        }

        public static class Download
        {

        }
    }
}
