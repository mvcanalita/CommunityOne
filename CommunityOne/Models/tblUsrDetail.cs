//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CommunityOne.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUsrDetail
    {
        public int UsrDetailsID { get; set; }
        public int UsrInfoID { get; set; }
        public string UsrFName { get; set; }
        public string UsrLName { get; set; }
        public string UsrMName { get; set; }
        public int UsrDepartment { get; set; }
        public string UsrPosition { get; set; }
        public string UsrEmpCode { get; set; }
        public string UsrAddress { get; set; }
        public string UsrSection { get; set; }
        public string UsrEAdd { get; set; }
        public Nullable<bool> UsrGender { get; set; }
        public Nullable<System.DateTime> UsrDateOfBirth { get; set; }
        public string UsrContactNo { get; set; }
        public string Usrhoobies { get; set; }
        public string UsrMotto { get; set; }
        public Nullable<long> UsrProfileID { get; set; }
        public string UsrNickName { get; set; }
    
        public virtual tblUsrInfo tblUsrInfo { get; set; }
    }
}