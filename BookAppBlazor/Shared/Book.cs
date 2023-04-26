using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookAppBlazor.Shared;

public partial class Book
{
    [Key]
    public int IdBook { get; set; }
    [Required(ErrorMessage = "That field is required!")]
    [MaxLength(50,ErrorMessage = "The title of the book cannot be that long!")]
    public string Title { get; set; } = null!;
    [Required(ErrorMessage = "That field is required!")]
    [MaxLength(50, ErrorMessage = "The name of the author cannot be that long!")]
    public string Author { get; set; } = null!;
    [Required(ErrorMessage = "That field is required!")]
    [MaxLength(50, ErrorMessage = "The name of the editorial cannot be that long!")]
    public string Editorial { get; set; } = null!;
    [Required(ErrorMessage = "That field is required!")]
    [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
    public DateTime PublishDate { get; set; }
    [Required(ErrorMessage = "That field is required!")]
    [Range(0,999999999,ErrorMessage = "Insert a quantity between the range established 0 - 999999999")]
    public double Price { get; set; }

    public Book()
    {

    }
}
