
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ShopBridge.Models
{

using System;
    using System.Collections.Generic;
    
public partial class ManageOrder
{

    public int OrderId { get; set; }

    public string OrderName { get; set; }

    public string OrderCity { get; set; }

    public string OrderCountry { get; set; }

    public string OrderAddress { get; set; }

    public string OrderDescription { get; set; }

    public string Status { get; set; }

    public string Amount { get; set; }

    public Nullable<int> UserId { get; set; }



    public virtual User User { get; set; }

}

}
