//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DClubs
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public int id_user { get; set; }
        public string user_login { get; set; }
        public string user_password { get; set; }
        public int id_account { get; set; }
    
        public virtual Accounts Accounts { get; set; }
    }
}
