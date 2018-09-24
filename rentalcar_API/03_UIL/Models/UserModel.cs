using _01_BOL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _03_UIL.Models
{
    public class UserModel
    {

        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string FullUserName { get; set; }
        [Required]
        private string myVar;
        public string UserIdNumber
        {
            get { return myVar; }
            set { myVar = IdTest(value); }
        }



        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string UserName { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 6)]
        public string Password { get; set; }
        public DateTime? BirthDay { get; set; }
        [Required]
        public string Sex { get; set; }

        public string UserPic { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string UserRole { get; set; }

        static string IdTest(string value)
        {
            int[] id_12_digits = { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            int count = 0;

            if (value == null)
                throw new InvalidOperationException("wrong id");

            value = value.PadLeft(9, '0');

            for (int i = 0; i < 9; i++)
            {
                int num = Int32.Parse(value.Substring(i, 1)) * id_12_digits[i];

                if (num > 9)
                    num = (num / 10) + (num % 10);

                count += num;
            }
            if (count % 10 == 0)
            {
                return value;
            }
            else
            {
                throw new InvalidOperationException("wrong id");
            }
        }
   
    }
}