using WebkinzManagement.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebkinzManagement.Models
{
    public class Product
    {
        [Display(Name ="Product ID")]
        [Required(ErrorMessage = "Please fill in ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Please fill in name")]
        [MaxLength(30)]
        //[AllLetters(ErrorMessage = "Please enter letters only")]
        public string Name { get; set; }


        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        [MaxLength(300)]
        [Required(ErrorMessage = "Please fill in description")]
        public string Description { get; set; }


        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Please fill in price")]
        public double Price { get; set; }


        [Display(Name = "Plushie Image")]
        //[DataType(DataType.ImageUrl)] ?
        public string ImagePlush { get; set; }


        [Display(Name = "Avatar Image")]
        public string ImageAvatar { get; set; }
    }
}
