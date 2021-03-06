﻿using System.ComponentModel.DataAnnotations;

namespace MetalMastery.Web.Models
{
    [MetadataType(typeof(LogOnModelMetadata))]
    public class SignInModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }

    public class LogOnModelMetadata
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}