using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ecard.Model
{
    public class Questionnaire
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Your Favorite Color")]
        [Display(Prompt = "What is your favorite color?")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string favoritecolor { get; set; }

        [DisplayName("Your Favorite Movie Star")]
        [Display(Prompt = "Who is your favorite movie star?")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string moviestar { get; set; }

        [DisplayName("Favorite Ice Cream Flavor")]
        [Display(Prompt = "What is your favorite ice cream flavor?")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string icecream { get; set; }

        [DisplayName("Do You Play Music")]
        [Display(Prompt = "Do you play an instrument or just the radio?")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string musician { get; set; }

        [DisplayName("Dogs or Cats")]
        [Display(Prompt = "Do you prefer dogs or cats?")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string dogsorcats { get; set; }

        [DisplayName("Your Name")]
        [Display(Prompt = "Your Name")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string sendername { get; set; }

        [DisplayName("Your Email")]
        [Display(Prompt = "Your Email")]
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "You must enter between 2 to 100 characters")]
        public string senderemail { get; set; }

        public string created { get; set; }

        public string created_ip { get; set; }



    }
}