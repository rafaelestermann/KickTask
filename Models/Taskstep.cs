//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KickTask.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Taskstep
    {
        public long ID { get; set; }
        public string Text { get; set; }
        public long Position { get; set; }
        public long TaskID { get; set; }
    
        public virtual Task Task { get; set; }
    }
}
