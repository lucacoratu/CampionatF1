//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CampionatF1
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class Constructor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Constructor()
        {
            this.Pilots = new ObservableCollection<Pilot>();
        }
    
        public int ConstructorID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<Pilot> Pilots { get; set; }
    }
}