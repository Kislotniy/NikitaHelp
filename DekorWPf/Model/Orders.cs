//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DekorWPf.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public int id_Orders { get; set; }
        public int id_Product { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<System.DateTime> DateOrder { get; set; }
        public Nullable<System.DateTime> DateDelivery { get; set; }
        public string Issue_number { get; set; }
        public int id_User { get; set; }
        public string Kode { get; set; }
        public int id_Status { get; set; }
    
        public virtual Products Products { get; set; }
        public virtual Satus_Orders Satus_Orders { get; set; }
        public virtual Users Users { get; set; }
    }
}
