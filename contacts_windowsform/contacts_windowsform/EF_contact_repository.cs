using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contacts_windowsform
{
    class EF_contact_repository : IContacts_repository
    {
        public bool del(int contact_id)
        {
            throw new NotImplementedException();
        }

        public bool insert(string name, string mobile, string email, int age)
        {
            throw new NotImplementedException();
        }

        public DataTable select_all()
        {
            throw new NotImplementedException();
        }

        public DataTable select_bymobile(string mobile)
        {
            throw new NotImplementedException();
        }

        public DataTable select_byname(string name)
        {
            throw new NotImplementedException();
        }

        public DataTable select_row(int contact_id)
        {
            throw new NotImplementedException();
        }

        public bool update(int contact_id, string name, string mobile, string email, int age)
        {
            throw new NotImplementedException();
        }
    }
}
