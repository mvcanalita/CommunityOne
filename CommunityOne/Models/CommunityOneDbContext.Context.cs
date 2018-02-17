﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CommunityOneEntities : DbContext
    {
        public CommunityOneEntities()
            : base("name=CommunityOneEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblDepartment> tblDepartments { get; set; }
        public virtual DbSet<tblUsrDetail> tblUsrDetails { get; set; }
        public virtual DbSet<tblUsrInfo> tblUsrInfoes { get; set; }
        public virtual DbSet<vw_POHeaderShort> vw_POHeaderShort { get; set; }
    
        public virtual ObjectResult<proc_getUserLoginCredentials_Result> proc_getUserLoginCredentials(string uname, string upass)
        {
            var unameParameter = uname != null ?
                new ObjectParameter("uname", uname) :
                new ObjectParameter("uname", typeof(string));
    
            var upassParameter = upass != null ?
                new ObjectParameter("upass", upass) :
                new ObjectParameter("upass", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<proc_getUserLoginCredentials_Result>("proc_getUserLoginCredentials", unameParameter, upassParameter);
        }
    
        public virtual int proc_loadTopNthPOHeader(string buyrnam, string n)
        {
            var buyrnamParameter = buyrnam != null ?
                new ObjectParameter("buyrnam", buyrnam) :
                new ObjectParameter("buyrnam", typeof(string));
    
            var nParameter = n != null ?
                new ObjectParameter("n", n) :
                new ObjectParameter("n", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_loadTopNthPOHeader", buyrnamParameter, nParameter);
        }
    
        public virtual ObjectResult<vw_POHeaderShort> loadPOHeaderShort(string buyrnam, string n)
        {
            var buyrnamParameter = buyrnam != null ?
                new ObjectParameter("buyrnam", buyrnam) :
                new ObjectParameter("buyrnam", typeof(string));
    
            var nParameter = n != null ?
                new ObjectParameter("n", n) :
                new ObjectParameter("n", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<vw_POHeaderShort>("loadPOHeaderShort", buyrnamParameter, nParameter);
        }
    
        public virtual ObjectResult<vw_POHeaderShort> loadPOHeaderShort(string buyrnam, string n, MergeOption mergeOption)
        {
            var buyrnamParameter = buyrnam != null ?
                new ObjectParameter("buyrnam", buyrnam) :
                new ObjectParameter("buyrnam", typeof(string));
    
            var nParameter = n != null ?
                new ObjectParameter("n", n) :
                new ObjectParameter("n", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<vw_POHeaderShort>("loadPOHeaderShort", mergeOption, buyrnamParameter, nParameter);
        }
    }
}
