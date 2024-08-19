using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace LitLounge.Areas.Identity.Data;

// Add profile data for application users by adding properties to the LitLoungeUser class
public class LitLoungeUser : IdentityUser
{
   
    //[PersonalData]
    //public string? FirstName { get; set; }
    //[PersonalData]
    //public string? LastName { get; set; }
    [PersonalData]
    public string? NickName { get; set; }
    //[PersonalData]
    //public DateTime? BirthDate { get; set; }
    //[PersonalData]
    //public string? ProfilePicture { get; set; }
    [PersonalData]
    public string? ProfileImagePath { get; set; }

}

