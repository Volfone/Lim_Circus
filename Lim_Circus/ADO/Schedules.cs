//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lim_Circus.ADO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Schedules
    {
        public int Schedule_ID { get; set; }
        public int Events_ID { get; set; }
        public System.DateTime Date { get; set; }
        public int User_ID { get; set; }
        public int Event_ID { get; set; }
    
        public virtual Events Events { get; set; }
        public virtual Users Users { get; set; }
    }
}
