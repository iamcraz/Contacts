using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace contacts_windowsform
{
    interface IContacts_repository
    {
        DataTable select_byname(string name) ;
        DataTable select_bymobile(string mobile);
        
        DataTable select_all();
        DataTable select_row(int contact_id);
        bool insert(string name, string mobile, string email, int age);
        bool update(int contact_id, string name, string mobile, string email, int age);
        
        bool del(int contact_id);

    }
}
